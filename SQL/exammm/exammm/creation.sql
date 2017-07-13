
CREATE TABLE [Countries]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[CountryName] NVARCHAR(MAX),
)

CREATE TABLE [Hotels]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[HotelName] NVARCHAR(MAX),
	[idCountry] INT NOT NULL,
)

CREATE TABLE [Hotels]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[HotelName] NVARCHAR(MAX),
	[idCountry] INT NOT NULL,
)

CREATE TABLE [ReserveHotels]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[HotelName] NVARCHAR(MAX),
	[idCountry] INT NOT NULL,
)

CREATE TABLE [Guides]
(
    [Id] INT  NOT NULL PRIMARY KEY, 
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Phone] NVARCHAR(30)
)



CREATE TABLE [Tour]
(
    [Id] INT NOT NULL PRIMARY KEY, 
	[DepartureDate] DATE NOT NULL,
	[ReturnDate] DATE NOT NULL,
	[idCountry] INT NOT NULL CHECK (idCountry in(1, 2, 3)),
	[Description] TEXT NOT NULL,
	[idGuide] INT NOT NULL,
	[Price] MONEY NOT NULL,
	[NumberOfPeople] INT NOT NULL,
	[Transport] NVARCHAR(MAX) NOT NULL CHECK (Transport in('Avia', 'Bus', 'Train' )),
	[idHotel] INT NOT NULL,
	CONSTRAINT [FK_Tour_To_Countries] FOREIGN KEY ([idCountry]) REFERENCES Countries([Id]),
	CONSTRAINT [FK_Tour_To_Guides] FOREIGN KEY ([idGuide]) REFERENCES Guides([Id]),
	CONSTRAINT [FK_Tour_To_Hotels] FOREIGN KEY ([idHotel]) REFERENCES Hotels([Id]),
)

INSERT INTO Countries VALUES (1 , 'Indonesia') , (2 , 'Ukraine') , (3, 'Denmark')

INSERT INTO Guides VALUES 
(1 , 'Petia' , 'Petrov' , '+375291234567' ),
(2 , 'Alex' , 'Dubov', '+375447654321'),
(3, 'Alla' , 'Bogodukhova', '+375253425167')

INSERT INTO Hotels VALUES 
(1, 'Canguu Dream' , 1),
(2, 'Pripiat', 2),
(3 , 'Bella Sky Copenhagen',3),
(4 , 'M.A. Homestay', 1),
(5, 'Polesie', 2),
(6, 'Seagull',3),
(7, 'Nice Inn', 1)


INSERT INTO Tour VALUES
(1 , '2017-08-01', '2017-08-15', 1 , 'two-week tour to Bali', 1, 150.000, 60 , 'Avia', 1),
(2, '2017-08-15' ,'2017-08-18', 2, 'two-day tour to Pripiat', 2, 10.000 , 40 , 'Bus', 2),
(3, '2017-09-03', '2017-09-11', 3,'a week tour to Copenhagen', 3, 75.000 , 50 , 'Avia' , 3)

CREATE INDEX guideIndex ON Tour(idGuide)

select * from tour  LEFT JOIN Hotels ON Hotels.Id = Tour.idHotel

select * from Hotels
select [Description] , HotelName  from tour LEFT JOIN Hotels ON idHotel = Hotels.Id

delete from Hotels where Hotels.Id = 1


