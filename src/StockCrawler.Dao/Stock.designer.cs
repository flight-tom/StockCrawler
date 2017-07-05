﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
		
    #region Extensibility Method Definitions
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
		public int DeleteStockPriceHistoryData([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pStockID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> pTradeDate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockID, pTradeDate);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertStockPriceHistoryData")]
		public int InsertStockPriceHistoryData([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> pStockID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> pStockDT, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pOpenPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pHighPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pLowPrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pClosePrice, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> pVolume, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(10,4)")] System.Nullable<decimal> pAdjClosePrice)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockID, pStockDT, pOpenPrice, pHighPrice, pLowPrice, pClosePrice, pVolume, pAdjClosePrice);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DisableAllStocks")]
		public int DisableAllStocks()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetStocks")]
		public ISingleResult<GetStocksResult> GetStocks()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<GetStocksResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.InsertOrUpdateStockList")]
		public int InsertOrUpdateStockList([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string pStockNo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string pStockName)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pStockNo, pStockName);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class GetStocksResult
	{
		
		private int _StockID;
		
		private string _StockNo;
		
		private string _StockName;
		
		private bool _Enable;
		
		private System.DateTime _DateCreated;
		
		public GetStocksResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockID", DbType="Int NOT NULL")]
		public int StockID
		{
			get
			{
				return this._StockID;
			}
			set
			{
				if ((this._StockID != value))
				{
					this._StockID = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockName", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this._DateCreated = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
