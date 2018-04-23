CREATE PROCEDURE [dbo].[UpdateUsers]
	@UserID int,
	@UserName VARCHAR(80),
	@UserEmail VARCHAR(80),
	@UserTel VARCHAR(40)
AS
	UPDATE Users
	SET UserName = @UserName, UserEmail = @UserEmail, UserTel = @UserTel
	WHERE UserID = @UserID; 