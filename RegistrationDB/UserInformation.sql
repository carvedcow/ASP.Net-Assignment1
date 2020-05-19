CREATE TABLE [dbo].[UserInformation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(100) NULL, 
    [City] NVARCHAR(50) NULL, 
    [Province] CHAR(2) NULL, 
    [PostalCode] NVARCHAR(7) NULL, 
    [Country] NVARCHAR(50) NULL
)
