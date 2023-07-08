CREATE PROCEDURE [dbo].[UpdateUser]
    @Id INT,
	@Alias VARCHAR(50),
	@Email VARCHAR(384),
	@FlagUrl VARCHAR(384),
	@AvatarKey INT,
    @Country NVARCHAR(50),
    @Score INT,
    @Credits INT
AS
BEGIN
	--DECLARE @Salt VARCHAR(100)
 --   SET @Salt = CONCAT(NEWID(),NEWID(),NEWID())

 --   DECLARE @HashKey VARCHAR(100)
 --   SET @HashKey = dbo.GetSecret()

 --   DECLARE @PasswdHash VARBINARY(64)
 --   SET @PasswdHash = HASHBYTES('SHA2_512', CONCAT( @Salt, @HashKey, @Passwd, @Salt))

    UPDATE [dbo].[User]
    SET Alias = @Alias, Email = @Email, AvatarKey = @AvatarKey, FlagUrl = @FlagUrl, Country = @Country, Score = @Score, Credits = @Credits
    WHERE  Id = @Id
END
