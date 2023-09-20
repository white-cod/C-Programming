-- Employees
INSERT INTO [Employees] ([FullName], [Position], [ContactPhone], [ContactEmail], [DateEmployed])
VALUES ('John Smith', 'Tour Manager', '555-1234', 'johnsmith@example.com', '2020-01-01'),
('Jane Doe', 'Tour Guide', '555-5678', 'janedoe@example.com', '2020-01-01'),
('Bob Johnson', 'Travel Agent', '555-9012', 'bobjohnson@example.com', '2020-01-01'),
('Alice Lee', 'Tour Guide', '555-3456', 'alicelee@example.com', '2020-01-01');

-- TourEmployees
INSERT INTO [TourEmployees] ([EmployeeID], [Country], [TourName])
VALUES (1, 'England', 'Around the UK'),
(1, 'France', 'Paris and Beyond'),
(2, 'China', 'Great Wall Expedition'),
(3, 'USA', 'American Road Trip'),
(4, 'Australia', 'Outback Adventure');

-- Tours
INSERT INTO [Tours] ([TourName], [Price], [StartDate], [EndDate], [TravelModes], [MaxTourists], [EmployeeID])
VALUES ('Around the UK', 1500.00, '2023-05-01', '2023-05-15', 'Bus, Train, Ferry', 20, 1),
('Paris and Beyond', 2500.00, '2023-06-01', '2023-06-15', 'Train, Bus', 15, 1),
('Great Wall Expedition', 3000.00, '2023-07-01', '2023-07-15', 'Plane, Bus', 10, 2),
('American Road Trip', 4000.00, '2023-08-01', '2023-08-15', 'Car', 12, 3),
('Outback Adventure', 5000.00, '2023-09-01', '2023-09-15', 'Plane, Car', 8, 4);

-- TourCities
INSERT INTO [TourCities] ([TourID], [Country], [City], [VisitDate])
VALUES (1, 'England', 'London', '2023-05-02'),
(1, 'England', 'Edinburgh', '2023-05-05'),
(1, 'England', 'Liverpool', '2023-05-08'),
(1, 'England', 'Bath', '2023-05-11'),
(1, 'England', 'Stonehenge', '2023-05-13'),
(2, 'France', 'Paris', '2023-06-02'),
(2, 'France', 'Versailles', '2023-06-05'),
(2, 'France', 'Loire Valley', '2023-06-08'),
(2, 'France', 'Normandy', '2023-06-11'),
(3, 'China', 'Beijing', '2023-07-02'),
(3, 'China', 'Xi''an', '2023-07-05'),
(3, 'China', 'Shanghai', '2023-07-08'),
(4, 'USA', 'New York', '2023-08-02'),
(4, 'USA', 'Chicago', '2023-08-05'),
(4, 'USA', 'Los Angeles', '2023-08-08'),
(5, 'Australia', 'Sydney', '2023-09-02'),
(5, 'Australia', 'Uluru', '2023-09-05'),
(5, 'Australia', 'Great Barrier Reef', '2023-09-08');

-- PointsOfInterest
INSERT INTO [PointsOfInterest] ([TourID], [City], [PointOfInterest], [IncludedInPrice], [ExtraCost])
VALUES (1, 'London', 'Tower of London', 1, 300.00),
(1, 'Edinburgh', 'Edinburgh Castle', 1, 400.00),
(1, 'Liverpool', 'The Beatles Story', 1, 100.00),
(1, 'Bath', 'Roman Baths', 1, 500.00),
(1, 'Stonehenge', 'Stone Circle', 1, 100.00),
(2, 'Paris', 'Eiffel Tower', 1, 200.00),
(2, 'Versailles', 'Palace of Versailles', 1, 600.00),
(2, 'Loire Valley', 'Chateau de Chambord', 1, 200.00),
(2, 'Normandy', 'D-Day Beaches', 1, 800.00),
(3, 'Beijing', 'Great Wall of China', 1, 400.00),
(3, 'Xi''an', 'Terracotta Army', 1, 100.00),
(3, 'Shanghai', 'The Bund', 1, 200.00),
(4, 'New York', 'Statue of Liberty', 1, 300.00),
(4, 'Chicago', 'The Bean', 1, 400.00),
(4, 'Los Angeles', 'Hollywood Walk of Fame', 1, 300.00),
(5, 'Sydney', 'Sydney Opera House', 1, 600.00),
(5, 'Uluru', 'Uluru-Kata Tjuta National Park', 1, 200.00),
(5, 'Great Barrier Reef', 'Snorkeling', 1, 100.00);

