CREATE PROCEDURE [dbo].[CheckUserName]
	@UserName NVARCHAR(80)
	
	
AS
DECLARE @ReturnValue INT
	
	IF EXISTS(SELECT UserName FROM Users WHERE UserName = @UserName)
		BEGIN
			 SET @ReturnValue = (SELECT UserID FROM Users WHERE UserName = @UserName)
			 RETURN @ReturnValue
			--If the user name exsists then this will return the user id
		END
	ELSE
		BEGIN
			SET @ReturnValue = 0
			RETURN @ReturnValue
			--If it does not work then it will send back a 0 to let the app
			--know its an invalid user name
			
		END