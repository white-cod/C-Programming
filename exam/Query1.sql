-----------1-------------
--Предоставьте информацию о всех актуальных турах

CREATE VIEW [CurrentTours] AS
SELECT [Tours].[TourID], [Tours].[TourName], [Tours].[Price], [Tours].[StartDate], [Tours].[EndDate], [Tours].[TravelModes], [Tours].[MaxTourists], [Employees].[FullName] AS [EmployeeName]
FROM [Tours]
JOIN [Employees] ON [Tours].[EmployeeID] = [Employees].[EmployeeID]
WHERE [Tours].[EndDate] >= GETDATE();

-----------2-------------
--Отобразите информацию о всех турах, которые стартуют 
--в указанном диапазоне дат. Диапазон дат передаётся в качестве параметр

CREATE PROCEDURE [ToursByDateRange] 
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT [Tours].[TourID], [Tours].[TourName], [Tours].[Price], [Tours].[StartDate], [Tours].[EndDate], [Tours].[TravelModes], [Tours].[MaxTourists], [Employees].[FullName] AS [EmployeeName]
    FROM [Tours]
    JOIN [Employees] ON [Tours].[EmployeeID] = [Employees].[EmployeeID]
    WHERE [Tours].[StartDate] BETWEEN @StartDate AND @EndDate
END

-----------3-------------
--Отобразите информацию о всех турах, которые посетят 
--указанную страну. Страна передаётся в качестве параметра

CREATE PROCEDURE [ToursByCountry]
    @Country NVARCHAR(50)
AS
BEGIN
    SELECT [Tours].[TourID], [Tours].[TourName], [Tours].[Price], [Tours].[StartDate], [Tours].[EndDate], [Tours].[TravelModes], [Tours].[MaxTourists], [Employees].[FullName] AS [EmployeeName]
    FROM [Tours]
    JOIN [TourCities] ON [Tours].[TourID] = [TourCities].[TourID]
    JOIN [Employees] ON [Tours].[EmployeeID] = [Employees].[EmployeeID]
    WHERE [TourCities].[Country] = @Country
END

-----------4-------------
--Отобразите самую популярную туристическую страну (по 
--самому большому количеству туров)

CREATE VIEW [MostPopularTourCountry] AS
SELECT TOP 1 [TourCities].[Country], COUNT(*) AS [TourCount]
FROM [TourCities]
GROUP BY [TourCities].[Country]
ORDER BY [TourCount] DESC;

-----------5-------------
--Показать самый популярный актуальный тур (по максимальному количеству купленных туристических путевок)

CREATE VIEW [PopularTours] AS
SELECT TOP 1 WITH TIES [Tours].[TourID], [Tours].[TourName], COUNT([Tourists].[TouristID]) AS [NumTourists]
FROM [Tours]
JOIN [Tourists] ON [Tours].[TourID] = [Tourists].[TouristID]
WHERE [Tours].[EndDate] >= GETDATE()
GROUP BY [Tours].[TourID], [Tours].[TourName]
ORDER BY COUNT([Tourists].[TouristID]) DESC;

-----------6-------------
--Показать самый популярный архивный тур (по максимальному количеству купленных туристических путевок)

CREATE VIEW [MostPopularArchiveTour] AS
SELECT t.TourID, t.TourName, COUNT(pt.TouristID) AS PurchasedVouchers
FROM Tours t
JOIN PastTours pt ON t.TourID = pt.TourID
GROUP BY t.TourID, t.TourName
ORDER BY PurchasedVouchers DESC
OFFSET 0 ROWS
FETCH NEXT 1 ROWS ONLY;

-----------7-------------
--Показать самый непопулярный актуальный тур (по минимальному количеству купленных туристических путевок)

CREATE VIEW [UnpopularTours] AS
SELECT [Tours].[TourID], [Tours].[TourName], COUNT([Tourists].[TouristID]) AS [NumTourists]
FROM [Tours]
LEFT JOIN [Tourists] ON [Tours].[TourID] = [Tourists].[TouristID]
WHERE [Tours].[EndDate] >= GETDATE()
GROUP BY [Tours].[TourID], [Tours].[TourName]

-----------8-------------
--Показать для конкретного туриста по ФИО список всех 
--его туров. ФИО туриста передаётся в качестве параметра

CREATE VIEW [TouristTours] AS
SELECT [Tours].[TourName], [Tours].[StartDate], [Tours].[EndDate]
FROM [Tours]
JOIN [Tourists] ON [Tours].[TourID] = [Tourists].[TouristID]
WHERE [Tourists].[FullName] = 'Sarah Lee';

-----------11-------------
--Отобразить информацию о самом активном туристе (по 
--количеству приобретённых туров)

