﻿CREATE TABLE [dbo].[WorkType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_WorkType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

