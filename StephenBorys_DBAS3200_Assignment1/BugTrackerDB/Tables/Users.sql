﻿CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[UserName] NVARCHAR(80) NOT NULL UNIQUE,
	[UserEmail] NVARCHAR(80) NOT NULL,
	[UserTel] NVARCHAR(40)
)
