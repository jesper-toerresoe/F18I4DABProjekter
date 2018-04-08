CREATE TABLE [dbo].[Enumeration] (
    [EnumSet]     VARCHAR (32)  NOT NULL,
    [EnumValue]   INT           NOT NULL,
    [EnumString]  VARCHAR (32)  NOT NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [pk_Enumeration] PRIMARY KEY CLUSTERED ([EnumSet] ASC, [EnumValue] ASC),
    CONSTRAINT [fk_Enumeration] FOREIGN KEY ([EnumSet]) REFERENCES [dbo].[EnumerationSet] ([EnumSet]) ON UPDATE CASCADE
);

