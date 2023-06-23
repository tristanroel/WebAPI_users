CREATE TABLE [dbo].[Success]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
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
)
