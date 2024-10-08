���������� �� �������������:

1. ���������� ����������� �����������:

��������� ������� ��� �������������� ������������:
dotnet restore
����
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package AutoMapper

2. ��������� ������ ����������� � ���� ������ � appsettings.json: 
���������, ��� � ����� appsettings.json ������� ���������� ������ �����������:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContactDb;Trusted_Connection=True;"
  }
}

3. ��� �������� ���� ������ ��������� ��������:
dotnet ef migrations add Initial 
dotnet ef database update

4. ��������� ���������� ��������:
dotnet run
��� �� Visual Studio.