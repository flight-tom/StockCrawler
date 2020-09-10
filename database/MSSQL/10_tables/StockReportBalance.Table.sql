/****** Object:  Table [dbo].[StockReportBalance]    Script Date: 2020/8/22 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockReportBalance]
GO

/****** Object:  Table [dbo].[StockReportBalance]    Script Date: 2020/8/22 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- �l�q��
CREATE TABLE [dbo].[StockReportBalance](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	--�겣--
	[CashAndEquivalents][MONEY] NOT NULL, --�{���ά���{��
	[ShortInvestments] [MONEY] NOT NULL, -- �u�����
	[BillsReceivable] [MONEY] NOT NULL, -- �����b�ڤβ���
	[Stock] [MONEY] NOT NULL, -- �s�f
	[OtherCurrentAssets][MONEY] NOT NULL, -- ��l�y�ʸ겣
	[CurrentAssets][MONEY] NOT NULL,-- �y�ʸ겣
	[LongInvestment][MONEY] NOT NULL,-- �������
	[FixedAssets][MONEY] NOT NULL,-- �T�w�겣
	[OtherAssets][MONEY] NOT NULL, -- ��l�겣
	[TotalAssets][MONEY] NOT NULL, -- �`�겣
	-- �t��--
	[ShortLoan][MONEY] NOT NULL, -- �u���ɴ�
	[ShortBillsPayable][MONEY] NOT NULL, -- ���I�u������
	[AccountsAndBillsPayable][MONEY] NOT NULL, -- ���I�b�ڤβ���
	[AdvenceReceipt][MONEY] NOT NULL, -- �w���ڶ�
	[LongLiabilitiesWithinOneYear][MONEY] NOT NULL, -- �@�~����������t��
	[OtherCurrentLiabilities][MONEY] NOT NULL, -- ��l�y�ʭt��
	[CurrentLiabilities][MONEY] NOT NULL, -- �y�ʭt��
	[LongLiabilities][MONEY] NOT NULL, -- �����t��
	[OtherLiabilities][MONEY] NOT NULL, -- ��l�t��
	[TotalLiability][MONEY] NOT NULL, -- �`�t��
	[NetWorth][MONEY] NOT NULL, -- �b��
	[NAV][MONEY] NOT NULL, -- �C�Ѳb��

	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockReportBalance] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Season] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockReportBalance] ADD  CONSTRAINT [DF_StockReportBalance_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockReportBalance] ADD  CONSTRAINT [DF_StockReportBalance_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


