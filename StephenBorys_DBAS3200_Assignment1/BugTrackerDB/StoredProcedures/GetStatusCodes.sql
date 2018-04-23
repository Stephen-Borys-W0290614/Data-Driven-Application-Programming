CREATE PROCEDURE [dbo].[GetStatusCodes]

AS
	SELECT StatusCodeID, StatusCodeDesc FROM StatusCodes;

	 