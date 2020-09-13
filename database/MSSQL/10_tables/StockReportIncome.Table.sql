/****** Object:  Table [dbo].[StockReportIncome]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockReportIncome]
GO

/****** Object:  Table [dbo].[StockReportIncome]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- �X�ֺ�X�l�q��
CREATE TABLE [dbo].[StockReportIncome](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	[Revenue][MONEY] NOT NULL, --�禬
	[GrossProfit] [MONEY] NOT NULL, -- ��Q
	[SalesExpense] [MONEY] NOT NULL, -- �P��O��
	[ManagementCost] [MONEY] NOT NULL, -- �޲z�O��
	[RDExpense][MONEY] NOT NULL, -- ��o�O��
	[OperatingExpenses][MONEY] NOT NULL,-- ��~�O��
	[BusinessInterest][MONEY] NOT NULL,-- ��~�Q�q
	[NetProfitTaxFree][MONEY] NOT NULL,-- �|�e�b�Q
	[NetProfitTaxed][MONEY] NOT NULL, -- �|��b�Q
	[EPS][MONEY] NOT NULL, -- �C�Ѭվl
	[SEPS][MONEY] NOT NULL, -- ���u�C�Ѭվl
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockReportIncome] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Season] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockReportIncome] ADD  CONSTRAINT [DF_StockReportIncome_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockReportIncome] ADD  CONSTRAINT [DF_StockReportIncome_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


