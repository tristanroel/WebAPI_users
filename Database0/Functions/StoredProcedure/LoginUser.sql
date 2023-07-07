CREATE PROCEDURE [dbo].[LoginUser]
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
	DECLARE @Salt VARCHAR(100)
    SELECT @Salt = Salt FROM [dbo].[User] WHERE Email = @Email

    DECLARE @HashKey VARCHAR(100)
    SET @HashKey = dbo.GetSecret()

    DECLARE @PasswdHash VARBINARY(64)
    SET @PasswdHash = HASHBYTES('SHA2_512', CONCAT( @Salt, @HashKey, @Passwd, @Salt))

    SELECT Id, Email, Alias, Country, Score, Credits, IsAdmin FROM [dbo].[User] WHERE Email = @Email AND Passwd = @PasswdHash
END
