--INSERT INTO Currency (Id , Currency) VALUES ( 1, 'BYN')
--DELETE FROM Accounts
--INSERT INTO Accounts (AccountNumber , AccountValue , Currency) VALUES ( 123 , 50 , 1) , (124 , 100, 1) , (125, 300, 1) , (126 , 400 , 1) , (127 , 70 , 1)
--TRUNCATE TABLE Transfers

INSERT INTO Transfers ([Obtained] , [Payer],[Beneficiar],[Amount] , [IdCurrency] ) VALUES ( GETDATE() , 126 , 123 , 3 , 1 );


--SELECT AccountNumber , [Sum] , Currency.Currency FROM Accounts LEFT JOIN Currency ON Accounts.Currency = Currency.Id


--SELECT * FROM Transfers