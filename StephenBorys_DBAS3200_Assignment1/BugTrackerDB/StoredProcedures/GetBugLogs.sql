CREATE PROCEDURE [dbo].[GetBugLogs]

	@BugID INT

AS
	SELECT BugLogID, BugLogDate, StatusCodeID, UserID, BugLogDesc, BugID FROM BugLog
	WHERE BugID = @BugID;
	 