CREATE PROCEDURE [dbo].[DeleteUsers]
	@UserID INT

AS
	DELETE FROM Users
	WHERE UserID = @UserID; 
