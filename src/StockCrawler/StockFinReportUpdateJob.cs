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
    public class StockFinReportUpdateJob : JobBase, IJob
    {
        internal static ILog Logger { get; set; } = LogManager.GetLogger(typeof(StockBasicInfoUpdateJob));

        public StockFinReportUpdateJob()
            : base()
        {
            if (null == Logger)
                Logger = LogManager.GetLogger(typeof(StockBasicInfoUpdateJob));
        }

        public StockFinReportUpdateJob(string collectorTypeName)
            : this()
        {
            CollectorTypeName = collectorTypeName;
        }

        public string CollectorTypeName { get; private set; }
        public short BeginYear { get; set; } = -1;

        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            Logger.InfoFormat("Invoke [{0}]...", MethodBase.GetCurrentMethod().Name);
            try
            {
                using (var db = StockDataServiceProvider.GetServiceInstance())
                {
                    var collector = string.IsNullOrEmpty(CollectorTypeName) ? CollectorProviderService.GetFinanceReportCashFlowCollector() : CollectorProviderService.GetFinanceReportCashFlowCollector(CollectorTypeName);
                    foreach (var d in db.GetStocks().Where(d => !d.StockNo.StartsWith("0") && (int.TryParse(d.StockNo.Substring(0, 4), out _)))) // 排除非公司的基金型股票
                    {
                        short year = GetTaiwanYear();
                        short season = (short)(GetSeason() - 1);
                        if (season <= 0) { season = 4; year -= 1; }
                        if (BeginYear > 100)
                        {
                            year = BeginYear;
                            season = 1;
                        }

                        for (; year <= GetTaiwanYear(); year++)
                        {
                            for (; season <= 4; season++)
                            {
                                var info = collector.GetStockReportCashFlow(d.StockNo, year, season);
                                if (null != info)
                                {
                                    db.UpdateStockFinaniceCashflowReport(info);
                                    Logger.InfoFormat("[{0}] get its finance report(year={1}/season={2})", d.StockNo, year, season);
                                }
                                else
                                {
                                    Logger.InfoFormat("[{0}] has no finance report(year={1}/season={2})", d.StockNo, year, season);
                                    break;
                                }
                            }
                            season = 1;
                        }

                        Thread.Sleep(1 * 1000); // Don't get target website pissed off...
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Job executing failed!", ex);
                throw;
            }
        }

        private static short GetTaiwanYear()
        {
            return (short)(SystemTime.Today.Year - 1911);
        }
        private static short GetSeason()
        {
            var month = SystemTime.Today.Month;
            return (short)(month / 3 + 1);
        }
        #endregion
    }
}