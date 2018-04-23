USE [C:\USERS\NSCCSTUDENT\DESKTOP\DBAS\BORYS-STEPHEN-W0290614\ADONETFIRSTDEMO\ADONETFIRSTDEMO\NORTHWIND.MDF]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[CustOrderHist]
		@CustomerID = N'queen'

SELECT	@return_value as 'Return Value'

GO
