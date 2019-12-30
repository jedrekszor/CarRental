CREATE TABLE [dbo].[cars] (
    [licenceNo]  VARCHAR (255) NOT NULL,
    [brand]      VARCHAR (255) NULL,
    [model]      VARCHAR (255) NULL,
    [mileage]    INT           NULL,
    [passengers] INT           NULL,
    [price]      FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([licenceNo] ASC)
);

