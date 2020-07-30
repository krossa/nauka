SELECT name FROM master.dbo.sysdatabases


USE master;
GO
ALTER DATABASE [InterReview] 
SET SINGLE_USER 
WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE [InterReview];