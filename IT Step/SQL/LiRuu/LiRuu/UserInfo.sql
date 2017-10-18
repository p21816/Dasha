CREATE TABLE [dbo].[UserInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Login] NVARCHAR(50) NOT NULL, 
    [CodedPassword] NVARCHAR(MAX) NOT NULL
)
