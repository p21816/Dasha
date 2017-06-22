use ExtremeUniversity; 


IF OBJECT_ID('dbo.GroupContent', 'U') IS NOT NULL 
  DROP TABLE dbo.GroupContent; 
  IF OBJECT_ID('dbo.Lessons', 'U') IS NOT NULL 
  DROP TABLE dbo.Lessons; 
IF OBJECT_ID('dbo.TutorsQualification', 'U') IS NOT NULL 
  DROP TABLE dbo.TutorsQualification; 
  IF OBJECT_ID('dbo.Tutors', 'U') IS NOT NULL 
  DROP TABLE dbo.Tutors; 

IF OBJECT_ID('dbo.Schedule', 'U') IS NOT NULL 
  DROP TABLE dbo.Schedule; 
IF OBJECT_ID('dbo.Marks', 'U') IS NOT NULL 
  DROP TABLE dbo.Marks; 
IF OBJECT_ID('dbo.Rooms', 'U') IS NOT NULL 
  DROP TABLE dbo.Rooms; 
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL 
  DROP TABLE dbo.Students; 
IF OBJECT_ID('dbo.Groups', 'U') IS NOT NULL 
  DROP TABLE dbo.Groups; 
IF OBJECT_ID('dbo.Subjects', 'U') IS NOT NULL 
  DROP TABLE dbo.Subjects; 

IF OBJECT_ID('dbo.NewMarks', 'U') IS NOT NULL 
  DROP TABLE dbo.NewMarks; 


create table Rooms (
	id_cab	int not null primary key,
	capacity int not null,
	name    varchar(50) not null);

create table Students (
id_Stud int not null primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null);

create table Groups (
id_gr int not null primary key,
NumberGroup int not null);

create table Subjects(
id_subj int not null primary key,
NameSubject varchar(30) not null);

create table Tutors(
id_Tut int not null primary key,
FirstName varchar(30) not null,
LastName varchar(30) not null);

create table NewMarks(
id_newmarks int not null primary key,
MarksRange int not null);

create table GroupContent(
id_gd int not null primary key,
id_Student int not null,
id_Groups int not null,
fromdate date null,
todate date null,
constraint fk_forstudents foreign key (id_Student) references Students(id_Stud),
constraint fk_forgroups foreign key (id_Groups) references Groups(id_gr) );


create table TutorsQualification(
id_qualif int not null primary key,
id_Tutors int not null,
id_Subjects int not null,
document int not null,
constraint fk_fortutors foreign key (id_Tutors) references Tutors(id_Tut),
constraint fk_forsubjects foreign key (id_Subjects) references Subjects(id_subj)
);
create table Schedule(
id_shed int not null primary key,
startt datetime not null,
id_Rooms int not null, 
id_Groups int not null,
id_Tutors int not null,
id_Subjects int not null,
constraint fk_forroomsshedule foreign key (id_Rooms) references Rooms(id_cab),
constraint fk_forgroupsshedule foreign key (id_Groups) references Groups(id_gr),
constraint fk_fortutorsshedule foreign key (id_Tutors) references Tutors(id_Tut),
constraint fk_forsubjectsshedule foreign key (id_Subjects) references Subjects(id_subj),
);

create table Lessons(
id_Less int not null primary key,
idLessonName int not null,
StartLesson datetime not null,
Topic nvarchar(50) not null,
id_Tutors int not null,
constraint fk_forschedule foreign key (idLessonName) references Subjects(id_subj),
constraint fk_fortutorsforlessons foreign key (id_Tutors) references Tutors(id_Tut));


create table Marks(
id_marks int not null primary key,
id_Groups int not null,
id_Students int not null,
id_Lesson int not null,
Mark nchar(1) null,
constraint fk_forlesson foreign key (id_Lesson) references Lessons(id_Less),
constraint fk_forgroupsmarks foreign key (id_Groups) references Groups(id_gr),
constraint fk_forstudentsmarks foreign key (id_Students) references Students(id_Stud));

ALTER TABLE Marks DROP COLUMN Mark;     --удаление колонки Оценки из таблицы оценок
ALTER TABLE Marks ADD id_AddedNewMarks int;  --Добавление новой колонки оценки

ALTER TABLE Marks ADD CONSTRAINT FK_MarksRangeID  --Создание ограничения для колонки Оценки через внешний ключ 
FOREIGN KEY(id_AddedNewMarks) REFERENCES NewMarks(id_newmarks);