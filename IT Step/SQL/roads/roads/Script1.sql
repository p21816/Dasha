--CREATE TABLE [dbo].[roads] (
--    [id1] INT NOT NULL,
--    [id2] INT NOT NULL,
--	[distance] INT NOT NULL
--);

--create view roads1 as 

CREATE TABLE oneWayRoads 
(
    [id1] INT NOT NULL,
    [id2] INT NOT NULL,
	[distance] INT NOT NULL
);


INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (1, 2, 32)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (2, 3, 46)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (1, 4, 24)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (4, 6, 7)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (2, 8, 8)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (8, 6, 5)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (6, 3, 50)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (4, 5, 32)
INSERT INTO [dbo].oneWayRoads ([id1], [id2], [distance]) VALUES (6, 7, 20)




INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (1, 2, 32)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (2, 3, 46)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (1, 4, 24)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (4, 6, 7)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (2, 8, 8)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (8, 6, 5)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (6, 3, 50)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (4, 5, 32)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (6, 7, 20)

INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (2, 1, 32)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (3, 2, 46)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (4, 1, 24)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (6, 4, 7)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (8, 2, 8)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (6, 8, 5)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (3, 6, 50)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (5, 4, 32)
INSERT INTO [dbo].roads ([id1], [id2], [distance]) VALUES (7, 6, 20)