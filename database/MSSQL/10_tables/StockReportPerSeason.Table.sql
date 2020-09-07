/****** Object:  Table [dbo].[StockReportPerSeason]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
DROP TABLE IF EXISTS [dbo].[StockReportPerSeason]
GO

/****** Object:  Table [dbo].[StockReportPerSeason]    Script Date: 2020/8/9 �W�� 08:30:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- �l�q��
CREATE TABLE [dbo].[StockReportPerSeason](
	[StockNo] [varchar](10) NOT NULL,
	[Year] [smallint] NOT NULL,
	[Season] [smallint] NOT NULL,
	[EPS] [MONEY] NOT NULL, -- �C�Ѭվl�G�����G��uEPS = ��u�|��b�Q / �w�o��Ѽ�
	[NetValue] [MONEY] NOT NULL, -- �C�Ѳb�ȡG�����G�C�Ѳb�� = �b��(�ѪF�v�q) / �b�~�y�q�Ѽ�
	[CreatedAt] [datetime] NOT NULL,
	[LastModifiedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_StockReportPerSeason] PRIMARY KEY CLUSTERED 
(
	[StockNo] ASC,
	[Year] DESC,
	[Season] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockReportPerSeason] ADD  CONSTRAINT [DF_StockReportPerSeason_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[StockReportPerSeason] ADD  CONSTRAINT [DF_StockReportPerSeason_LastModifiedAt]  DEFAULT (getdate()) FOR [LastModifiedAt]
GO


