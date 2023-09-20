USE [master]
GO

CREATE DATABASE [AroundTheWorldIn80Days]
GO

USE [AroundTheWorldIn80Days]
GO

-- Таблица для сотрудников туристического агентства
CREATE TABLE [Employees] (
    [EmployeeID] INT PRIMARY KEY IDENTITY(1,1),
    [FullName] NVARCHAR(100) NOT NULL,
    [Position] NVARCHAR(50) NOT NULL,
    [ContactPhone] NVARCHAR(20) NOT NULL,
    [ContactEmail] NVARCHAR(100) NOT NULL,
    [DateEmployed] DATE NOT NULL
);

-- Таблица для сотрудников, отвечающих за страны, туры
CREATE TABLE [TourEmployees] (
    [EmployeeID] INT PRIMARY KEY REFERENCES [Employees]([EmployeeID]),
    [Country] NVARCHAR(50) NOT NULL,
    [TourName] NVARCHAR(100) NOT NULL
);

-- Таблица для туров
CREATE TABLE [Tours] (
    [TourID] INT PRIMARY KEY IDENTITY(1,1),
    [TourName] NVARCHAR(100) NOT NULL,
    [Price] DECIMAL(10,2) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [TravelModes] NVARCHAR(100) NOT NULL,
    [MaxTourists] INT NOT NULL,
    [EmployeeID] INT NOT NULL REFERENCES [Employees]([EmployeeID])
);

-- Таблица для городов тура
CREATE TABLE [TourCities] (
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [Country] NVARCHAR(50) NOT NULL,
    [City] NVARCHAR(50) NOT NULL,
    [VisitDate] DATE NOT NULL
);

-- Таблица для достопримечательностей в каждой точке маршрута
CREATE TABLE [PointsOfInterest] (
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [City] NVARCHAR(50) NOT NULL,
    [PointOfInterest] NVARCHAR(100) NOT NULL,
    [IncludedInPrice] BIT NOT NULL,
    [ExtraCost] DECIMAL(10,2) NULL
);

-- Таблица для изображений достопримечательностей
CREATE TABLE [SightImages] (
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [City] NVARCHAR(50) NOT NULL,
    [SightImage] VARBINARY(MAX) NOT NULL
);

-- Таблица для гостиниц
CREATE TABLE [Hotels] (
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [City] NVARCHAR(50) NOT NULL,
    [HotelName] NVARCHAR(100) NOT NULL,
    [HotelImage] VARBINARY(MAX) NOT NULL
);

-- Таблица для туристов, оплативших тур
CREATE TABLE [Tourists] (
    [TouristID] INT PRIMARY KEY IDENTITY(1,1),
    [FullName] NVARCHAR(100) NOT NULL,
    [ContactPhone] NVARCHAR(20) NOT NULL,
    [ContactEmail] NVARCHAR(100) NOT NULL,
    [DateOfBirth] DATE NOT NULL
);

-- Таблица для потенциальных туристов, которые интересовались туром
CREATE TABLE [PotentialTourists] (
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [TouristID] INT NOT NULL REFERENCES [Tourists]([TouristID]),
    PRIMARY KEY ([TourID], [TouristID])
);

-- Таблица для клиентов агентства
CREATE TABLE [Clients] (
    [ClientID] INT PRIMARY KEY IDENTITY(1,1),
    [FullName] NVARCHAR(100) NOT NULL,
    [ContactPhone] NVARCHAR(20) NOT NULL,
    [ContactEmail] NVARCHAR(100) NOT NULL,
    [DateOfBirth] DATE NOT NULL
);

-- Таблица для будущих туров клиента
CREATE TABLE [FutureTours] (
    [ClientID] INT NOT NULL REFERENCES [Clients]([ClientID]),
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    PRIMARY KEY ([ClientID], [TourID])
);

-- Таблица для прошлых экскурсий клиента
CREATE TABLE [PastTours] (
    [ClientID] INT NOT NULL REFERENCES [Clients]([ClientID]),
    [TourID] INT NOT NULL REFERENCES [Tours]([TourID]),
    [TouristID] INT NOT NULL REFERENCES [Tourists]([TouristID]),
    PRIMARY KEY ([ClientID], [TourID], [TouristID])
);

-- Индексация
CREATE INDEX [IX_Tours_EmployeeID] ON [Tours]([EmployeeID]);
CREATE INDEX [IX_TourCities_TourID] ON [TourCities]([TourID]);
CREATE INDEX [IX_PointsOfInterest_TourID] ON [PointsOfInterest]([TourID]);
CREATE INDEX [IX_Hotels_TourID] ON [Hotels]([TourID]);
CREATE INDEX [IX_PotentialTourists_TourID] ON [PotentialTourists]([TourID]);
CREATE INDEX [IX_FutureTours_ClientID] ON [FutureTours]([ClientID]);
CREATE INDEX [IX_FutureTours_TourID] ON [FutureTours]([TourID]);
CREATE INDEX [IX_PastTours_ClientID] ON [PastTours]([ClientID]);
CREATE INDEX [IX_PastTours_TourID] ON [PastTours]([TourID]);
CREATE INDEX [IX_PastTours_TouristID] ON [PastTours]([TouristID]);