CREATE PROCEDURE [dbo].[RegisterUser]
    @Alias VARCHAR(50),
	@Email NVARCHAR(384),
	@Passwd NVARCHAR(20)
AS
BEGIN
   
    IF LEN(TRIM(@Email)) < 1 AND @Email NOT LIKE '%@%.%'
    BEGIN
        RAISERROR ('Email invalide', 16, 1);
        RETURN 3;
    END

    DECLARE @Salt VARCHAR(100)
    SET @Salt = CONCAT(NEWID(),NEWID(),NEWID())

    DECLARE @HashKey VARCHAR(100)
    SET @HashKey = dbo.GetSecret()

    DECLARE @PasswdHash VARBINARY(64)
    SET @PasswdHash = HASHBYTES('SHA2_512', CONCAT( @Salt, @HashKey, @Passwd, @Salt))

    DECLARE @UserID INT
    SELECT @UserID AS Id FROM [dbo].[User] 

	INSERT INTO [dbo].[User](Alias,Email, Passwd, Salt)
    VALUES (@Alias ,@Email, @PasswdHash, @Salt)

    DECLARE @Id_ref INT 
    SET @Id_ref = SCOPE_IDENTITY()

    INSERT INTO [dbo].[User_Stats](User_Stats_Id)
    VALUES (@Id_ref)

    --INSERT INTO [dbo].[User_Stats](Alias) --SET STATS
    --VALUES (@Alias)

    RETURN 0;
END
