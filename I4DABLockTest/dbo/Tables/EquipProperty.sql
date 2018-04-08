CREATE TABLE [dbo].[EquipProperty] (
    [EquipmentID]   BIGINT        NOT NULL,
    [PropertyID]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [PropertyValue] VARCHAR (255) NULL,
    [EngrUnits]     VARCHAR (32)  NULL,
    [Description]   VARCHAR (255) NULL,
    CONSTRAINT [pk_EquipProperty] PRIMARY KEY CLUSTERED ([EquipmentID] ASC, [PropertyID] ASC),
    CONSTRAINT [fk_EquipProperty] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[EquipElement] ([EquipmentID]) ON UPDATE CASCADE
);

