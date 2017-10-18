CREATE TABLE [dbo].[Phones]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [people_id] INT NOT NULL, 
    [phone] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Phones_To_People] FOREIGN KEY ([people_id]) REFERENCES [People]([Id]) -- ограничение (CONSTRAIT): в колонку можно вписать только такие адишники, которые есть в People.Id
	ON DELETE NO ACTION
)

GO

CREATE INDEX [IX_Phones_Column] ON [dbo].[Phones] ([people_id])
