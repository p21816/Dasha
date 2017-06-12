CREATE TABLE [dbo].[Phones]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [people_id] INT NOT NULL, 
    [phone] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Phones_To_People] FOREIGN KEY (people_id) REFERENCES People([Id]) 
	ON DELETE CASCADE
)

GO

CREATE INDEX [IX_Phones_Column] ON [dbo].[Phones] (people_id)
--0	(1,'1242'),		0 1
--1	(1,'45-3'),		1 1
--2	(2,'2-232'),	3 1
--3	(1,'5446')		2 2
--4 (3,'3243')		5 2
--5 (2,'dsfds')		4 3
