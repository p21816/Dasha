--SELECT People.Firstname, People.PersonalNumber*1 as zz from People
--union
--select 'TOTAL',SUM(People.PersonalNumber*1) from People order by zz

delete from Toothbrushes;
delete from Chopper;
insert into Toothbrushes (Name,Rigidity,Color) values 
	('ohoho','soft','Green'),
	('hoho','medium','Red'),
	('oho','hard','zyzzy');
insert into Chopper (Name,Displacement) values 
	('Minsk ohoho',1600),
	('Yamaha ',1343),
	('Kawasaki vulcan',1200)


	select 42,12
	union
	select '42',124;



select Name from Toothbrushes where Name LIKE '%ohoho%' 
union
select Name from Chopper where Name LIKE '%ohoho%'



