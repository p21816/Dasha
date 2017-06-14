CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL, 
    [EntryId] INT NOT NULL, 
    [CommentText] NVARCHAR(MAX) NOT NULL, 
    [CommentTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_Comments_ToUserInfo] FOREIGN KEY (UserId) REFERENCES UserInfo(Id), 
    CONSTRAINT [FK_Comments_ToEntries] FOREIGN KEY ([EntryId]) REFERENCES Entries(Id)
)
