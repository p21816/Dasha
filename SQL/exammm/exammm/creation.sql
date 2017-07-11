CREATE TABLE [Tour]
(
    [Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
	[DepartureDate] DATETIME NOT NULL,
	[ReturnDate] DATETIME NOT NULL,
	[idCountry] INT NOT NULL,
	[Description] TEXT NOT NULL,
	[idGuide] INT NOT NULL,
	[Price] MONEY NOT NULL,
	[NumberOfPeople] INT NOT NULL,
	[Transport] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT [FK_Tour_To_Countries] FOREIGN KEY ([idCountry]) REFERENCES Countries([Id]),
	CONSTRAINT [FK_Tour_To_Guides] FOREIGN KEY ([idGuide]) REFERENCES Guides([Id]),
)

CREATE TABLE [Countries]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[CountryName] NVARCHAR(MAX),
)

CREATE TABLE [Guides]
(
    [Id] INT  NOT NULL PRIMARY KEY, 
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Phone] NVARCHAR(30)
)

INSERT INTO Countries VALUES (1 , 'Indonesia') , (2 , 'Ukraine') , (3, 'Denmark')
INSERT INTO Guides VALUES 
(1 , 'Petia' , 'Petrov' , '+375291234567' ),
(2 , 'Alex' , 'Dubov', '+375447654321'),
(3, 'Alla' , 'Bogodukhova', '+375253425167')
INSERT INTO Tour 