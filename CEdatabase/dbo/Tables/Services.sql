CREATE TABLE [dbo].[Services]
(
	[Name] VARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Description] TEXT NULL, 
    [ServiceID] INT IDENTITY (1, 1) NOT NULL  PRIMARY KEY, 
)
