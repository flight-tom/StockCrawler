/****** Object:  StoredProcedure [dbo].[GetStocks] Script Date: 07/15/2013 20:52:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Tom Tang
-- Create date: 2017-07-04
-- Description: Get all stocks
-- Revision:
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[GetStocks]
@pStockNo VARCHAR(20) = NULL
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @TRUE BIT = 1
	SELECT * 
	FROM [Stock](NOLOCK)
    WHERE 
		(@pStockNo IS NULL OR @pStockNo = '' OR [StockNo] = @pStockNo)
		AND [Enable] = @TRUE
END
GO
