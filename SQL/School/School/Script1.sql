--CREATE DATABASE School

DROP TABLE Classes
DROP TABLE TimeTable
DROP TABLE PeopleInGroup
DROP TABLE StudentGroup
DROP TABLE Marks
DROP TABLE Qualification

DROP TABLE Subjects
DROP TABLE Tutors
DROP TABLE Students
DROP TABLE Cabs



CREATE TABLE Cabs
(
id_cab int not null primary key,
capacity int not null,
name nvarchar not null
);

CREATE TABLE Students
(
idStud int not null primary key,
FirstName nvarchar not null,
LastName nvarchar not null,
dateOfBirth date null,
);

CREATE TABLE StudentGroup
(
idGroup int not null primary key
);

CREATE TABLE Subjects
(
idSubj int not null primary key
);

CREATE TABLE Tutors
(
idTutor int not null primary key,
FirstName nvarchar not null,
LastName nvarchar not null,
dateOfBirth date null,
);

CREATE TABLE Qualification
(
idQual int not null primary key,
idTutor int not null,
idSubj int not null,
document int null,
constraint fk_idTutor foreign key (idTutor) references Tutors(idTutor),
constraint fk_idSubj foreign key (idSubj) references Subjects(idSubj)
);

CREATE TABLE PeopleInGroup
(
idPeopleInGroup int not null primary key,
idStud int not null,
idGroup int not null,
MemberFrom date not null,
MemberTo date null
constraint fk_idStud foreign key (idStud) references Students(idStud),
constraint fk_idGroup foreign key (idGroup) references StudentGroup(idGroup)
);

CREATE TABLE TimeTable
(
idClass int not null primary key,
TimeofBeg datetime not null,
idCab int not null,
idGroup int not null,
idTutor int not null,
idSubj int not null
constraint fk_idCab foreign key (idCab) references Cabs(id_cab),
--constraint fk_idGroup foreign key (idGroup) references StudentGroup(idGroup)
);

CREATE TABLE Classes
(
idClass int not null primary key,
timeOfBeg datetime not null,
topic nvarchar not null,
idTutor int not null
);

CREATE TABLE Marks
(
idMark int not null primary key,
idClass int not null,
idStud int not null,
mark nchar(1),
--constraint fk_idClass foreign key (idClass) references Classes(idClass)

);







