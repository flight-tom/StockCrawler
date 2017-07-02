﻿using log4net;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StockCrawler.Services.StockDailyPrice
{
    internal class TwseStockDailyInfoCollector : IStockDailyInfoCollector
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(TwseStockDailyInfoCollector));
        private Dictionary<string, StockDailyPriceInfo> _stockInfoDict = null;
        public StockDailyPriceInfo GetStockDailyPriceInfo(string stock_code)
        {
            if (null == _stockInfoDict)
                lock (this)
                    if (null == _stockInfoDict)
                    {
                        _logger.Info("Initialize all stock information cache.");
                        _stockInfoDict = new Dictionary<string, StockDailyPriceInfo>();
#if(UNITTEST)
                        foreach (var info in GetAllStockDailyPriceInfo(new DateTime(2017, 6, 29)))
#else
                        foreach (var info in GetAllStockDailyPriceInfo(DateTime.Today))
#endif
                            _stockInfoDict[info.StockCode] = info;
                    }

            return (_stockInfoDict.ContainsKey(stock_code)) ? _stockInfoDict[stock_code] : null;
        }

        private static StockDailyPriceInfo[] GetAllStockDailyPriceInfo(DateTime day)
        {
            byte[] downloaded_data = null;
            using (var wc = new WebClient())
                downloaded_data = wc.DownloadData(string.Format("http://www.twse.com.tw/exchangeReport/MI_INDEX?response=csv&date={0}&type=ALLBUT0999", day.ToString("yyyyMMdd")));

            if (downloaded_data.Length == 0) return new StockDailyPriceInfo[] { }; // no data means there's no closed pricing data by the date.It could be caused by national holidays.

            string csv_data = Encoding.Default.GetString(downloaded_data);
            // twse csv has some corrupt lines make parse fail.
            csv_data = csv_data.Replace("\"\"漲跌價差\"為", "\"\"\"漲跌價差\"\"為").Replace("\"無比價\"含", "\"\"\"無比價\"\"含");

            // Usage of CsvReader: http://blog.darkthread.net/post-2017-05-13-servicestack-text-csvserializer.aspx
            var csv_lines = CsvReader.ParseLines(csv_data);
            var dsily_info = new List<StockDailyPriceInfo>();
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
                    // Generalize number fields data
                    for (int i = 2; i < data.Length; i++)
                        if (!string.IsNullOrEmpty(data[i]))
                            data[i] = data[i].Replace("--", "0").Replace(",", string.Empty);

                    dsily_info.Add(new StockDailyPriceInfo()
                    {
                        StockCode = data[0].Replace("=\"", string.Empty).Replace("\"", string.Empty),
                        StockName = data[1],
                        Volume = long.Parse(data[2]) / 1000,
                        LastTradeDT = day,
                        OpenPrice = decimal.Parse(data[5]),
                        HighPrice = decimal.Parse(data[6]),
                        LowPrice = decimal.Parse(data[7]),
                        ClosePrice = decimal.Parse(data[8])
                    });
                }
                else
                {
                    if ("證券代號" == data[0])
                        found_stock_list = true;
                }
            }
            return dsily_info.ToArray();
        }
    }
}