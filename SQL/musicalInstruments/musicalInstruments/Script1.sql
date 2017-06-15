DELETE FROM Requirements
DELETE FROM insrtuments
DELETE FROM Frequency
DELETE FROM InstrumentNames
DELETE FROM Classification

INSERT INTO InstrumentNames(Id, InstrumentName) VALUES ( 1, 'Contrabass') , (2, 'Tuba') , (3, 'Cello'), (4, 'Guitar'), (5, 'Violin'), (6 , 'Flute')
INSERT INTO Classification(Id, TypeOfInstrument) VALUES ( 1, 'String') , (2, 'Wind') , (3, 'Percussion')
INSERT INTO Frequency (Id, Octave) VALUES (1, 'First') , (2, 'Second') , (3, 'Third'), (4, 'Forth') , (5 , 'Fifth'), (6, 'Small'), (7, 'Large'), (8 , 'Controctave')


INSERT INTO insrtuments(Id, InstrumentNameId, FrequencyId , ClassificationId , YearOfProduction , Price) VALUES ( 1 , 1 , 8 , 1, '03-12-2015' , 500)
INSERT INTO insrtuments(Id, InstrumentNameId, FrequencyId , ClassificationId , YearOfProduction , Price) VALUES ( 5 , 5 , 2 , 1, '04-11-2015' , 250)

INSERT INTO insrtuments(Id, InstrumentNameId, FrequencyId , ClassificationId , YearOfProduction , Price) VALUES ( 2 , 2 , 7 , 2, '04-12-2015' , 450)
INSERT INTO insrtuments(Id, InstrumentNameId, FrequencyId , ClassificationId , YearOfProduction , Price) VALUES ( 6 , 6 , 3 , 2, '01-09-2015' , 130)

INSERT INTO Requirements (Id, ClassificationId, frequencyId) VALUES (1, 1, 8) --, (2, 2, 3) , (3, 1, 5) -- нужен струнный контроктавы, духовой третьей октавы
INSERT INTO Requirements (Id, ClassificationId, frequencyId) VALUES (2, 2, 3)
--SELECT * FROM Requirements

SELECT * FROM insrtuments WHERE (ClassificationId  = ANY(SELECT ClassificationId FROM Requirements) AND frequencyId = ANY(SELECT FrequencyId FROM Requirements))

--SELECT insrtuments.Id, InstrumentName , Octave, TypeOfInstrument
-- FROM insrtuments 
-- LEFT JOIN Classification ON insrtuments.ClassificationId = Classification.Id 
-- LEFT JOIN Frequency ON insrtuments.FrequencyId = Frequency.Id
-- LEFT JOIN InstrumentNames ON insrtuments.InstrumentNameId = InstrumentNames.Id
