CREATE TABLE [dbo].[Friend]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY,
	[User_Id] INT NOT NULL,
	[Friend_Id] INT NOT NULL,
	--[IsConnected] BIT DEFAULT 0 NOT NULL,

    CONSTRAINT [FK_UserFriend] FOREIGN KEY ([User_Id])
	REFERENCES [dbo].[User]([Id]),
    CONSTRAINT [FK_FriendUser] FOREIGN KEY ([Friend_Id])
    REFERENCES [dbo].[User]([Id])
)
