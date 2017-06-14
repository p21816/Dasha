DELETE FROM Comments
DELETE FROM Subsription
DELETE FROM Entries
DELETE FROM UserInfo

INSERT INTO UserInfo( Id, Login, CodedPassword) VALUES (1, 'solnishlo' , '1234567')
INSERT INTO UserInfo( Id, Login, CodedPassword) VALUES (2, 'dojdik' , '7654321')
INSERT INTO UserInfo( Id, Login, CodedPassword) VALUES (3, 'sneggg' , '3333333')
INSERT INTO UserInfo( Id, Login, CodedPassword) VALUES (4, 'tuchka' , '4444444')
INSERT INTO UserInfo( Id, Login, CodedPassword) VALUES (5, 'oblako' , '5555555')

INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (111, 5, 2)
INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (112, 3, 2)
INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (113, 4, 2)

INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (115, 2, 1)

INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (116, 1, 5)
INSERT INTO Subsription ( Id , Who, ToWhom) VALUES (117, 3, 5)


INSERT INTO Entries ( Id, EntryText , EntryTime , UserId) VALUES (123 , 'Hello, World!' , '2017-06-12T11:05:11' , 1)
INSERT INTO Entries ( Id, EntryText , EntryTime , UserId) VALUES (124 , 'How are you, World?' , '2017-06-13T12:05:11' , 1)
INSERT INTO Entries ( Id, EntryText , EntryTime , UserId) VALUES (125 , 'Bye-bye, World!' , '2017-06-11T14:05:11' , 1)

INSERT INTO Comments (Id, UserId, EntryId, CommentText, CommentTime) VALUES (444, 2, 123, 'Hi!' , '2017-06-14T14:05:11')

--SELECT TOP 3 EntryText FROM Entries ORDER BY EntryTime

SELECT UserInfo.Login , popularity FROM (SELECT TOP 2 COUNT(*) as [popularity], ToWhom FROM Subsription GROUP BY ToWhom ORDER BY popularity DESC) as tbl INNER JOIN UserInfo On tbl.ToWhom  = UserInfo.Id

--SELECT DISTINCT ToWhom FROM Subsription ORDER BY ToWhom DESC

--SELECT COUNT(DISTINCT ToWhom) as[count] FROM Subsription





--SELECT * FROM UserInfo LEFT JOIN Subsription ON Who = UserInfo.Id
