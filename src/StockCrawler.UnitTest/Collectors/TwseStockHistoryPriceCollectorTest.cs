﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockCrawler.Services;
using StockCrawler.Services.Collectors;
using System;
using System.Linq;
#if (DEBUG)
namespace StockCrawler.UnitTest.Collectors
{
    [TestClass]
    public class TwseStockHistoryPriceCollectorTest : UnitTestBase
    {
        [TestMethod]
        public void GetStockHistoryPriceInfoTest()
        {
            TwseCollectorBase._breakInternval = 5 * 1000;
            var collector = new TwseStockHistoryPriceCollector
            {
                _logger = new UnitTestLogger()
            };
            SystemTime.SetFakeTime(new DateTime(2020, 4, 6));

            var r = collector.GetStockHistoryPriceInfo(TEST_STOCKNO_台積電, SystemTime.Today.AddDays(-1), SystemTime.Today);
            Assert.AreEqual(20, r.Count());
            Assert.IsTrue(r.Where(d => d.StockNo == TEST_STOCKNO_台積電).Any());
            var d1 = r.Where(x => x.StockDT == new DateTime(2020, 4, 6)).First();
            _logger.DebugFormat("StockNo={0}\r\nStockDT={1}\r\nOpenPrice={2}\r\nHighPrice={3}\r\nLowPrice={4}\r\nClosePrice={5}\r\nVolume={6}\r\nDeltaPrice={7}\r\nDeltaPercent={8}%\r\nPE={9}",
                d1.StockNo, d1.StockDT.ToShortDateString(), d1.OpenPrice, d1.HighPrice, d1.LowPrice, d1.ClosePrice, d1.Volume, d1.DeltaPrice, (d1.DeltaPercent * 100).ToString("#0.##"), d1.PE);
            Assert.AreEqual(TEST_STOCKNO_台積電, d1.StockNo);
            Assert.AreEqual(new DateTime(2020, 4, 6), d1.StockDT);
            Assert.AreEqual(275.5M, d1.ClosePrice);
            Assert.AreEqual(273M, d1.OpenPrice);
            Assert.AreEqual(275.5M, d1.HighPrice);
            Assert.AreEqual(270M, d1.LowPrice);
            Assert.AreEqual(59712754, d1.Volume);
            Assert.AreEqual(4M, d1.DeltaPrice);
            Assert.AreEqual(0.0147M, d1.DeltaPercent);
            Assert.AreEqual(0, d1.PE); // this source doesn't provide the value
        }
    }
}
#endif