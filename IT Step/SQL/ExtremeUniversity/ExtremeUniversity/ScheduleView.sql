ALTER VIEW Thursday AS
(
	SELECT NumberGroup,  FORMAT(startt , 't', 'ru-Ru' ) + ' ' + NameSubject + ' ' + name 
	AS Thursday FROM Schedule Sh 
	INNER JOIN Groups ON Sh.id_Groups = Groups.id_gr 
	INNER JOIN Subjects ON Sh.id_Subjects = Subjects.id_subj 
	INNER JOIN Rooms ON Sh.id_Rooms = Rooms.id_cab 
	WHERE DATEPART(dw, startt ) = 4 
)

go 

ALTER VIEW Friday AS
(
	SELECT NumberGroup,  FORMAT(startt , 't', 'ru-Ru' ) + ' ' + NameSubject + ' ' + name 
	AS Friday FROM Schedule Sh 
	INNER JOIN Groups ON Sh.id_Groups = Groups.id_gr 
	INNER JOIN Subjects ON Sh.id_Subjects = Subjects.id_subj 
	INNER JOIN Rooms ON Sh.id_Rooms = Rooms.id_cab 
	WHERE DATEPART(dw, startt ) = 5
)

go

SELECT *  FROM Thursday FULL JOIN Friday ON Thursday.NumberGroup = Friday.NumberGroup

