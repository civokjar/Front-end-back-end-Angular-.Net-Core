﻿CREATE TABLE [dbo].[ListItem] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [ListId]  UNIQUEIDENTIFIER NOT NULL,
    [Content] NVARCHAR (150)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ListId]) REFERENCES [dbo].[List] ([Id])
);

