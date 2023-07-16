USE tempdb;
GO
DECLARE @SQL nvarchar(1000);
IF EXISTS (SELECT 1 FROM sys.databases WHERE [name] = N'APIIntegrationDb')
BEGIN
    SET @SQL = N'USE [APIIntegrationDb];

                 ALTER DATABASE APIIntegrationDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                 USE [tempdb];

                 DROP DATABASE APIIntegrationDb;';
    EXEC (@SQL);
END

GO
CREATE DATABASE APIIntegrationDb;
GO
USE APIIntegrationDb;
GO
CREATE TABLE dbo.[Task] (
    Id INT PRIMARY KEY IDENTITY (1, 1),
    [Name] NVARCHAR (50) NOT NULL,
	[Date] DateTime NOT NULL,
    [Type] NVARCHAR (50) NOT NULL,
    IsProcessed BIT NOT NULL DEFAULT(0),
    IsDeleted BIT NOT NULL DEFAULT(0)
);
GO
INSERT INTO dbo.[Task] ([Name], [Date], [Type])
VALUES ('Task1', GETDATE(), 'Type1'),
	   ('Task2', GETDATE(), 'Type2'),
	   ('Task3', GETDATE(), 'Type3');
GO