CREATE TABLE [dbo].[insrtuments]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [InstrumentNameId] INT NOT NULL, 
    [FrequencyId] INT NOT NULL, 
    [ClassificationId] INT NOT NULL, 
    [YearOfProduction] DATE NOT NULL, 
    [Price] MONEY NOT NULL, 
    CONSTRAINT [FK_insrtuments_ToInstName] FOREIGN KEY (InstrumentNameId) REFERENCES InstrumentNames(Id), 
    CONSTRAINT [FK_insrtuments_ToClassification] FOREIGN KEY (ClassificationId) REFERENCES Classification(Id), 
    CONSTRAINT [FK_insrtuments_ToFrequency] FOREIGN KEY (FrequencyId) REFERENCES Frequency(Id)
)
