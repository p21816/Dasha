GO
-- vdcvfcvcv

CREATE TABLE [People]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [Firstname] NVARCHAR(MAX) NOT NULL, 
    [Lastname] NVARCHAR(MAX) NOT NULL, 
    [Birthdate] DATE NULL, 
    [PersonalNumber] CHAR(16) NULL,
	[MoodId] INT NULL, 
    CONSTRAINT 
		[FK_People_ToMoods] 
		FOREIGN KEY (MoodId)
		REFERENCES Moods(Id)
)

GO

CREATE UNIQUE INDEX [IX_People_Number] ON [People] ([PersonalNumber])

go
