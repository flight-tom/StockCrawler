﻿using Common.Logging;
using Quartz;
using StockCrawler.Dao;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace StockCrawler.Services
{
    public class StockBasicInfoUpdateJob : JobBase, IJob
    {
        internal static ILog Logger { get; set; } = LogManager.GetLogger(typeof(StockBasicInfoUpdateJob));

        public string BeginStockNo { get; set; }

        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            Logger.InfoFormat("Invoke [{0}]...", MethodBase.GetCurrentMethod().Name);
            try
            {
                using (var db = StockDataServiceProvider.GetServiceInstance())
                {
                    var collector = CollectorProviderService.GetStockBasicInfoCollector();
                    foreach (var d in db.GetStocks().Where(d => !d.StockNo.StartsWith("0") && (string.IsNullOrEmpty(BeginStockNo) || int.Parse(d.StockNo.Substring(0, 4)) >= int.Parse(BeginStockNo)))) // 排除非公司的基金型股票
                    {
                        try
                        {
                            var info = collector.GetStockBasicInfo(d.StockNo);
                            if (null != info)
                                db.InsertOrUpdateStockBasicInfo(info);
                            else
                                Logger.InfoFormat("[{0}] has no basic info", d.StockNo);
                        }catch(Exception e)
                        {
                            Logger.WarnFormat("[{0}] has no basic info", d.StockNo, e);
                        }
                        Thread.Sleep(_breakInternval);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Job executing failed!", ex);
                throw;
            }
        }
        #endregion
    }
}