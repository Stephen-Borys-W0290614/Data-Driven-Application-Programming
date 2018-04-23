CREATE PROCEDURE [dbo].[CheckIfAppHasBugs]
	
	@AppID INT

AS

DECLARE @ReturnValue INT

	
IF EXISTS (SELECT BugID FROM Bugs WHERE AppID = @AppID)
	BEGIN
		SET @ReturnValue = 1
		RETURN @ReturnValue
	END

	ELSE
		BEGIN
			SET @ReturnValue = 0
			RETURN @ReturnValue
		END
	
