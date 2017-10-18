﻿CREATE TABLE [dbo].[Transfers]
(
	[IdTransfer] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Obtained] DATETIME ,
	[Completed] DATETIME ,
	[Payer] INT NOT NULL,
	[Beneficiar] INT NOT NULL,
	[Amount] INT NOT NULL,
	[IdCurrency] INT NULL,
	[Comment] NVARCHAR(50), 
    [Code] NCHAR(10) NULL, 
    CONSTRAINT [FK_Transfers_ToCurrency] FOREIGN KEY ([IdCurrency]) REFERENCES [Currency]([Id])
)
