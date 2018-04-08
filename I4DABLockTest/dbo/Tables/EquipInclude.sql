CREATE TABLE [dbo].[EquipInclude] (
    [EquipmentID]      BIGINT     NOT NULL,
    [ClassEquipmentID] BIGINT     NOT NULL,
    [Description]      CHAR (255) NULL,
    CONSTRAINT [pk_EquipInclude] PRIMARY KEY CLUSTERED ([EquipmentID] ASC, [ClassEquipmentID] ASC),
    CONSTRAINT [fk_EquipInclude] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [fk_EquipInclude2] FOREIGN KEY ([ClassEquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID])
);

