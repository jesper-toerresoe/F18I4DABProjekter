CREATE TABLE [dbo].[EquipElement] (
    [EquipmentID] BIGINT        IDENTITY (1, 1) NOT NULL,
    [EE_Type]     INT           NULL,
    [EE_Level]    INT           NULL,
    [Description] VARCHAR (255) NULL,
    [ContainedIn] BIGINT        NULL,
    CONSTRAINT [pk_EquipElement] PRIMARY KEY CLUSTERED ([EquipmentID] ASC),
    CONSTRAINT [UQ__EquipElement__3D2915A8] UNIQUE NONCLUSTERED ([EquipmentID] ASC)
);

