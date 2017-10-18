USE [Accounts]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Procedure]
		@src = 1,
		@dst = 6,
		@sum = 160

SELECT	@return_value as 'Return Value'

GO
