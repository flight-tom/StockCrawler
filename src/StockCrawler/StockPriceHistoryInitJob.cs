﻿using Common.Logging;
using Quartz;
using ServiceStack.Text;
using StockCrawler.Dao;
using StockCrawler.Dao.Schema;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace StockCrawler.Services
{
    public class StockPriceHistoryInitJob : JobBase, IJob
    {
#if(UNITTEST)
        public static ILog _logger { get; set; }
        private static readonly string _dbType = "MSSQL";
#else
        private static readonly ILog _logger = LogManager.GetLogger(typeof(StockPriceHistoryInitJob));
        private static readonly string _dbType = ConfigurationManager.AppSettings["DB_TYPE"];
#endif
        public StockPriceHistoryInitJob()
            : base()
        {
#if(UNITTEST)
            if (null == _logger)
                _logger = LogManager.GetLogger(typeof(StockPriceHistoryInitJob));
#endif
        }

        public int ProcessingStockID { get; set; }

        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("Invoke [{0}]...", MethodInfo.GetCurrentMethod().Name);
            // init stock list
            downloadTwselatestInfo();

            using (var db = StockDataService.GetServiceInstance(_dbType))
            {
                foreach (var d in db.GetStocks().Where(d => d.StockID == ProcessingStockID || ProcessingStockID == -1))
                {
                    db.DeleteStockPriceHistoryData(d.StockID, null);
                    initializeHistoricData(d.StockNo, DateTime.Today.AddYears(-5), DateTime.Today, d.StockID);
                    _logger.Info(string.Format("Finish the {0} stock history task.", d.StockNo));
                }
            }
        }

        #endregion

        private void downloadTwselatestInfo()
        {
            string downloaded_data = null;
#if(UNITTEST)
            string url = string.Format("https://www.twse.com.tw/exchangeReport/MI_INDEX?response=csv&date={0}&type=ALLBUT0999", new DateTime(2017, 5, 26).ToString("yyyyMMdd"));
#else
            string url = string.Format("https://www.twse.com.tw/exchangeReport/MI_INDEX?response=csv&date={0}&type=ALLBUT0999", DateTime.Today.ToString("yyyyMMdd"));
#endif
            _logger.DebugFormat("url=[{0}]", url);
            // https://blog.darkthread.net/blog/disable-tls-1-0-issues
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var req = HttpWebRequest.CreateHttp(url);
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            using (var res1 = req.GetResponse())
            {
                var stream = res1.GetResponseStream();
                using (var sr = new StreamReader(stream, Encoding.Default))
                    downloaded_data = sr.ReadToEnd();
            }

            string csv_data = downloaded_data;

            // Usage of CsvReader: http://blog.darkthread.net/post-2017-05-13-servicestack-text-csvserializer.aspx
            var csv_lines = CsvReader.ParseLines(csv_data);
            var dt = new StockDataSet.StockDataTable();
            bool found_stock_list = false;
            foreach (var ln in csv_lines)
            {
                //證券代號	證券名稱	成交股數	成交筆數	成交金額	開盤價	最高價	最低價	收盤價	漲跌(+/-)	漲跌價差	最後揭示買價	最後揭示買量	最後揭示賣價	最後揭示賣量	本益比
                string[] data = CsvReader.ParseFields(ln).ToArray();
                if (found_stock_list)
                {
                    if ("備註:" == data[0].Trim())
                    {
                        found_stock_list = false;
                        break;
                    }

                    var dr = dt.NewStockRow();
                    dr.StockNo = data[0].Replace("=\"", string.Empty).Replace("\"", string.Empty);
                    dr.StockName = data[1];
                    dr.Enable = true;
                    dr.DateCreated = DateTime.Now;
                    dt.AddStockRow(dr);
                    _logger.DebugFormat("StockNo={0} - StockName={1}", dr.StockNo, dr.StockName);
                }
                else
                {
                    if ("證券代號" == data[0])
                        found_stock_list = true;
                }
            }
            _logger.DebugFormat("dt.Count={0}", dt.Count);
            if (dt.Count > 0)
                StockDataService.GetServiceInstance(_dbType).RenewStockList(dt);
        }

        private string downloadYahooStockCSV(string stockNo, DateTime startDT, DateTime endDT)
        {
            DateTime base_date = new DateTime(1970, 1, 1);
            HttpWebRequest req = null;
            string url = string.Format("https://finance.yahoo.com/quote/{0}.TW/history?period1={1}&period2={2}&interval=1d&filter=history&frequency=1d",
                stockNo, (startDT - base_date).TotalSeconds, (endDT - base_date).TotalSeconds);
            Cookie c1 = null;
            req = HttpWebRequest.CreateHttp(url);
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            Uri target = new Uri("https://query1.finance.yahoo.com/");
            string crumb = null;
            using (var res1 = req.GetResponse())
            {
                string s2 = res1.Headers["Set-Cookie"];
                c1 = new Cookie("B", s2.Split(';')[0].Substring(2)) { Domain = ".yahoo.com" };
                string key = "\"CrumbStore\":{\"crumb\":\"";
                using (var sr = new StreamReader(res1.GetResponseStream(), Encoding.UTF8))
                {
                    var data = sr.ReadToEnd();
                    int sub_beg = data.IndexOf(key) + key.Length;
                    data = data.Substring(sub_beg);
                    int sub_end = data.IndexOf("\"");
                    crumb = data.Substring(0, sub_end);
                }
            }

            req = HttpWebRequest.CreateHttp(string.Format("https://query1.finance.yahoo.com/v7/finance/download/{0}.TW?period1={1}&period2={2}&interval=1d&events=history&crumb={3}",
                stockNo, (startDT - base_date).TotalSeconds, (endDT - base_date).TotalSeconds, crumb));
            req.Method = "GET";
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(c1);
            var res = req.GetResponse();
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
                return sr.ReadToEnd();
        }

        private void initializeHistoricData(string stockNo, DateTime startDT, DateTime endDT, int stockID)
        {
            try
            {
                var csv_data = downloadYahooStockCSV(stockNo, startDT, endDT);

                var csv_lines = CsvReader.ParseLines(csv_data).Skip(1);

                var dt = new StockDataSet.StockPriceHistoryDataTable();
                foreach (var ln in csv_lines)
                {
                    string[] data = CsvReader.ParseFields(ln).ToArray();
                    try
                    {
                        if (data.Length == 7)
                        {
                            var dr = dt.NewStockPriceHistoryRow();
                            dr.StockDT = DateTime.Parse(data[0]);
                            dr.OpenPrice = decimal.Parse(data[1]);
                            dr.HighPrice = decimal.Parse(data[2]);
                            dr.LowPrice = decimal.Parse(data[3]);
                            dr.ClosePrice = decimal.Parse(data[4]);
                            dr.AdjClosePrice = decimal.Parse(data[5]);
                            dr.Volume = long.Parse(data[6]) / 1000;
                            dr.StockID = stockID;
                            dr.DateCreated = DateTime.Now;
                            dt.AddStockPriceHistoryRow(dr);
                        }
                    }
                    catch (ConstraintException ex)
                    {
                        _logger.Warn(string.Format("Got duplicate data, skip it...[{0}]", stockNo), ex);
                    }
                    catch (FormatException)
                    {
                        _logger.WarnFormat("Got invalid format data...[{0}]", ln);
                    }
                }
                StockDataService.GetServiceInstance(_dbType).UpdateStockPriceHistoryDataTable(dt);
            }
            catch (WebException wex)
            {
                _logger.Error(string.Format("Got web error but will continue...(StockNo={0})", stockNo), wex);
                return;
            }
            catch (Exception ex)
            {
                _logger.Fatal(string.Format("Got unrecoverable error!(StockNo={0})", stockNo), ex);
                throw;
            }
        }
    }
}