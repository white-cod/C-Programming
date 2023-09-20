USE [master]
GO

-- ����� ��� ��������� �������������� ���������
CREATE LOGIN [AgencyDirector] WITH PASSWORD = 'password';
GO

-- ������������ ��� ��������� �������������� ���������
USE [AroundTheWorldIn80Days];
GO
CREATE USER [AgencyDirector] FOR LOGIN [AgencyDirector];
GO

-- ������ ������ ��������� ��������
GRANT CONTROL TO [AgencyDirector];
GO

-- ����� ��� ������������� � �������� �� ������ � ������� � �����
CREATE LOGIN [ReadAccessUser] WITH PASSWORD = 'password';
GO

-- ������������ ��� ������������� � �������� �� ������ � ������� � �����
USE [AroundTheWorldIn80Days];
GO
CREATE USER [ReadAccessUser] FOR LOGIN [ReadAccessUser];
GO

-- ������ ������������� �� ������ ����� � �����
GRANT SELECT ON [TourCities] TO [ReadAccessUser];
GRANT SELECT ON [Tours] TO [ReadAccessUser];
GO

-- ����� ��� ������������� � ������� �� ��������� ����������� � ��������������
CREATE LOGIN [BackupRestoreUser] WITH PASSWORD = 'password';
GO

-- �������������� ���� �� ��������� ����������� � �������������� �������������, ������� ����� �� ��������� ����������� � ��������������
USE [master];
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [BackupRestoreUser];
GO

-- ����� ��� ������������� � ������� �� �������� � �������� ������ �������������
CREATE LOGIN [UserManagementUser] WITH PASSWORD = 'password';
GO

-- �������������� ���� �� �������� � �������� ������ ������������� ������������� (UserManagementUser)
USE [master];
GO
ALTER SERVER ROLE [securityadmin] ADD MEMBER [UserManagementUser];
GO

-- ����� ��� ������ �������������
CREATE LOGIN [OtherUser] WITH PASSWORD = 'password';
GO

-- �������� ������������ ��� [OtherUser]
USE [AroundTheWorldIn80Days];
GO
CREATE USER [OtherUser] FOR LOGIN [OtherUser];
GO

-- ������������ ����� ������ �������������.
-- ����� SELECT �� ������� Clients ��� ��������� ���������� � ��������:
GRANT SELECT ON [Clients] TO [OtherUser];
GO