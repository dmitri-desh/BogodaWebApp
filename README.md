Инструкция по развертыванию:

1. Установите необходимые зависимости:

Выполните команду для восстановления зависимостей:
dotnet restore
либо
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package AutoMapper

2. Настройте строку подключения к базе данных в appsettings.json: 
Убедитесь, что в файле appsettings.json указана корректная строка подключения:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContactDb;Trusted_Connection=True;"
  }
}

3. Для создания базы данных выполните миграции:
dotnet ef migrations add Initial 
dotnet ef database update

4. Запустите приложение командой:
dotnet run
или из Visual Studio.
