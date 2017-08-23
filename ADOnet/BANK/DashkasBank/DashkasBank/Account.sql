CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [AccountNumber] INT NOT NULL, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Amount] INT NOT NULL
)
