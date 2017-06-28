CREATE TABLE [dbo].[Accounts]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[AccountNumber] INT NOT NULL,
	[Sum] MONEY NOT NULL,
	[Currency] INT NOT NULL, 
    CONSTRAINT [FK_Accounts_ToCurrency] FOREIGN KEY ([Currency]) REFERENCES [Currency]([Id])
)
