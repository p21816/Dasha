CREATE TABLE [dbo].[Catalogue]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY, 
    [bookId] INT NOT NULL, 
    [subscriberId] INT NOT NULL, 
    [dateOut] DATE NOT NULL, 
    [dateIn] DATE NULL, 
    CONSTRAINT [FK_Catalogue_ToBook] FOREIGN KEY (bookId) REFERENCES book(Id), 
    CONSTRAINT [FK_Catalogue_ToSubsriber] FOREIGN KEY (subscriberId) REFERENCES Subsriber(Id)
	ON DELETE NO ACTION

)
