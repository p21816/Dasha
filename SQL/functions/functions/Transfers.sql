CREATE TABLE [dbo].[Transfers]
(
	[IdTransfer] INT NOT NULL PRIMARY KEY,
	[Obtained] DATETIME ,
	[Completed] DATETIME ,
	[Payer] INT NOT NULL,
	[Beneficiar] INT NOT NULL,
	[Amount] INT NOT NULL,
	[IdCurrency] INT NOT NULL,
	[Comment] NVARCHAR(15), 
    CONSTRAINT [FK_Transfers_ToCurrency] FOREIGN KEY ([IdCurrency]) REFERENCES [Currency]([Id])
)
