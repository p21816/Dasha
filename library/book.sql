CREATE TABLE [dbo].[book]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [AuthorID] INT NOT NULL, 
    [PublisherID] INT NOT NULL, 
    [YearOfPublishing] NVARCHAR(MAX) NOT NULL, 
    [GenreID] INT NOT NULL, 
    CONSTRAINT [FK_book_ToAuthor] FOREIGN KEY (AuthorID) REFERENCES Author(Id)
	ON DELETE NO ACTION
)
