﻿using System;
using System.Collections.Generic;

namespace StockCrawler.Dao
{
    internal class StockDataServiceMSSQL : IStockDataService
    {
        public IList<GetStocksResult> GetStocks()
        {
            List<GetStocksResult> dt = new List<GetStocksResult>();
            using (var db = GetMSSQLStockDataContext())
            {
                foreach (var d in db.GetStocks())
                {
                    var dr = new GetStocksResult
                    {
                        Enable = d.Enable,
                        StockName = d.StockName,
                        StockNo = d.StockNo
                    };

                    dt.Add(dr);
                }
            }
            return dt;
        }

        public void UpdateStockPriceHistoryDataTable(IList<GetStockHistoryResult> list)
        {
            using (var db = GetMSSQLStockDataContext())
                foreach (var dr in list)
                    db.InsertStockPriceHistoryData(
                        dr.StockNo,
                        dr.StockDT,
                        dr.OpenPrice,
                        dr.HighPrice,
                        dr.LowPrice,
                        dr.ClosePrice,
                        dr.Volume,
                        dr.AdjClosePrice);
        }

        public void RenewStockList(IList<GetStocksResult> list)
        {
            using (var db = GetMSSQLStockDataContext())
            {
                db.DisableAllStocks();
                foreach (var dr in list)
                    db.InsertOrUpdateStock(dr.StockNo, dr.StockName);
            }
        }

        private static StockDataContext GetMSSQLStockDataContext()
        {
            return new StockDataContext(ConnectionStringHelper.StockConnectionString);
        }

        public void Dispose()
        {
        }

        public void DeleteStockPriceHistoryData(string stockNo, DateTime? tradeDate)
        {
            using (var db = GetMSSQLStockDataContext())
                db.DeleteStockPriceHistoryData(stockNo, tradeDate);
        }
        public void UpdateStockName(string stockNo, string stockName)
        {
            using (var db = GetMSSQLStockDataContext())
                db.InsertOrUpdateStock(stockNo, stockName);
        }
        public void UpdateStockBasicInfo(IEnumerable<GetStockBasicInfoResult> data)
        {
            foreach (var d in data)
                UpdateStockBasicInfo(d);
        }
        public void UpdateStockBasicInfo(GetStockBasicInfoResult info)
        {
            using (var db = GetMSSQLStockDataContext())
                db.InsertOrUpdateStockBasicInfo(
                    info.StockNo,
                    info.Category,
                    info.CompanyName,
                    info.CompanyID,
                    info.BuildDate,
                    info.PublishDate,
                    info.Capital,
                    info.MarketValue,
                    info.ReleaseStockCount,
                    info.Chairman,
                    info.CEO,
                    info.Url,
                    info.Businiess);
        }
        public void UpdateStockCashflowReport(GetStockReportCashFlowResult info)
        {
            using (var db = GetMSSQLStockDataContext())
                db.InsertOrUpdateStockReportCashFlow(
                    info.StockNo,
                    info.Year,
                    info.Season,
                    info.Depreciation,
                    info.AmortizationFee,
                    info.BusinessCashflow,
                    info.InvestmentCashflow,
                    info.FinancingCashflow,
                    info.CapitalExpenditures,
                    info.FreeCashflow,
                    info.NetCashflow);
        }

        public void UpdateStockIncomeReport(GetStockReportIncomeResult info)
        {
            using (var db = GetMSSQLStockDataContext())
                db.InsertOrUpdateStockReportIncome(
                    info.StockNo,
                    info.Year,
                    info.Season,
                    info.Revenue,
                    info.GrossProfit,
                    info.SalesExpense,
                    info.ManagementCost,
                    info.RDExpense,
                    info.OperatingExpenses,
                    info.BusinessInterest,
                    info.NetProfitTaxFree,
                    info.NetProfitTaxed);
        }
    }
}
