INSERT INTO [dbo].[StockFinancialReport]
    ([StockNo], [Year], [Season]
    ,[TotalAssets], [TotalLiability], [NetWorth], [NAV]
    ,[Revenue], [BusinessInterest], [NetProfitTaxFree], [EPS]
    ,[BusinessCashflow], [InvestmentCashflow], [FinancingCashflow])
SELECT 
	a.StockNo, a.[Year], a.Season
	, a.TotalAssets, a.TotalLiability, a.NetWorth,NAV -- ²���겣�t��
	, c.Revenue, c.BusinessInterest, c.NetProfitTaxFree, c.EPS -- ²����X�l�q��
	, b.BusinessCashflow, b.InvestmentCashflow, b.FinancingCashflow -- ²���{���y�q��
FROM [dbo].[StockReportBalance] a(NOLOCK)
	LEFT JOIN [dbo].[StockReportCashFlow] b(NOLOCK) ON a.StockNo = b.StockNo AND a.[Year] = b.[Year] AND a.Season = b.Season
	LEFT JOIN [dbo].[StockReportIncome] c(NOLOCK) ON a.StockNo = c.StockNo AND a.[Year] = c.[Year] AND a.Season = c.Season
GO
