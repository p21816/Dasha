CREATE TABLE [dbo].[Author]
(
	[Id] INT  NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [DateOfBirth] DATE NULL, 
    [DateOfDeath] DATE NULL
)
