GO
CREATE TABLE [People]
(
    [Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [Firstname] NVARCHAR(MAX) NOT NULL, 
    [Lastname] NVARCHAR(MAX) NOT NULL, 
    [Birthdate] DATE NULL, 
    [PersonalNumber] CHAR(16) NULL,
	[MoodId] INT NULL
)

GO

CREATE TABLE [dbo].[Phones]
(
    [Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [people_id] INT NOT NULL, 
    [phone] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Phones_To_People] FOREIGN KEY (people_id) REFERENCES People([Id]) 
    ON DELETE CASCADE
)


SET IDENTITY_INSERT [dbo].[People] ON
INSERT INTO [dbo].[People] ([Id], [Firstname], [Lastname], [Birthdate], [PersonalNumber], [MoodId])
 VALUES
  (1, N'Lala', N'Ava', NULL, N'11              ', 1)
, (2, N'Lol', N'Orava', NULL, N'12              ', 1)
, (3, N'Col', N'Lama', NULL, N'13              ', 2)
, (4, N'Basha', N'Rama', NULL, N'14              ', 2)
, (5, N'Wnshu', N'Krshna', NULL, N'15              ', 1)
, (6, N'Rinpoche', N'Patrol', NULL, N'16              ', 3)
, (7, N'Krala', N'Ava', NULL, N'17              ', 1)
, (8, N'Mlavaja', N'Ava', NULL, N'18              ', 2)
SET IDENTITY_INSERT [dbo].[People] OFF

SET IDENTITY_INSERT [dbo].[Phones] ON
INSERT INTO [dbo].[Phones] ([Id], [people_id], [phone])
 VALUES 
 (2078, 1, N'1242')
, (2079, 1, N'45-3f')
, (2080, 2, N'2-232')
, (2081, 1, N'5446')
, (2082 , 2 , '12345')
, (2083 , 3 , '7645342312')
, (2084, 4, '4565453')
, (2085 , 6, '235')
, (2086, 6, ' 56445342')
SET IDENTITY_INSERT [dbo].[Phones] OFF


GO

SELECT People.Id, Firstname, Lastname , MAX(phone) from dbo.People LEFT JOIN dbo.Phones ON People.Id = Phones.people_id GROUP BY people.Id, Firstname, Lastname