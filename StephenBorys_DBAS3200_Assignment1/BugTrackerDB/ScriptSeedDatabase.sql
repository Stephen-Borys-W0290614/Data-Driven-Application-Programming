/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/





IF NOT EXISTS (SELECT 1 FROM StatusCodes WHERE StatusCodeDesc = 'Unassigned')
BEGIN
	INSERT INTO StatusCodes (StatusCodeDesc ) VALUES ('Unassigned');
	INSERT INTO StatusCodes (StatusCodeDesc ) VALUES ('In Progress');
	INSERT INTO StatusCodes (StatusCodeDesc ) VALUES ('Ready For Review');
	INSERT INTO StatusCodes (StatusCodeDesc ) VALUES ('Closed');
END

IF NOT EXISTS (SELECT 1 FROM Applications WHERE AppName = 'ESPN Basketball')
BEGIN
	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('ESPN Basketball', 'A basketball application', 1);
END



--IF EXISTS (SELECT 1 FROM Applications WHERE AppName = 'ESPN Basketball')
--BEGIN
--	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('Tinder', 'This is an app where lonely people can meet up ad start their lives together', 7.9);
--	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('Trip Advisor', 'This is an app to make sure you dont go anywwhere that sucks for a vacation', 9);
--	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('Private Internes Access', 'This lets you look at things you dont want your mom to find out about', 1);
--	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('Slack', 'Its like a chat app for team communications', 6);
--	INSERT INTO Applications(AppName, AppDesc, AppVersion) VALUES ('Apple Music', 'Its like music....But by apple', 1);

--END



IF NOT EXISTS (SELECT 1 FROM Users WHERE UserName = 'Admin')
BEGIN
	INSERT INTO Users(UserName, UserEmail) VALUES ('Admin', 'Admin@example.com');
END



IF NOT EXISTS (SELECT 2 FROM Users WHERE UserName = 'randomUser')
BEGIN
	INSERT INTO Users(UserName, UserEmail) VALUES ('randomUser', 'example1@example.com');
	INSERT INTO Users(UserName, UserEmail) VALUES ('alexG', 'alexG@example.com');
	INSERT INTO Users(UserName, UserEmail) VALUES ('Stephen', 'stephenB@example.com');
	INSERT INTO Users(UserName, UserEmail) VALUES ('MikeC', 'mikeC@example.com');
	INSERT INTO Users(UserName, UserEmail) VALUES ('edMa', 'edMa@example.com');

END



IF NOT EXISTS (SELECT 1 FROM Bugs WHERE BugDesc = 'TEST FOR CLASS')
BEGIN
	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (1, 1, 1,GETDATE(),'TEST FOR CLASS', 'Its a bad one');
END


IF NOT EXISTS (SELECT 2 FROM Bugs WHERE BugDesc = 'My Pics Wont Send')
BEGIN
	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (2, 3, 1,GETDATE(),'My Pics Wont Send', 'Its a bad one');

	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (6, 3, 1,GETDATE(),'My Music Wont Music', 'Its a bad one');

	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (1, 5, 1,GETDATE(),'I cant take Lebron from another persons team', 'Its a bad one');

	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (2, 4, 1,GETDATE(),'My Pics Wont Send', 'Its a bad one');

	INSERT INTO Bugs (AppID, UserID, BugSignOff, BugDate, BugDesc, BugDetails)
	VALUES (2, 2, 1,GETDATE(),'My Pics Wont Send', 'Its a bad one');
END


