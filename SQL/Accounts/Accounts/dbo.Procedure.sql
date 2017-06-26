CREATE PROCEDURE [dbo].[Procedure]
    @src int,
    @dst int,
    @sum int
AS
    BEGIN
        --DECLARE @X FLOAT = 4;
        --SET @X = 1;
		--DECLARE @X FLOAT;
		--SELECT @X = [MONEY] FROM [Accounts] WHERE [NUMBER] = 1;
        IF (SELECT [MONEY] FROM [Accounts] WHERE [NUMBER]=@src)<@sum
            BEGIN  
                RETURN;
            END;
        UPDATE Accounts SET [MONEY]=[MONEY]-@sum WHERE [NUMBER]=@src;
        UPDATE Accounts SET [MONEY]=[MONEY]+@sum WHERE [NUMBER]=@dst;
    END
    GO