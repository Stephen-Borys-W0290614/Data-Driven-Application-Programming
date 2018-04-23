CREATE PROCEDURE [dbo].[GetUsers]

AS
	SELECT UserID, UserName, UserEmail, UserTel FROM Users; 