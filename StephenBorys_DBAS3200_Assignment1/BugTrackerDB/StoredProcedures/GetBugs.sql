CREATE PROCEDURE [dbo].[GetBugs]

AS
	SELECT BugID, AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails, RepSteps, FixDate FROM Bugs; 