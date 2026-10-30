# C-Programming

Учебные задания и проекты, написанные во время обучения в Компьютерной академии ШАГ (2022–2024).
Репозиторий — архив: код оставлен в том виде, в котором сдавался, без последующего рефакторинга.

## Что внутри

| Направление | Примеры проектов |
|---|---|
| **C++** (консоль, Visual Studio) — основы, указатели, строки, классы, ООП, контейнеры | `Задание 1.1`…`5.8`, `Project1`…`Project24`, `Drob`, `Complex`, `Matrix`, `String`, `Stack`, `VectorContainer`, `Sea Battle`, `Быки и коровы`, `Stacks_and_Queues`, `Texts_Arrays` |
| **C#** (консоль) — синтаксис, коллекции, LINQ, делегаты, исключения | `Ex 1.1`…`Ex 10.2`, `Chess2`, `Poker`, `Parser`, `philosophy`, `LINQ Ex*.linq` |
| **ADO.NET / SQL Server** | `ADO.NET_LB2`, `ADO.NET_LB14`, `ShopDB_ADO.NET`, `AcademySTEP`, `exam` (SQL-скрипты) |
| **Windows Forms** | `BestOil`, `Alarm clock`, `clock`, `TextEditor1`, `MdiApplication`, `TreeView`, `ListView`, `GDI1`, `NumberGuessingGame`, `Questionnaire` |
| **WPF** | `CalculatorWPF`, `SimpleTextEditorWPF`, `KeyboardTrainer`, `gallery`, `Pulsar`, `OlympiadApp`, `WeatherAppWPF`, `SneakersParserWPF`, `NetworkClockHost` / `NetworkClockClient` |
| **ASP.NET Core** (Razor Pages) | `RazorPagesDemo` |
| **Python** | `Ex17q` |

## Как запустить

Каждая папка — отдельное решение Visual Studio (`.sln`). Откройте его в Visual Studio 2022 и запустите (F5).

- C++ проекты собираются с набором инструментов MSVC (workload *Desktop development with C++*).
- C# проекты в основном нацелены на .NET 6–8 (`net7.0-windows` для WinForms/WPF), часть — на .NET Framework.
- Проекты с базой данных ожидают локальный SQL Server Express (`.\SQLEXPRESS`) — строку подключения при необходимости поправьте в коде.
- `WeatherAppWPF` и `WeatherForecastApp` используют [OpenWeatherMap API](https://openweathermap.org/api): подставьте свой ключ вместо `YOUR_OPENWEATHERMAP_API_KEY` в `MainWindow.xaml.cs`.
