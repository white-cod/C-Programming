--�������� 13 �������
INSERT INTO [Clients] ([FullName], [ContactPhone], [ContactEmail], [DateOfBirth])
VALUES ('Karen Johnson', '555-1111', 'karenjohnson@example.com', '1990-01-01');

--������� ��� ��������� 14 �������������
CREATE TABLE [dbo].[TourArchive](
    [TourID] [int] NOT NULL,
    [ClientID] [int] NOT NULL,
    [TouristID] [int] NOT NULL,
    [ArchivedDate] [datetime] NOT NULL CONSTRAINT [DF_TourArchive_ArchivedDate] DEFAULT (GETDATE())
) ON [PRIMARY]

--�������� 14 �������������
EXEC [dbo].[MovePastToursToArchive]