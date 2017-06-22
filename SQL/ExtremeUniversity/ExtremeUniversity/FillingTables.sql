use ExtremeUniversity;

delete from GroupContent;
delete from TutorsQualification;
delete from Lessons;
delete from Schedule;
delete from Marks;
delete from Rooms;
delete from Students;
delete from Groups;
delete from Subjects;
delete from Tutors;
delete from NewMarks;

insert into Rooms (id_cab, capacity, name) values
(1, 20, 'AC-22585'),
(2, 18, 'AD-33399'),
(3, 15, 'AA-98765');

insert into Students (id_Stud, FirstName, LastName) values
(1, 'Andrew', 'Klain'),
(2, 'Simon', 'Zweig'),
(3, 'Peter', 'Gabriel');

insert into Groups (id_gr, NumberGroup) values
(1, 525),
(2, 448),
(3, 1777);

insert into Subjects(id_subj, NameSubject) values
(1, 'Extreme climbing'),
(2, 'Survival in the desert'),
(3, 'Deep dive');

insert into Tutors (id_Tut, FirstName, LastName) values
(1, 'Max', 'Planck'),
(2, 'Redley', 'Scott'),
(3, 'Barbara', 'Suzerlend');

insert into NewMarks(id_newmarks, MarksRange) values
(1, 9),
(2, 8),
(3, 7),
(4, 6),
(5, 5);

insert into GroupContent(id_gd, id_Student, id_Groups, fromdate, todate) values
(1, 2, 1, '2017.05.15', '2017.06.08'),
(2, 3, 2, null, null),
(3, 1, 3, '2017.02.23', '2017.06.07');

insert into TutorsQualification (id_qualif, id_Tutors, id_Subjects, document) values
(1, 2, 1, 2356),
(2, 1, 3, 2288),
(3, 3, 2, 9933);

insert into Lessons (id_Less, idLessonName, StartLesson, Topic, id_Tutors) values
(1,1, '2017.04.12 09:00', 'Introduction', 2),
(2,2, '2017.04.12 12:30', 'Different trubbles', 1),
(3,1, '2017.04.13 10:00', 'The main aspects of survival', 3);

insert into Schedule (id_shed, startt, id_Rooms, id_Groups, id_Tutors, id_Subjects) values
(1, '2017.04.12 09:00', 1, 3, 2, 3),
(2, '2017.04.13 10:00', 2, 1, 1, 1),
(3, '2017.04.12 12:30', 3, 2, 3, 2);

insert into Marks (id_Marks, id_Groups, id_Students,id_Lesson, id_AddedNewMarks) values
(1, 2, 1, 1, 5);

----select * from Marks;

select StartLesson, Topic, Tutors.FirstName as FirstName, Tutors.LastName as LastName from Lessons
	inner join Tutors on Lessons.id_Tutors = Tutors.id_Tut;



select * from Schedule
	inner join Rooms on Schedule.id_Rooms = Rooms.id_cab
	inner join Groups on Schedule.id_Groups = Groups.id_gr
	inner join Tutors on Schedule.id_Tutors = Tutors.id_Tut
	inner join Subjects on Schedule.id_Subjects = Subjects.id_subj;
