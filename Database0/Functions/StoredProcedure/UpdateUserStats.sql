CREATE PROCEDURE [dbo].[UpdateUserStats]
    @Id INT,
	@LevelMax INT,
    @DeathNumber INT,
    @KillNumber INT,
    @BonusNumber INT,
    @WeaponNumber INT,
    @BulletDamage INT,
    @BossKill INT,
    @DragonKill INT,
    @SuccessRate INT,
    @Rank CHAR
AS
BEGIN
	 UPDATE [dbo].[User_Stats]
     SET [LevelMax] = @LevelMax, 
         [DeathNumber] = @DeathNumber, 
         [KillNumber] = @KillNumber, 
         [BonusNumber] = @BonusNumber,
         [WeaponNumber] = @WeaponNumber,
         [BulletDamage] = @BulletDamage,
         [BossKill] = @BossKill,
         [DragonKill] = @DragonKill,
         [SuccessRate] = @SuccessRate,
         [Rank] = @rank WHERE [User_Stats_Id] = @Id
END
RETURN 0
