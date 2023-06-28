CREATE PROCEDURE [dbo].[DeleteUser]
	@Id int
AS
BEGIN
	
	IF EXISTS(SELECT 1 FROM [dbo].[User_Stats] WHERE [User_Stats_Id] = @Id)
	BEGIN
		DELETE FROM [dbo].[User_Stats]
		WHERE [User_Stats_Id] = @Id AND [User_Stats_Id] != 1
	END
	IF EXISTS(SELECT 1 FROM [dbo].[User] WHERE [Id] = @Id)
	BEGIN
		DELETE FROM [dbo].[User]
		WHERE [Id] = @Id
	END
	IF EXISTS(SELECT 1 FROM [dbo].[Friend] WHERE [User_Id] = @Id)
	BEGIN
		DELETE FROM [dbo].[Friend]
		WHERE [User_Id] = @Id
	END
	IF EXISTS(SELECT 1 FROM [dbo].[User] WHERE [Id] = @Id)
	BEGIN
		DELETE FROM [dbo].[User]
		WHERE [Id] = @Id
	END

END
