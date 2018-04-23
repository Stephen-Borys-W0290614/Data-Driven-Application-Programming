CREATE PROCEDURE [dbo].[AddNewUsers]
	@UserName VARCHAR(80),
	@UserEmail VARCHAR(80),
	@UserTel VARCHAR(40)
AS
	INSERT INTO Users(UserName, UserEmail, UserTel) 
	VALUES (@UserName, @UserEmail, @UserTel); 
