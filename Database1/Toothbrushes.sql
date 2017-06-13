CREATE TABLE [dbo].[Toothbrushes]
(
	[Id] INT Identity(1,1) NOT NULL PRIMARY KEY,
	[Name] NvArChAr(255) NOT NULL,
	[Color] NVARCHAR(255) NOT NULL,
	[Rigidity] NVARCHAR(255) NOT NULL
)
