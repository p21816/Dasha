CREATE TABLE [dbo].[Requirements]
(
	[Id] INT  NOT NULL PRIMARY KEY, 
    [ClassificationId] INT NOT NULL, 
    [frequencyId] INT NOT NULL, 
    CONSTRAINT [FK_Requirements_ToClassification] FOREIGN KEY (ClassificationId) REFERENCES Classification(Id), 
    CONSTRAINT [FK_Requirements_ToFrequency] FOREIGN KEY (frequencyId) REFERENCES Frequency(Id)
)
