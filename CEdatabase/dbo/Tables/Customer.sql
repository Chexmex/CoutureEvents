CREATE TABLE [dbo].[Customer]
(
	[ID] INT NOT NULL   IDENTITY (1, 1) PRIMARY KEY, 
    [BrideFirstName] NVARCHAR(50) NULL, 
    [BrideLastName] NVARCHAR(50) NULL, 
    [GroomFirstName] NVARCHAR(50) NULL, 
    [GroomLastName] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [WeddingDate] DATE NULL, 
    [NumberOfGuests] INT NULL, 
    [NumberOfBridesmaids] INT NULL, 
    [NumberOfGroomsmen] INT NULL
)
