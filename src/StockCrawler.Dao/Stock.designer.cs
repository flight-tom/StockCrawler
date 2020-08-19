﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockCrawler.Dao
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Stock")]
	public partial class StockDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 擴充性方法定義
    partial void OnCreated();
    #endregion
		
		public StockDataContext() : 
				base(global::StockCrawler.Dao.Properties.Settings.Default.StockConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public StockDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public StockDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DeleteStockPriceHistoryData")]
		public int DeleteStockPriceHistoryData([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pTradeDate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pTradeDate);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertStockPriceHistoryData")]
		public int InsertStockPriceHistoryData([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pStockDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pOpenPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pHighPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pLowPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pClosePrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> pVolume, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pAdjClosePrice)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pStockDT, pOpenPrice, pHighPrice, pLowPrice, pClosePrice, pVolume, pAdjClosePrice);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DisableAllStocks")]
		public int DisableAllStocks()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStockBasicInfo")]
		public ISingleResult<GetStockBasicInfoResult> GetStockBasicInfo([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo);
			return ((ISingleResult<GetStockBasicInfoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStockHistory")]
		public ISingleResult<GetStockHistoryResult> GetStockHistory([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pDateBegin, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pDateEnd, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pTop, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pCurrentPage, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pPageSize, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> oPageCount)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pDateBegin, pDateEnd, pTop, pCurrentPage, pPageSize, oPageCount);
			oPageCount = ((System.Nullable<int>)(result.GetParameterValue(6)));
			return ((ISingleResult<GetStockHistoryResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStockReportCashFlow")]
		public ISingleResult<GetStockReportCashFlowResult> GetStockReportCashFlow([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pSeason)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pYear, pSeason);
			return ((ISingleResult<GetStockReportCashFlowResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStockReportIncome")]
		public ISingleResult<GetStockReportIncomeResult> GetStockReportIncome([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pSeason)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pYear, pSeason);
			return ((ISingleResult<GetStockReportIncomeResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStocks")]
		public ISingleResult<GetStocksResult> GetStocks()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetStocksResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertOrUpdateStock")]
		public int InsertOrUpdateStock([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string pStockName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pStockName);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertOrUpdateStockBasicInfo")]
		public int InsertOrUpdateStockBasicInfo([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string pCategory, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(100)")] string pCompanyName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pCompanyID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pBuildDate, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> pPublishDate, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pCapital, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pMarketValue, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> pReleaseStockCount, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string pChairman, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string pCEO, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(100)")] string pUrl, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(1000)")] string pBusiness)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pCategory, pCompanyName, pCompanyID, pBuildDate, pPublishDate, pCapital, pMarketValue, pReleaseStockCount, pChairman, pCEO, pUrl, pBusiness);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertOrUpdateStockReportCashFlow")]
		public int InsertOrUpdateStockReportCashFlow([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pSeason, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pDepreciation, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pAmortizationFee, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pBusinessCashflow, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pInvestmentCashflow, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pFinancingCashflow, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pCapitalExpenditures, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pFreeCashflow, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pNetCashflow)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pYear, pSeason, pDepreciation, pAmortizationFee, pBusinessCashflow, pInvestmentCashflow, pFinancingCashflow, pCapitalExpenditures, pFreeCashflow, pNetCashflow);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertOrUpdateStockReportIncome")]
		public int InsertOrUpdateStockReportIncome([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> pSeason, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pRevenue, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pGrossProfit, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pSalesExpense, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pManagementCost, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pRDExpense, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pOperatingExpenses, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pBusinessInterest, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pNetProfitTaxFree, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Money")] System.Nullable<decimal> pNetProfitTaxed)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pYear, pSeason, pRevenue, pGrossProfit, pSalesExpense, pManagementCost, pRDExpense, pOperatingExpenses, pBusinessInterest, pNetProfitTaxFree, pNetProfitTaxed);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class GetStockBasicInfoResult
	{
		
		private string _StockName;
		
		private string _StockNo;
		
		private string _Category;
		
		private string _CompanyName;
		
		private string _CompanyID;
		
		private System.DateTime _BuildDate;
		
		private System.DateTime _PublishDate;
		
		private decimal _Capital;
		
		private decimal _MarketValue;
		
		private long _ReleaseStockCount;
		
		private string _Chairman;
		
		private string _CEO;
		
		private string _Url;
		
		private string _Businiess;
		
		private System.DateTime _CreatedAt;
		
		private System.DateTime _LastModifiedAt;
		
		public GetStockBasicInfoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string StockName
		{
			get
			{
				return this._StockName;
			}
			set
			{
				if ((this._StockName != value))
				{
					this._StockName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockNo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string StockNo
		{
			get
			{
				return this._StockNo;
			}
			set
			{
				if ((this._StockNo != value))
				{
					this._StockNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Category", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this._Category = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string CompanyName
		{
			get
			{
				return this._CompanyName;
			}
			set
			{
				if ((this._CompanyName != value))
				{
					this._CompanyName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyID", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string CompanyID
		{
			get
			{
				return this._CompanyID;
			}
			set
			{
				if ((this._CompanyID != value))
				{
					this._CompanyID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BuildDate", DbType="Date NOT NULL")]
		public System.DateTime BuildDate
		{
			get
			{
				return this._BuildDate;
			}
			set
			{
				if ((this._BuildDate != value))
				{
					this._BuildDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublishDate", DbType="Date NOT NULL")]
		public System.DateTime PublishDate
		{
			get
			{
				return this._PublishDate;
			}
			set
			{
				if ((this._PublishDate != value))
				{
					this._PublishDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Capital", DbType="Money NOT NULL")]
		public decimal Capital
		{
			get
			{
				return this._Capital;
			}
			set
			{
				if ((this._Capital != value))
				{
					this._Capital = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MarketValue", DbType="Money NOT NULL")]
		public decimal MarketValue
		{
			get
			{
				return this._MarketValue;
			}
			set
			{
				if ((this._MarketValue != value))
				{
					this._MarketValue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReleaseStockCount", DbType="BigInt NOT NULL")]
		public long ReleaseStockCount
		{
			get
			{
				return this._ReleaseStockCount;
			}
			set
			{
				if ((this._ReleaseStockCount != value))
				{
					this._ReleaseStockCount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Chairman", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Chairman
		{
			get
			{
				return this._Chairman;
			}
			set
			{
				if ((this._Chairman != value))
				{
					this._Chairman = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CEO", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CEO
		{
			get
			{
				return this._CEO;
			}
			set
			{
				if ((this._CEO != value))
				{
					this._CEO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this._Url = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Businiess", DbType="NVarChar(1000) NOT NULL", CanBeNull=false)]
		public string Businiess
		{
			get
			{
				return this._Businiess;
			}
			set
			{
				if ((this._Businiess != value))
				{
					this._Businiess = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this._CreatedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifiedAt", DbType="DateTime NOT NULL")]
		public System.DateTime LastModifiedAt
		{
			get
			{
				return this._LastModifiedAt;
			}
			set
			{
				if ((this._LastModifiedAt != value))
				{
					this._LastModifiedAt = value;
				}
			}
		}
	}
	
	public partial class GetStockHistoryResult
	{
		
		private string _StockNo;
		
		private System.DateTime _StockDT;
		
		private decimal _OpenPrice;
		
		private decimal _HighPrice;
		
		private decimal _LowPrice;
		
		private decimal _ClosePrice;
		
		private decimal _AdjClosePrice;
		
		private long _Volume;
		
		private System.DateTime _CreatedAt;
		
		private System.Nullable<long> _RNO;
		
		public GetStockHistoryResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockNo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string StockNo
		{
			get
			{
				return this._StockNo;
			}
			set
			{
				if ((this._StockNo != value))
				{
					this._StockNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockDT", DbType="Date NOT NULL")]
		public System.DateTime StockDT
		{
			get
			{
				return this._StockDT;
			}
			set
			{
				if ((this._StockDT != value))
				{
					this._StockDT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OpenPrice", DbType="Decimal(10,4) NOT NULL")]
		public decimal OpenPrice
		{
			get
			{
				return this._OpenPrice;
			}
			set
			{
				if ((this._OpenPrice != value))
				{
					this._OpenPrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HighPrice", DbType="Decimal(10,4) NOT NULL")]
		public decimal HighPrice
		{
			get
			{
				return this._HighPrice;
			}
			set
			{
				if ((this._HighPrice != value))
				{
					this._HighPrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LowPrice", DbType="Decimal(10,4) NOT NULL")]
		public decimal LowPrice
		{
			get
			{
				return this._LowPrice;
			}
			set
			{
				if ((this._LowPrice != value))
				{
					this._LowPrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClosePrice", DbType="Decimal(10,4) NOT NULL")]
		public decimal ClosePrice
		{
			get
			{
				return this._ClosePrice;
			}
			set
			{
				if ((this._ClosePrice != value))
				{
					this._ClosePrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AdjClosePrice", DbType="Decimal(10,4) NOT NULL")]
		public decimal AdjClosePrice
		{
			get
			{
				return this._AdjClosePrice;
			}
			set
			{
				if ((this._AdjClosePrice != value))
				{
					this._AdjClosePrice = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Volume", DbType="BigInt NOT NULL")]
		public long Volume
		{
			get
			{
				return this._Volume;
			}
			set
			{
				if ((this._Volume != value))
				{
					this._Volume = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this._CreatedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RNO", DbType="BigInt")]
		public System.Nullable<long> RNO
		{
			get
			{
				return this._RNO;
			}
			set
			{
				if ((this._RNO != value))
				{
					this._RNO = value;
				}
			}
		}
	}
	
	public partial class GetStockReportCashFlowResult
	{
		
		private string _StockName;
		
		private string _StockNo;
		
		private short _Year;
		
		private short _Season;
		
		private decimal _Depreciation;
		
		private decimal _AmortizationFee;
		
		private decimal _BusinessCashflow;
		
		private decimal _InvestmentCashflow;
		
		private decimal _FinancingCashflow;
		
		private decimal _CapitalExpenditures;
		
		private decimal _FreeCashflow;
		
		private decimal _NetCashflow;
		
		private System.DateTime _CreatedAt;
		
		private System.DateTime _LastModifiedAt;
		
		public GetStockReportCashFlowResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string StockName
		{
			get
			{
				return this._StockName;
			}
			set
			{
				if ((this._StockName != value))
				{
					this._StockName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockNo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string StockNo
		{
			get
			{
				return this._StockNo;
			}
			set
			{
				if ((this._StockNo != value))
				{
					this._StockNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="SmallInt NOT NULL")]
		public short Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this._Year = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Season", DbType="SmallInt NOT NULL")]
		public short Season
		{
			get
			{
				return this._Season;
			}
			set
			{
				if ((this._Season != value))
				{
					this._Season = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Depreciation", DbType="Money NOT NULL")]
		public decimal Depreciation
		{
			get
			{
				return this._Depreciation;
			}
			set
			{
				if ((this._Depreciation != value))
				{
					this._Depreciation = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AmortizationFee", DbType="Money NOT NULL")]
		public decimal AmortizationFee
		{
			get
			{
				return this._AmortizationFee;
			}
			set
			{
				if ((this._AmortizationFee != value))
				{
					this._AmortizationFee = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessCashflow", DbType="Money NOT NULL")]
		public decimal BusinessCashflow
		{
			get
			{
				return this._BusinessCashflow;
			}
			set
			{
				if ((this._BusinessCashflow != value))
				{
					this._BusinessCashflow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvestmentCashflow", DbType="Money NOT NULL")]
		public decimal InvestmentCashflow
		{
			get
			{
				return this._InvestmentCashflow;
			}
			set
			{
				if ((this._InvestmentCashflow != value))
				{
					this._InvestmentCashflow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FinancingCashflow", DbType="Money NOT NULL")]
		public decimal FinancingCashflow
		{
			get
			{
				return this._FinancingCashflow;
			}
			set
			{
				if ((this._FinancingCashflow != value))
				{
					this._FinancingCashflow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CapitalExpenditures", DbType="Money NOT NULL")]
		public decimal CapitalExpenditures
		{
			get
			{
				return this._CapitalExpenditures;
			}
			set
			{
				if ((this._CapitalExpenditures != value))
				{
					this._CapitalExpenditures = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FreeCashflow", DbType="Money NOT NULL")]
		public decimal FreeCashflow
		{
			get
			{
				return this._FreeCashflow;
			}
			set
			{
				if ((this._FreeCashflow != value))
				{
					this._FreeCashflow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetCashflow", DbType="Money NOT NULL")]
		public decimal NetCashflow
		{
			get
			{
				return this._NetCashflow;
			}
			set
			{
				if ((this._NetCashflow != value))
				{
					this._NetCashflow = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this._CreatedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifiedAt", DbType="DateTime NOT NULL")]
		public System.DateTime LastModifiedAt
		{
			get
			{
				return this._LastModifiedAt;
			}
			set
			{
				if ((this._LastModifiedAt != value))
				{
					this._LastModifiedAt = value;
				}
			}
		}
	}
	
	public partial class GetStockReportIncomeResult
	{
		
		private string _StockName;
		
		private string _StockNo;
		
		private short _Year;
		
		private short _Season;
		
		private decimal _Revenue;
		
		private decimal _GrossProfit;
		
		private decimal _SalesExpense;
		
		private decimal _ManagementCost;
		
		private decimal _RDExpense;
		
		private decimal _OperatingExpenses;
		
		private decimal _BusinessInterest;
		
		private decimal _NetProfitTaxFree;
		
		private decimal _NetProfitTaxed;
		
		private System.DateTime _CreatedAt;
		
		private System.DateTime _LastModifiedAt;
		
		public GetStockReportIncomeResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string StockName
		{
			get
			{
				return this._StockName;
			}
			set
			{
				if ((this._StockName != value))
				{
					this._StockName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockNo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string StockNo
		{
			get
			{
				return this._StockNo;
			}
			set
			{
				if ((this._StockNo != value))
				{
					this._StockNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="SmallInt NOT NULL")]
		public short Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this._Year = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Season", DbType="SmallInt NOT NULL")]
		public short Season
		{
			get
			{
				return this._Season;
			}
			set
			{
				if ((this._Season != value))
				{
					this._Season = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Revenue", DbType="Money NOT NULL")]
		public decimal Revenue
		{
			get
			{
				return this._Revenue;
			}
			set
			{
				if ((this._Revenue != value))
				{
					this._Revenue = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GrossProfit", DbType="Money NOT NULL")]
		public decimal GrossProfit
		{
			get
			{
				return this._GrossProfit;
			}
			set
			{
				if ((this._GrossProfit != value))
				{
					this._GrossProfit = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalesExpense", DbType="Money NOT NULL")]
		public decimal SalesExpense
		{
			get
			{
				return this._SalesExpense;
			}
			set
			{
				if ((this._SalesExpense != value))
				{
					this._SalesExpense = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ManagementCost", DbType="Money NOT NULL")]
		public decimal ManagementCost
		{
			get
			{
				return this._ManagementCost;
			}
			set
			{
				if ((this._ManagementCost != value))
				{
					this._ManagementCost = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RDExpense", DbType="Money NOT NULL")]
		public decimal RDExpense
		{
			get
			{
				return this._RDExpense;
			}
			set
			{
				if ((this._RDExpense != value))
				{
					this._RDExpense = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OperatingExpenses", DbType="Money NOT NULL")]
		public decimal OperatingExpenses
		{
			get
			{
				return this._OperatingExpenses;
			}
			set
			{
				if ((this._OperatingExpenses != value))
				{
					this._OperatingExpenses = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessInterest", DbType="Money NOT NULL")]
		public decimal BusinessInterest
		{
			get
			{
				return this._BusinessInterest;
			}
			set
			{
				if ((this._BusinessInterest != value))
				{
					this._BusinessInterest = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetProfitTaxFree", DbType="Money NOT NULL")]
		public decimal NetProfitTaxFree
		{
			get
			{
				return this._NetProfitTaxFree;
			}
			set
			{
				if ((this._NetProfitTaxFree != value))
				{
					this._NetProfitTaxFree = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NetProfitTaxed", DbType="Money NOT NULL")]
		public decimal NetProfitTaxed
		{
			get
			{
				return this._NetProfitTaxed;
			}
			set
			{
				if ((this._NetProfitTaxed != value))
				{
					this._NetProfitTaxed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this._CreatedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifiedAt", DbType="DateTime NOT NULL")]
		public System.DateTime LastModifiedAt
		{
			get
			{
				return this._LastModifiedAt;
			}
			set
			{
				if ((this._LastModifiedAt != value))
				{
					this._LastModifiedAt = value;
				}
			}
		}
	}
	
	public partial class GetStocksResult
	{
		
		private string _StockNo;
		
		private string _StockName;
		
		private bool _Enable;
		
		private System.DateTime _CreatedAt;
		
		private System.DateTime _LastModifiedAt;
		
		public GetStocksResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockNo", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string StockNo
		{
			get
			{
				return this._StockNo;
			}
			set
			{
				if ((this._StockNo != value))
				{
					this._StockNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string StockName
		{
			get
			{
				return this._StockName;
			}
			set
			{
				if ((this._StockName != value))
				{
					this._StockName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enable", DbType="Bit NOT NULL")]
		public bool Enable
		{
			get
			{
				return this._Enable;
			}
			set
			{
				if ((this._Enable != value))
				{
					this._Enable = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this._CreatedAt = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModifiedAt", DbType="DateTime NOT NULL")]
		public System.DateTime LastModifiedAt
		{
			get
			{
				return this._LastModifiedAt;
			}
			set
			{
				if ((this._LastModifiedAt != value))
				{
					this._LastModifiedAt = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
