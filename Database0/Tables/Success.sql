CREATE TABLE [dbo].[Success]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,
	[ScoreMax] INT DEFAULT 0,
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
)
