--INSERT INTO Currency (Id , Currency) VALUES ( 2, 'USD')
DELETE FROM Accounts
INSERT INTO Accounts (AccountNumber , AccountValue , Currency) 
VALUES ( 123 , 50 , 1) , (124 , 100, 2) , (125, 300, 1) , (126 , 400 , 2) , (127 , 70 , 1)
TRUNCATE TABLE Transfers

INSERT INTO Transfers ([Obtained] , [Payer],[Beneficiar],[Amount]) VALUES ( GETDATE() , 126 , 124 , 3060 );
SELECT * FROM Accounts

--SELECT AccountNumber , AccountValue , Currency.Currency FROM Accounts LEFT JOIN Currency ON Accounts.Currency = Currency.Id

CREATE TYPE Zip FROM SMALLINT NOT NULL
