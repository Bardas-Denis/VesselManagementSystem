USE VesselManagementSystem;
GO

--show all merged
SELECT
    o.Owner_name,
    s.Ship_name,
    s.Imo_number,
    sc.Ship_type,
    sc.Ship_tonnage
FROM Owner o
JOIN Owner_Ship os ON o.Owner_Id = os.Owner_Id
JOIN Ship s ON os.Ship_Id = s.Ship_Id
JOIN Ship_Category sc ON s.Ship_Id = sc.Ship_id;
