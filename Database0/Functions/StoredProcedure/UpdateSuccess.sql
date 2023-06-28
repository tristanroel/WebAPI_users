CREATE PROCEDURE [dbo].[UpdateSuccess]
    @Id INT,
	@Title VARCHAR(50),
    @Description VARCHAR(50),
    @ScoreMax INT, 
    @LevelMax INT,
    @DeathNumber INT,
    @KillNumber INT,
    @BonusNumber INT,
    @WeaponNumber INT,
    @BulletDamage INT,
    @BossKill INT,
    @DragonKill INT,
    @SuccessRate INT,
    @Rank INT
AS
BEGIN
	select [Title] = @Title,
        [Description] = @Description,
        [ScoreMax] = @ScoreMax,
        [LevelMax] = @LevelMax,
        [DeathNumber] = @DeathNumber,
        [KillNumber] = @KillNumber,
        [BonusNumber] = @BonusNumber,
        [WeaponNumber] = @WeaponNumber,
        [BulletDamage] = @BulletDamage,
        [BossKill] = @BossKill,
        [DragonKill] = @DragonKill,
        [SuccessRate] = @SuccessRate,
        [Rank] = @Rank
    from [dbo].[Success] 
    WHERE[Id] = @Id


END
RETURN 0
