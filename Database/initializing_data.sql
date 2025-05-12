-- Insert Owners 
INSERT INTO Owner (Owner_name) VALUES
('Holland America Cruises'),
('Royal Caribbean Cruises'),
('Carnival Cruises'),
('Mitsubishi Heavy Industries'),
('Mitsui O.S.K. Lines'),
('Romania Navy');
GO

-- Insert Ships 
INSERT INTO Ship (Ship_name, Imo_number) VALUES
('Symphony of the Seas', 9744001),
('Eco Arctic', 9746683),
('Explorer Spirit', 9313486),
('Carnival Luminosa', 9398905),
('Navigatorii', 9323326),
('Exploratorii', 9878321);
GO

-- Insert Ship Categories 
INSERT INTO Ship_Category (Ship_id, Ship_type, Ship_tonnage) VALUES
(1, 'Cruise', 208081),
(2, 'Crude Oil Tanker', 19554),
(3, 'LPG Tanker', 57657),
(4, 'Cruise', 323872),
(5, 'Cruise', 322122),
(6, 'Cruise', 433211);
GO

-- Insert Owner-Ship relations
INSERT INTO Owner_Ship (Owner_Id, Ship_Id) VALUES
(2, 1),  
(4, 2),  
(5, 3),  
(3, 4),  
(1, 1),
(6, 5),
(6, 6);
GO
