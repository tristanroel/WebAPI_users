CREATE PROCEDURE [dbo].[SetUserScore]
	@UserId INT,
	@Score INT	
AS
BEGIN
	UPDATE [dbo].[User]
    SET [Score] = @Score
    WHERE [Id] = @UserId
END
RETURN 0