CREATE VIEW [MostActiveTourist] AS
SELECT [Tourists].[TouristID], [Tourists].[FullName], [Tourists].[ContactPhone], [Tourists].[ContactEmail], [Tourists].[DateOfBirth], COUNT(*) AS [TourCount]
FROM [Tourists]
JOIN [PastTours] ON [Tourists].[TouristID] = [PastTours].[TouristID]
GROUP BY [Tourists].[TouristID], [Tourists].[FullName], [Tourists].[ContactPhone], [Tourists].[ContactEmail], [Tourists].[DateOfBirth];

-----------12-------------
--Отобразить информацию о всех турах указанного способа передвижения. Способ передвижения передаётся в качестве параметра

CREATE VIEW [ToursByTravelMode] AS
SELECT [Tours].[TourID], [Tours].[TourName], [Tours].[Price], [Tours].[StartDate], [Tours].[EndDate], [TourCities].[Country], [TourCities].[City], [TourCities].[VisitDate], [Hotels].[HotelName]
FROM [Tours]
JOIN [TourCities] ON [Tours].[TourID] = [TourCities].[TourID]
JOIN [Hotels] ON [TourCities].[City] = [Hotels].[City] AND [Tours].[TourID] = [Hotels].[TourID]
WHERE [Tours].[TravelModes] LIKE '%' + 'Car' + '%';

-----------13-------------
--При вставке нового клиента нужно проверять, нет ли его 
--уже в базе данных. Если такой клиент есть, генерировать 
--ошибку с описанием возникшей проблемы

CREATE TRIGGER [dbo].[CheckClientExists]
ON [dbo].[Clients]
FOR INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 FROM [dbo].[Clients] c
        INNER JOIN inserted i ON c.[FullName] = i.[FullName]
        WHERE c.[ContactPhone] = i.[ContactPhone] AND c.[ContactEmail] = i.[ContactEmail] AND c.[DateOfBirth] = i.[DateOfBirth]
    )
    BEGIN
        RAISERROR ('Client already exists in the database', 16, 1)
        ROLLBACK TRANSACTION
    END
END

-----------14-------------
--При удалении прошедших туров необходимо переносить 
--их в архив туров

CREATE PROCEDURE [dbo].[MovePastToursToArchive]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TourID INT, @ClientID INT, @TouristID INT;

    DECLARE cur CURSOR FOR
    SELECT [TourID], [ClientID], [TouristID] FROM [dbo].[PastTours];

    OPEN cur;

    FETCH NEXT FROM cur INTO @TourID, @ClientID, @TouristID;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        INSERT INTO [dbo].[TourArchive] ([TourID], [ClientID], [TouristID])
        VALUES (@TourID, @ClientID, @TouristID);

        DELETE FROM [dbo].[PastTours]
        WHERE [TourID] = @TourID AND [ClientID] = @ClientID AND [TouristID] = @TouristID;

        FETCH NEXT FROM cur INTO @TourID, @ClientID, @TouristID;
    END;

    CLOSE cur;
    DEALLOCATE cur;
END

-----------15-------------
--Отобразить информацию о самой популярной гостинице 
--среди туристов (по количеству туристов)

CREATE VIEW [dbo].[MostPopularHotel] AS
SELECT TOP 1
    h.[HotelName],
    COUNT(*) AS [NumTourists]
FROM
    [dbo].[Hotels] h
    INNER JOIN [dbo].[TourCities] tc ON h.[TourID] = tc.[TourID]
    INNER JOIN [dbo].[Tourists] t ON t.[TouristID] = t.[TouristID]
GROUP BY
    h.[HotelName]
ORDER BY
    COUNT(*) DESC;

-----------16-------------
--При добавлении нового туриста в тур проверять не достигнуто ли уже максимальное количество. Если максимальное количество достигнуто, генерировать ошибку с 
--информацией о возникшей проблеме

CREATE PROCEDURE [dbo].[AddTouristToTour]
    @TourID INT,
    @ClientID INT,
    @TouristName NVARCHAR(50),
    @TouristEmail NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MaxTourists INT;

    SELECT @MaxTourists = [MaxTourists] FROM [dbo].[Tours] WHERE [TourID] = @TourID;

    IF (SELECT COUNT(*) FROM [dbo].[PastTours] WHERE [TourID] = @TourID AND [ClientID] = @ClientID) >= @MaxTourists
    BEGIN
        RAISERROR('Maximum number of tourists for this tour has been reached.', 16, 1);
        RETURN;
    END

    DECLARE @TouristID INT;

    INSERT INTO [dbo].[Tourists] ([FullName], [ContactEmail])
    VALUES (@TouristName, @TouristEmail);

    SET @TouristID = SCOPE_IDENTITY();

    INSERT INTO [dbo].[PastTours] ([TourID], [ClientID], [TouristID])
    VALUES (@TourID, @ClientID, @TouristID);
END