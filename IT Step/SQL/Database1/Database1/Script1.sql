INSERT INTO 
	 People(Id, Firstname, Lastname, DateOfBirth, PersonalNumber)
VALUES 
	( 1, 'Ava' , 'Lala' , NULL , '11'),
	( 2, 'Idael' , 'Gerrero' , NULL , '12')



INSERT INTO Phones(Id, people_id, phone) VALUES (1, '1' ,'12344')

--SELECT * FROM Phones


--SELECT count(DISTINCT People.Id) FROM People INNER JOIN Phones ON People.Id = Phones.people_id --выберает и считает только тех людей, у которых есть телефоны

SELECT COUNT(People.Id) AS [Numder of people without phones] FROM People LEFT JOIN Phones ON People.Id = Phones.people_id  where Phones.Id is null 


--GO

--SELECT TOP 3* FROM People

--GO