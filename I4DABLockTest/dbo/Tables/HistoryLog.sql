CREATE TABLE [dbo].[HistoryLog] (
    [RecordID]    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EquipmentID] BIGINT       NULL,
    [UTC]         DATETIME     NULL,
    [LocalTime]   DATETIME     NOT NULL,
    [RecordAlias] VARCHAR (32) NULL,
    [NewValue]    FLOAT (53)   NULL,
    [OldValue]    FLOAT (53)   NULL,
    [EngrUnits]   VARCHAR (32) NULL,
    CONSTRAINT [pk_HistoryLog] PRIMARY KEY CLUSTERED ([RecordID] ASC),
    CONSTRAINT [fk_HistoryLog] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID]) ON UPDATE CASCADE
);

