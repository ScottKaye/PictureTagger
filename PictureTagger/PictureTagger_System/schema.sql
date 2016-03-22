CREATE TABLE [dbo].[Pictures] (
    [PictureID]     INT           IDENTITY (1, 1) NOT NULL,
    [Path]          VARCHAR (255) NOT NULL,
    [PrimaryColour] VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([PictureID] ASC)
);

CREATE TABLE [dbo].[Tags] (
    [PictureID] INT          NOT NULL,
    [Tag]       VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Tag] ASC, [PictureID] ASC)
);