/****** Object:  Table [dbo].[StockReportCashFlow]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
DROP TABLE [dbo].[StockReportCashFlow]
GO

/****** Object:  Table [dbo].[StockReportCashFlow]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockReportCashFlow](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	[Depreciation][MONEY] NOT NULL, --���¶O��
	[AmortizationFee] [MONEY] NOT NULL, -- �u�P
	[BusinessCashflow] [MONEY] NOT NULL, -- ��~�{���y, ��~���ʤ��b�{���y�J�]�y�X�^
	[InvestmentCashflow] [MONEY] NOT NULL, -- ���{���y, ��ꬡ�ʤ��b�{���y�J�]�y�X�^
	[FinancingCashflow][MONEY] NOT NULL, -- �ĸ�{���y, �w�ꬡ�ʤ��b�{���y�J�]�y�X�^
	[CapitalExpenditures][MONEY] NOT NULL,-- �ꥻ��X, (���o���ʲ��B�t�Фγ]�� + �B�����ʲ��B�t�Фγ]��)
	[FreeCashflow][MONEY] NOT NULL,-- �ۥѲ{���y = (��~�{���y - �ꥻ��X - �ѧQ��X)
	[NetCashflow][MONEY] NOT NULL,-- �b�{���y = ��~�{���y - ���{���y + �ĸ�{���y
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockReportCashFlow] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] ASC,
	[Season] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockReportCashFlow] ADD  CONSTRAINT [DF_StockReportCashFlow_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockReportCashFlow] ADD  CONSTRAINT [DF_StockReportCashFlow_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


