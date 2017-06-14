CREATE TABLE [dbo].[Entries]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EntryText] NVARCHAR(MAX) NOT NULL, 
    [EntryTime] DATETIME NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Entries_ToUserInfo] FOREIGN KEY (UserId) REFERENCES UserInfo(Id)
)
