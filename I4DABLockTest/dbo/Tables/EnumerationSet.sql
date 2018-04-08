CREATE TABLE [dbo].[EnumerationSet] (
    [EnumSet]     VARCHAR (32)  NOT NULL,
    [Description] VARCHAR (255) NULL,
    CONSTRAINT [pk_EnumerationSet] PRIMARY KEY CLUSTERED ([EnumSet] ASC)
);

