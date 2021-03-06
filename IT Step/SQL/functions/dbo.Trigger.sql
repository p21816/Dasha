﻿CREATE TRIGGER [DoTransfer]
    ON [dbo].[Transfers]
    AFTER INSERT
    AS
    BEGIN
        IF (SELECT COUNT(*) FROM inserted)!=1
        BEGIN
            SELECT 'ONLY 1 TRANSFER ALLOWED AT ONCE';  --позволяет добавлять по 1 записи в Transfers
            RETURN
        END 
        
        DECLARE @sum INT;
        DECLARE @src INT;
        DECLARE @dst INT;
        DECLARE @tid INT;
		DECLARE @Cur INT;
        SELECT @sum=Amount, @src=Payer, @dst=Beneficiar, @tid = IdTransfer , @Cur = IdCurrency
        from inserted;


        IF (select Accounts.AccountValue from Accounts where AccountNumber = @src) < @sum 
        BEGIN 
		UPDATE Transfers SET [Comment]='NOT ENOUGH MONEY FOR PAYMENT'
        where [IdTransfer] = @tid;
        RETURN
        END

		IF(SELECT COUNT(Accounts.AccountNumber) FROM Accounts WHERE AccountNumber = @src) != 1
		BEGIN 
		UPDATE Transfers SET [Comment]='INVALID ACCOUNT NUMBER' WHERE [IdTransfer] = @tid;
        RETURN
        END

		IF(SELECT Transfers.IdCurrency FROM Transfers) 


        UPDATE Accounts SET [AccountValue]=[AccountValue]+@sum
        where [AccountNumber] = @dst;
        UPDATE Accounts SET [AccountValue]=[AccountValue]-@sum
        where [AccountNumber] = @src;
        UPDATE Transfers set Completed = GETDATE()
        where [IdTransfer] = @tid
		UPDATE Transfers SET [Comment]='SUCCESSFUL PAYMENT'
        where [IdTransfer] = @tid;
        SET NOCOUNT ON
    END