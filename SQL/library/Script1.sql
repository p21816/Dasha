DELETE FROM Catalogue
DELETE FROM book
DELETE FROM Author
DELETE FROM Subsriber
DELETE FROM Wear

INSERT INTO Author (Id, FirstName, LastName) VALUES ( 1, 'William' , 'Shakespeare')
INSERT INTO book (Id, Title, AuthorID, PublisherID, YearOfPublishing, GenreID) VALUES (123, 'Macbeth' , 1, 2, 2015, 1)
INSERT INTO Subsriber (Id, FirstName, LastName, DateOfBirth, Phone, SubsriberAddress) VALUES (1, 'Kwaigon' , 'Jinn', '2.03.4990', +375291234567, 'Minsk, Tolstogo, 8')
INSERT INTO Catalogue (bookId , subscriberId , dateOut) VALUES (123, 1, '12.06.2017')
INSERT INTO Wear (Id, Condition) VALUES ( 1, 'New') , (2, 'Good') , (3, 'Old')

SELECT * FROM Catalogue

--SELECT Title, LastName as [Author] FROM book LEFT JOIN Author ON book.AuthorID = Author.Id


 --LEFT JOIN Author ON book.AuthorID = Author.Id


