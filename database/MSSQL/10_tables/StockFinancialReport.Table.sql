/****** Object:  Table [dbo].[StockFinancialReport]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockFinancialReport]
GO

/****** Object:  Table [dbo].[StockFinancialReport]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- ²���]�ȳ���
CREATE TABLE [dbo].[StockFinancialReport](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	[TotalAssets][MONEY] NOT NULL, --�겣�`�p
	[TotalLiability] [MONEY] NOT NULL, -- �t��
	[NetWorth] [MONEY] NOT NULL, -- �v�q�`�p
	[NAV] [MONEY] NOT NULL, -- �C�Ѳb��
	[Revenue] [MONEY] NOT NULL, -- ��~���J
	[BusinessInterest] [MONEY] NOT NULL,-- ��~�Q�q
	[NetProfitTaxFree] [MONEY] NOT NULL,-- �|�e�b�Q
	[EPS][MONEY] NOT NULL, -- �C�Ѭվl
	[BusinessCashflow] [MONEY] NOT NULL,-- ��~���ʤ��b�{���y�J
	[InvestmentCashflow] [MONEY] NOT NULL,-- ��ꬡ�ʤ��b�{���y�J
	[FinancingCashflow] [MONEY] NOT NULL,-- �w�ꬡ�ʤ��b�{���y�J
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockFinancialReport] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Season] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockFinancialReport] ADD  CONSTRAINT [DF_StockFinancialReport_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockFinancialReport] ADD  CONSTRAINT [DF_StockFinancialReport_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


