--ALTER VIEW Register AS
--(
--	LEFT JOIN Marks ON Marks.id_Students = Students.id_Stud
--	--FULL JOIN Lessons ON Marks.id_marks = Lessons.id_Less
--	--FULL JOIN Subjects ON Lessons.id_Less = Subjects.id_subj
--	--FULL JOIN NewMarks ON Marks.id_marks = NewMarks.id_newmarks
--)

	SELECT * FROM Students LEFT JOIN Marks ON Marks.id_Students = Students.id_Stud