-- Hotels
INSERT INTO [Hotels] ([TourID], [City], [HotelName], [HotelImage])
VALUES (1, 'London', 'The Ritz London', 1),
(1, 'Edinburgh', 'The Balmoral Hotel', 1),
(1, 'Liverpool', 'The Shankly Hotel', 1),
(1, 'Bath', 'The Gainsborough Bath Spa', 1),
(1, 'Stonehenge', 'Travelodge Amesbury Stonehenge', 1),
(2, 'Paris', 'Hotel Plaza Athenee', 1),
(2, 'Versailles', 'Trianon Palace Versailles', 1),
(2, 'Loire Valley', 'Chateau d''Artigny', 1),
(2, 'Normandy', 'Hotel Mercure Omaha Beach', 1),
(3, 'Beijing', 'The Peninsula Beijing', 1),
(3, 'Xi''an', 'Sofitel Legend People''s Grand Hotel Xi''an', 1),
(3, 'Shanghai', 'The Peninsula Shanghai', 1),
(4, 'New York', 'The Plaza Hotel', 1),
(4, 'Chicago', 'The Langham Chicago', 1),
(4, 'Los Angeles', 'The Beverly Hilton', 1),
(5, 'Sydney', 'The Langham, Sydney', 1),
(5, 'Uluru', 'Sails in the Desert', 1),
(5, 'Great Barrier Reef', 'Sheraton Grand Mirage Resort, Port Douglas', 1);

-- Tourists
INSERT INTO [Tourists] ([FullName], [ContactPhone], [ContactEmail], [DateOfBirth])
VALUES ('Mark Johnson', '555-1111', 'markjohnson@example.com', '1990-01-01'),
('Sarah Lee', '555-2222', 'sarahlee@example.com', '1985-05-05'),
('Tom Williams', '555-3333', 'tomwilliams@example.com', '1978-12-31'),
('Emily Davis', '555-4444', 'emilydavis@example.com', '2000-06-15'),
('Chris Brown', '555-5555', 'chrisbrown@example.com', '1995-04-20');

-- PotentialTourists
INSERT INTO [PotentialTourists] ([TourID], [TouristID])
VALUES (1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 3),
(3, 5),
(4, 1),
(4, 5),
(5, 2),
(5, 4);

-- Clients
INSERT INTO [Clients] ([FullName], [ContactPhone], [ContactEmail], [DateOfBirth])
VALUES ('Karen Johnson', '555-1111', 'karenjohnson@example.com', '1990-01-01'),
('Hannah Lee', '555-2222', 'hannahlee@example.com', '1985-05-05'),
('David Williams', '555-3333', 'davidwilliams@example.com', '1978-12-31'),
('Amy Davis', '555-4444', 'amydavis@example.com', '2000-06-15'),
('Matt Brown', '555-5555', 'mattbrown@example.com', '1995-04-20');

-- FutureTours
INSERT INTO [FutureTours] ([ClientID], [TourID])
VALUES (1, 1),
(2, 2),
(3, 3),
(4, 4),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(5, 5);

--PastTours
INSERT INTO PastTours (ClientID, TourID, TouristID)
VALUES
(1, 1, 1),
(1, 2, 2),
(2, 1, 3),
(2, 3, 4),
(3, 2, 5),
(3, 3, 6);