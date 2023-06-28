CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY,
    [Alias] VARCHAR(50) NOT NULL,
    [Credits] INT DEFAULT 0,
    [Score] INT DEFAULT 0,
    [AvatarUrl] VARCHAR(250) NULL,
    [Country] VARCHAR(50) DEFAULT 'NO-COUNTRY',
    [Email] VARCHAR(384) NOT NULL, 
    [Passwd] VARBINARY(64) NOT NULL, 
    [Salt] VARCHAR(100),
    [IsAdmin] BIT DEFAULT 0,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UK_User_Email] UNIQUE ([Email])
)
