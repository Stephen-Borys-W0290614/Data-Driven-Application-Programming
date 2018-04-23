CREATE PROCEDURE [dbo].[AddNewBugs]
	@AppID INT,
	@UserID INT,
	@BugSignOff INT, 
	@BugDesc VARCHAR(40),
	@BugDetails TEXT,
	@RwpSteps TEXT,
	@FixDate DATETIME, 
	@BugID INT,
	@StatusCodeID INT,
	@LogDesc TEXT

AS

	BEGIN TRY
        BEGIN TRANSACTION;
			INSERT INTO Bugs(AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails, RepSteps, FixDate)
			VALUES(@AppID, @UserID, @BugSignOff, GETDATE(), @BugDesc, @BugDetails, @RwpSteps, @FixDate);


			SET @BugID = SCOPE_IDENTITY(); --This will get the last idenentity used in this scope.
			--Add to the bug log
			INSERT INTO BugLog(BugLogDate, StatusCodeID, UserID, BugLogDesc, BugID)
			VALUES (GETDATE(), @StatusCodeID, @UserID, @LogDesc, @BugID);

		COMMIT TRANSACTION;
    END TRY
    
	BEGIN CATCH
        -- Rollback any active or uncommittable transactions before
        -- inserting information in the ErrorLog
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

    END CATCH;

