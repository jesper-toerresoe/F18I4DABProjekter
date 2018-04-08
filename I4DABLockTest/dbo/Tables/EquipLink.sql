CREATE TABLE [dbo].[EquipLink] (
    [EquipmentID]   BIGINT     NOT NULL,
    [ToEquipmentID] BIGINT     NOT NULL,
    [Description]   CHAR (255) NULL,
    CONSTRAINT [pk_EquipLink] PRIMARY KEY CLUSTERED ([EquipmentID] ASC, [ToEquipmentID] ASC),
    CONSTRAINT [fk_EquipLink] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [fk_EquipLink2] FOREIGN KEY ([ToEquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID])
);

