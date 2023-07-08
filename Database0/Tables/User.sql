CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY,
    [Alias] VARCHAR(50) NOT NULL,
    [Credits] INT DEFAULT 0,
    [Score] INT DEFAULT 0,
    [AvatarKey] INT NULL DEFAULT 7,
    [FlagUrl] VARCHAR(384) DEFAULT 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/International_Flag_of_Planet_Earth_Budassi_version.svg/1024px-International_Flag_of_Planet_Earth_Budassi_version.svg.png',
    [Country] VARCHAR(50) DEFAULT 'Earth',
    [Email] VARCHAR(384) NOT NULL, 
    [Passwd] VARBINARY(64) NOT NULL, 
    [Salt] VARCHAR(100),
    [IsAdmin] BIT DEFAULT 0,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [UK_User_Email] UNIQUE ([Email])
)
