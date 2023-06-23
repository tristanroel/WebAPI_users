CREATE TABLE [dbo].[User_Stats]
(
	[User_Stats_Id] INT PRIMARY KEY IDENTITY,
    [UserID] INT,
    [Alias] VARCHAR(50),
    [ScoreMax] INT DEFAULT 0,
    [DeathNumber] INT DEFAULT 0,
    [KillNumber] INT DEFAULT 0,
    [BonusNumber] INT DEFAULT 0,
    [WeaponNumber] INT DEFAULT 0,
	[BulletDamage] INT DEFAULT 0,
    [BossKill] INT DEFAULT 0,
    [DragonKill] INT DEFAULT 0,
    [SuccessRate] INT DEFAULT 0,
    [Rank] CHAR DEFAULT 'F'

    CONSTRAINT FK_UserStats_UserID FOREIGN KEY (UserID)
    REFERENCES [User](Id)
)

