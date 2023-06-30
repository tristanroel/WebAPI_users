CREATE PROCEDURE [dbo].[UpdateUser]
    @Id INT,
	@Alias VARCHAR(50),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20),
	@AvatarUrl NVARCHAR(250),
    @Country NVARCHAR(50),
    @Score INT,
    @Credits INT
AS
BEGIN
	DECLARE @Salt VARCHAR(100)
    SET @Salt = CONCAT(NEWID(),NEWID(),NEWID())

    DECLARE @HashKey VARCHAR(100)
    SET @HashKey = dbo.GetSecret()

    DECLARE @PasswdHash VARBINARY(64)
    SET @PasswdHash = HASHBYTES('SHA2_512', CONCAT( @Salt, @HashKey, @Passwd, @Salt))

    UPDATE [dbo].[User]
    SET Alias = @Alias, Email = @Email, Passwd = @PasswdHash, AvatarUrl = @AvatarUrl, Country = @Country, Score = @Score, Credits = @Credits
    WHERE  Id = @Id
END
