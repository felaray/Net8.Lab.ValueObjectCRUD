CREATE TABLE [dbo].[Job] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (MAX) NOT NULL,
    [Item_WorkItemId]   INT            NOT NULL,
    [Item_Description]  NVARCHAR (MAX) NOT NULL,
    [Item_WorkTypeId]   INT            NOT NULL,
    [Item_WorkTypeName] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Job] PRIMARY KEY CLUSTERED ([Id] ASC)
);

