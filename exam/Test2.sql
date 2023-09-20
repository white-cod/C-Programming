--Проверка 13 тригера
INSERT INTO [Clients] ([FullName], [ContactPhone], [ContactEmail], [DateOfBirth])
VALUES ('Karen Johnson', '555-1111', 'karenjohnson@example.com', '1990-01-01');

--Таблица для проверкаи 14 представления
CREATE TABLE [dbo].[TourArchive](
    [TourID] [int] NOT NULL,
    [ClientID] [int] NOT NULL,
    [TouristID] [int] NOT NULL,
    [ArchivedDate] [datetime] NOT NULL CONSTRAINT [DF_TourArchive_ArchivedDate] DEFAULT (GETDATE())
) ON [PRIMARY]

--Проверка 14 представления
EXEC [dbo].[MovePastToursToArchive]