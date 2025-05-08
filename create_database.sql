-- creating database if does not exist
IF NOT EXISTS (
    SELECT name FROM sys.databases WHERE name = N'VesselManagementSystem'
)
BEGIN
    CREATE DATABASE VesselManagementSystem;
END
GO


USE VesselManagementSystem;
GO

--creating tables if they don't exist

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Owner')
BEGIN
    CREATE TABLE Owner (
        Owner_Id INT PRIMARY KEY,
        Owner_name NVARCHAR(255) NOT NULL
    );
END
GO


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ship')
BEGIN
    CREATE TABLE Ship (
        Ship_Id INT PRIMARY KEY,
        Ship_name NVARCHAR(255) NOT NULL,
        Imo_number BIGINT NOT NULL
    );
END
GO


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ship_Category')
BEGIN
    CREATE TABLE Ship_Category (
        Id INT PRIMARY KEY,
        Ship_id INT FOREIGN KEY REFERENCES Ship(Ship_Id),
        Ship_type NVARCHAR(255),
        Ship_tonnage BIGINT
    );
END
GO


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Owner_Ship')
BEGIN
    CREATE TABLE Owner_Ship (
        Owner_Id INT FOREIGN KEY REFERENCES Owner(Owner_Id),
        Ship_Id INT FOREIGN KEY REFERENCES Ship(Ship_Id),
        PRIMARY KEY (Owner_Id, Ship_Id)
    );
END
GO
