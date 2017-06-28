--INSERT INTO Accounts (AccountNumber , [Sum] , Currency) VALUES ( 123 , 50 , 1) , (124 , 100, 1) , (125, 300, 1) , (126 , 400 , 1) , (127 , 70 , 1)
--SELECT AccountNumber , [Sum] , Currency.Currency FROM Accounts LEFT JOIN Currency ON Accounts.Currency = Currency.Id
--INSERT INTO Currency (Id , Currency) VALUES ( 1, 'BYN')

INSERT INTO Transfers ([IdTransfer] ,[Obtained] , [Payer],[Beneficiar],[Amount] , [IdCurrency] ) VALUES (3 , GETDATE() , 4 , 1 , 33 , 1 )

--TRUNCATE TABLE Transfers
--SELECT * FROM Transfers
--SELECT * FROM Accounts