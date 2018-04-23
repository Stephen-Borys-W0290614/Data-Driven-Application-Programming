CREATE PROCEDURE [dbo].[UpdateApplications]
	@AppID int,
	@AppName VARCHAR(40),
	@AppVersion VARCHAR(40),
	@AppDesc VARCHAR(255) 
AS
	UPDATE Applications
	SET AppName = @AppName, AppVersion = @AppVersion, AppDesc = @AppDesc
	WHERE AppID = @AppID;
