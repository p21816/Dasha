CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Firstname] NVARCHAR(MAX) NOT NULL, 
    [Lastname] NVARCHAR(MAX) NOT NULL, 
    [DateOfBirth] DATE NULL, 
    [PersonalNumber] CHAR(16) NULL
)

GO

CREATE UNIQUE INDEX [IX_People_Number] ON [dbo].[People] ([PersonalNumber])

GO
CREATE INDEX [FullName] ON [dbo].[People] ([Firstname] , [Lastname])
