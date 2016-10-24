CREATE TABLE [dbo].[Customer] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [BrideFirstName]      NVARCHAR (50) NULL,
    [BrideLastName]       NVARCHAR (50) NULL,
    [GroomFirstName]      NVARCHAR (50) NULL,
    [GroomLastName]       NVARCHAR (50) NULL,
    [PhoneNumber]         NVARCHAR (50) NULL,
    [Email]               NVARCHAR (50) NULL,
    [Address]             NVARCHAR (50) NULL,
    [City]                NVARCHAR (50) NULL,
    [WeddingDate]         DATE          NULL,
    [NumberOfGuests]      INT           NULL,
    [NumberOfBridesmaids] INT           NULL,
    [NumberOfGroomsmen]   INT           NULL,
    [Password]            NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


