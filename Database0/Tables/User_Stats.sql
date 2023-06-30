CREATE TABLE [dbo].[User_Stats]
(
	[User_Stats_Id] INT NOT NULL,
    --[Alias] VARCHAR(50),
    [LevelMax] INT DEFAULT 0,
    [DeathNumber] INT DEFAULT 0,
    [KillNumber] INT DEFAULT 0,
    [BonusNumber] INT DEFAULT 0,
    [WeaponNumber] INT DEFAULT 0,
	[BulletDamage] INT DEFAULT 0,
    [BossKill] INT DEFAULT 0,
    [DragonKill] INT DEFAULT 0,
    [SuccessRate] INT DEFAULT 0,
    [Rank] CHAR DEFAULT 'F'

    --CONSTRAINT [FK_UserStats_UserID] FOREIGN KEY ([UserID])
    --REFERENCES [dbo].[User]([Id])
    CONSTRAINT [PK_UserStats] PRIMARY KEY CLUSTERED([User_Stats_Id]),
    CONSTRAINT [FK_UserID] FOREIGN KEY ([User_Stats_Id])
    REFERENCES [dbo].[User]([Id])
    --ON DELETE CASCADE
    --ON UPDATE CASCADE
)

