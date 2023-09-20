USE [master]
GO

-- Ћогин дл€ директора туристического агентства
CREATE LOGIN [AgencyDirector] WITH PASSWORD = 'password';
GO

-- ѕользователь дл€ директора туристического агентства
USE [AroundTheWorldIn80Days];
GO
CREATE USER [AgencyDirector] FOR LOGIN [AgencyDirector];
GO

-- ѕолный доступ директору турфирмы
GRANT CONTROL TO [AgencyDirector];
GO

-- Ћогин дл€ пользователей с доступом на чтение к странам и турам
CREATE LOGIN [ReadAccessUser] WITH PASSWORD = 'password';
GO

-- ѕользователь дл€ пользователей с доступом на чтение к странам и турам
USE [AroundTheWorldIn80Days];
GO
CREATE USER [ReadAccessUser] FOR LOGIN [ReadAccessUser];
GO

-- ƒоступ пользовател€м на чтение стран и туров
GRANT SELECT ON [TourCities] TO [ReadAccessUser];
GRANT SELECT ON [Tours] TO [ReadAccessUser];
GO

-- Ћогин дл€ пользователей с правами на резервное копирование и восстановление
CREATE LOGIN [BackupRestoreUser] WITH PASSWORD = 'password';
GO

-- ѕредоставление прав на резервное копирование и восстановление пользовател€м, имеющим права на резервное копирование и восстановление
USE [master];
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [BackupRestoreUser];
GO

-- Ћогин дл€ пользователей с правами на создание и удаление других пользователей
CREATE LOGIN [UserManagementUser] WITH PASSWORD = 'password';
GO

-- ѕредоставление прав на создание и удаление других пользователей пользовател€м (UserManagementUser)
USE [master];
GO
ALTER SERVER ROLE [securityadmin] ADD MEMBER [UserManagementUser];
GO

-- Ћогин дл€ других пользователей
CREATE LOGIN [OtherUser] WITH PASSWORD = 'password';
GO

-- —оздание пользовател€ дл€ [OtherUser]
USE [AroundTheWorldIn80Days];
GO
CREATE USER [OtherUser] FOR LOGIN [OtherUser];
GO

-- ѕредоставить права другим пользовател€м.
-- ѕрава SELECT на таблицу Clients дл€ просмотра информации о клиентах:
GRANT SELECT ON [Clients] TO [OtherUser];
GO