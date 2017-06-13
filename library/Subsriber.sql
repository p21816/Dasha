CREATE TABLE [dbo].[Subsriber]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [DateOfBirth] DATE NULL, 
    [Phone] NVARCHAR(50) NOT NULL, 
    [SubsriberAddress] NVARCHAR(MAX) NULL
)
