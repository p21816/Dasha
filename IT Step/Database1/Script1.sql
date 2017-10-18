delete from Phones
delete from People
delete from Moods
Insert into Moods (Id,MoodDescription) values 
	(1,'Good'),
	(2,'Evil'),
	(3,'Orange');
SET IDENTITY_INSERT People ON;
INSERT INTO People (Id,Lastname,Firstname,Birthdate,PersonalNumber,MoodId) VALUES 
	(1,'Ava','Lala',NULL,'11',1),
	(2,'Orava','Lol',null,'12',1),
	(3,'Lama','Col',null,'13',2),
	(4,'Rama','Bash',null,'14',2),
	(5,'Krshna','Wnshu',null,'15',1),
	(6,'Patrol','Rinpoche',null,'16',3),
	(7,'Ava','Krala',NULL,'17',1),
	(8,'Ava','Mlavaja',NULL,'18',2);
SET IDENTITY_INSERT People OFF;
go
insert into Phones ([people_id],[phone]) values 
	(1,'1242'),
	(1,'45-3'),
	(2,'2-232'),
	(1,'5446')
go
	select count(People.Id) 
	from People 
	left join Phones on People.Id = Phones.people_id 
	where Phones.Id is null
	

	