CREATE PROCEDURE [dbo].[AddNewApplication]
	@AppName VARCHAR(40),
	@AppVersion VARCHAR(40),
	@AppDesc VARCHAR(255)
AS
	INSERT INTO Applications(AppName, AppVersion, AppDesc)
	VALUES(@AppName, @AppVersion, @AppDesc); 
