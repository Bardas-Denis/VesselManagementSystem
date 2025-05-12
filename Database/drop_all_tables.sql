USE VesselManagementSystem;
GO

-- Drop all tables
IF OBJECT_ID('Owner_Ship', 'U') IS NOT NULL DROP TABLE Owner_Ship;
IF OBJECT_ID('Ship_Category', 'U') IS NOT NULL DROP TABLE Ship_Category;
IF OBJECT_ID('Ship', 'U') IS NOT NULL DROP TABLE Ship;
IF OBJECT_ID('Owner', 'U') IS NOT NULL DROP TABLE Owner;
GO