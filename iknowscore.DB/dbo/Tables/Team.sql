CREATE TABLE [dbo].[Team] (
    [TeamID]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [CountryID] INT           NULL,
    [City]      NVARCHAR (50) NULL,
    [ImageFile] IMAGE         NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED ([TeamID] ASC),
    CONSTRAINT [FK_Team_Country] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([CountryID])
);

