CREATE TABLE [dbo].[WorkItem] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [WorkTypeId]  INT            NOT NULL,
    CONSTRAINT [PK_WorkItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkItem_WorkType_WorkTypeId] FOREIGN KEY ([WorkTypeId]) REFERENCES [dbo].[WorkType] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_WorkItem_WorkTypeId]
    ON [dbo].[WorkItem]([WorkTypeId] ASC);

