USE [WebApp]
GO

SET IDENTITY_INSERT [Roles] ON

INSERT INTO [dbo].[Roles]
	([Id], [Name])
VALUES
	(1, 'User'),
	(2, 'Administrator');

SET IDENTITY_INSERT [Roles] OFF

INSERT INTO [dbo].[Users]
    ([Id]
    ,[UserID]
    ,[IsActive]
    ,[FirstName]
    ,[LastName])
VALUES
    (NEWID()
    ,'WEBAPPDEV'
    ,1
    ,'WebApp'
    ,'Developer');

INSERT INTO [dbo].[UserRoles]
    ([RolesId], [UsersId])
SELECT 
	r.Id, u.Id
FROM [Users] u
	join [Roles] r ON 1 = 1
   
SET IDENTITY_INSERT [DocumentTypes] ON

INSERT INTO [dbo].[DocumentTypes]
	([Id], [Name])
VALUES
	(1, 'Type 1'),
	(2, 'Type 2');

SET IDENTITY_INSERT [DocumentTypes] OFF

INSERT INTO [dbo].[Documents]
    ([Id]
    ,[RegNumber]
    ,[BarCode]
    ,[CreationDate]
    ,[DocumentTypeId])
VALUES
    (NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 1),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2),
	(NEWID(),CONVERT(varchar(100), NEWID()),CONVERT(varchar(100), NEWID()),GETDATE(), 2);

