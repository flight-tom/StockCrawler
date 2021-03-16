/****** Object:  Table [dbo].[StockInterestIssuedInfo]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockInterestIssuedInfo]
GO

/****** Object:  Table [dbo].[StockInterestIssuedInfo]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- ²���]�ȳ���
CREATE TABLE [dbo].[StockInterestIssuedInfo](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	[DecisionDate][DATE] NOT NULL, --���Ʒ|�Mĳ�]��ĳ�^���
	[ProfitCashIssued] [MONEY] NOT NULL, -- �վl���t���{���ѧQ
	[ProfitStockIssued] [MONEY] NOT NULL, -- �վl���t���Ѳ��ѧQ
	[SsrCashIssued] [MONEY] NOT NULL, -- �k�w�վl���n�o�񤧲{��(��/��)
	[SsrStockIssued] [MONEY] NOT NULL, -- �k�w�վl���n��W��t��(��/��)
	[CapitalReserveCashIssued] [MONEY] NOT NULL,-- �ꥻ���n�o�񤧲{��(��/��)
	[CapitalReserveStockIssued] [MONEY] NOT NULL,-- �ꥻ���n��W��t��(��/��)
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockInterestIssuedInfo] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Season] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockInterestIssuedInfo] ADD  CONSTRAINT [DF_StockInterestIssuedInfo_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockInterestIssuedInfo] ADD  CONSTRAINT [DF_StockInterestIssuedInfo_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


