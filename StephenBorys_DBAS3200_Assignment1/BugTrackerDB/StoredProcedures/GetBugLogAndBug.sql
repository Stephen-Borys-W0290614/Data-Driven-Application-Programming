CREATE PROCEDURE [dbo].[GetBugLogAndBug]
	@p_BugID int
AS
	SELECT b.BugID, 
		   b.AppID, 
		   b.UserID, 
		   b.BugSignOff, 
		   b.BugDate, 
		   b.BugDesc, 
		   b.BugDetails, 
		   b.RepSteps, 
		   b.FixDate,
		   bl.BugLogID, 
		   bl.BugLogDate, 
		   bl.StatusCodeID, 
		   bl.UserID, 
		   bl.BugLogDesc, 
		   bl.BugID
		   FROM Bugs b LEFT OUTER JOIN BugLog bl ON b.BugID = bl.BugID
		   WHERE b.BugID = @p_BugID; 



