CREATE PROCEDURE [dbo].[GetApplications]

AS
	SELECT AppID, AppName, AppVersion, AppDesc FROM Applications; 