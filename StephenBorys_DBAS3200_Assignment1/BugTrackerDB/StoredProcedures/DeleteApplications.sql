CREATE PROCEDURE [dbo].[DeleteApplications]
	@AppID int
	
AS
	DELETE FROM Applications
	WHERE AppID = @AppID;
	 