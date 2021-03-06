ALTER TABLE [dbo].[StockPriceHistory] DROP CONSTRAINT [FK_StockPriceHistory_Stock]
GO
ALTER TABLE [dbo].[StockBasicInfo] DROP CONSTRAINT [FK_StockBasicInfo_Stock]
GO
ALTER TABLE [dbo].[StockReportCashFlow] DROP CONSTRAINT [FK_StockReportCashFlow_Stock]
GO
ALTER TABLE [dbo].[StockReportIncome] DROP CONSTRAINT [FK_StockReportIncome_Stock]
GO
ALTER TABLE [dbo].[StockReportBalance] DROP CONSTRAINT [FK_StockReportBalance_Stock]
GO
ALTER TABLE [dbo].[StockReportMonthlyNetProfitTaxed] DROP CONSTRAINT [FK_StockReportMonthlyNetProfitTaxed_Stock]
GO
ALTER TABLE [dbo].[StockAveragePrice] DROP CONSTRAINT [FK_StockAveragePrice_Stock]
GO
ALTER TABLE [dbo].[StockForumRelations] DROP CONSTRAINT [FK_StockForumRelations_Stock]
GO
ALTER TABLE [dbo].[StockForumRelations] DROP CONSTRAINT [FK_StockForumRelations_StockForums]
GO
ALTER TABLE [dbo].[LazyStockData] DROP CONSTRAINT [FK_LazyStockData_Stock]
GO
ALTER TABLE [dbo].[StockMarketNews] DROP CONSTRAINT [FK_StockMarketNews_Stock]
GO

