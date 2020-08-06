﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quartz;
using StockCrawler.Services;

namespace StockCrawler.UnitTest.JobUnitTest
{
    /// <summary>
    ///This is a test class for StockPriceUpdateJobTest and is intended
    ///to contain all StockPriceUpdateJobTest Unit Tests
    ///</summary>
    [TestClass]
    public class StockPriceUpdateJobTest // : UnitTestBase
    {
        /// <summary>
        ///A test for Execute StockPriceUpdate
        ///</summary>
        [TestMethod()]
        public void StockPriceUpdateTest()
        {
            StockPriceUpdateJob.Logger = new UnitTestLogger();
            StockPriceUpdateJob target = new StockPriceUpdateJob("StockCrawler.Services.StockDailyPrice.TwseStockDailyInfoCollector, StockCrawler.Services");
            IJobExecutionContext context = null;
            target.Execute(context);
        }
    }
}
