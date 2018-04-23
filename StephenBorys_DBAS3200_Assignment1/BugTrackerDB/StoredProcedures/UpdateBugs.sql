CREATE PROCEDURE [dbo].[UpdateBugs]
	@BugID int,
	@AppID int,
	@UserID INT,
	@BugSignOff INT,
	@BugDate DATETIME,
	@BugDesc VARCHAR(40),
	@BugDetails TEXT,
	@Repteps TEXT,
	@FixDate DATETIME,
	@StatusCodeID INT,
	@LogDesc TEXT

AS
	


	
		BEGIN TRY
        BEGIN TRANSACTION;
			UPDATE Bugs
				SET --AppID = @p_AppID, 
				--UserID = @p_UserID,
				--BugSignOff = @p_BugSignOff, 
				BugDate = @BugDate,
				BugDesc = @BugDesc,
				BugDetails = @BugDetails,
				RepSteps = @Repteps,
				FixDate = @FixDate
			WHERE BugID = @BugID;

			--SET @p_getBugID = SCOPE_IDENTITY(); --This will get the last idenentity used in this scope. Since i know bug id i dont need it
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