/****** Object:  Table [dbo].[StockReportMonthlyNetProfitTaxed]    Script Date: 2020/8/23 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockReportMonthlyNetProfitTaxed]
GO

/****** Object:  Table [dbo].[StockReportMonthlyNetProfitTaxed]    Script Date: 2020/8/23 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockReportMonthlyNetProfitTaxed](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Month] [smallint] NOT NULL,
    NetProfitTaxed MONEY NOT NULL,    -- ����
    LastYearNetProfitTaxed MONEY NOT NULL, -- �h�~�P��
    Delta MONEY NOT NULL, -- �W����B
    DeltaPercent DECIMAL(18, 4) NOT NULL, -- �W��ʤ���
    ThisYearTillThisMonth MONEY NOT NULL, -- ���~�֭p
    LastYearTillThisMonth MONEY NOT NULL, -- �h�~�֭p
    TillThisMonthDelta MONEY NOT NULL,    -- �W����B
    TillThisMonthDeltaPercent DECIMAL(18, 4) NOT NULL,    -- �W��ʤ���
    Remark NVARCHAR(1000) NOT NULL,   -- �Ƶ�/�禬�ܤƭ�]����
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockReportMonthlyNetProfitTaxed] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Month] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockReportMonthlyNetProfitTaxed] ADD  CONSTRAINT [DF_StockReportMonthlyNetProfitTaxed_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockReportMonthlyNetProfitTaxed] ADD  CONSTRAINT [DF_StockReportMonthlyNetProfitTaxed_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


