CREATE TABLE [dbo].[Subsription]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Who] INT NOT NULL, 
    [ToWhom] INT NOT NULL, 
    CONSTRAINT [FK_Subsription_ToUserInfo] FOREIGN KEY (Who) REFERENCES UserInfo(Id), 
    CONSTRAINT [FK_Subsription_ToUserInfo1] FOREIGN KEY (ToWhom) REFERENCES UserInfo(Id)
)
