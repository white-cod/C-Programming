using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Article
{
    public string name;
    public int characters;
    public string announcement;

    public Article(string name, int characters, string announcement)
    {
        this.name = name;
        this.characters = characters;
        this.announcement = announcement;
    }

    public override string ToString()
    {
        return $"Название: {name}\nПерсонажи: {characters}\nAnnouncement: {announcement}";
    }
}

[Serializable]
public class Journal
{
    public string name;
    public string publisher;
    public DateTime date;
    public int pages;
    public List<Article> articles;

    public Journal(string name, string publisher, DateTime date, int pages)
    {
        this.name = name;
        this.publisher = publisher;
        this.date = date;
        this.pages = pages;
        this.articles = new List<Article>();
    }

    public void AddArticle(Article article)
    {
        articles.Add(article);
    }

    public override string ToString()
    {
        string result = $"Название: {name}\nИздатель: {publisher}\nДата: {date}\nСтраницы: {pages}\n";

        if (articles.Count == 0)
        {
            result += "Нет статей.";
        }
        else
        {
            result += "Статьи:\n";
            foreach (Article article in articles)
            {
                result += $"{article}\n";
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal[] journals = new Journal[10];
        int count = 0;
        string fileName = "journals.dat";

        while (true)
        {
            Console.WriteLine("1. Введите информацию о журнале");
            Console.WriteLine("2. Добавить статью в журнал");
            Console.WriteLine("3. Вывод информации о журнале");
            Console.WriteLine("4. Сохраните сериализованные журналы в файл");
            Console.WriteLine("5. Загрузка сериализованных журналов из файла");
            Console.WriteLine("0. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Название: ");
                    string name = Console.ReadLine();

                    Console.Write("Издатель: ");
                    string publisher = Console.ReadLine();

                    Console.Write("Дата (yyyy-MM-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Количество страниц: ");
                    int pages = int.Parse(Console.ReadLine());

                    journals[count] = new Journal(name, publisher, date, pages);
                    count++;
                    break;

                case 2:
                    Console.Write("Journal number: ");
                    int journalNumber = int.Parse(Console.ReadLine()) - 1;

                    if (journals[journalNumber] == null)
                    {
                        Console.WriteLine("Журнал не найден.");
                    }
                    else
                    {
                        Console.Write("Название статьи: ");
                        string articleName = Console.ReadLine();

                        Console.Write("Количество символов: ");
                        int characters = int.Parse(Console.ReadLine());

                        Console.Write("Объявление: ");
                        string announcement = Console.ReadLine();

                        Article article = new Article(articleName, characters, announcement);
                        journals[journalNumber].AddArticle(article);

                        Console.WriteLine("Статья добавлена в журнал.");
                    }
                    break;

                case 3:
                    Console.Write("Номер журнала: ");
                    int journalNumber2 = int.Parse(Console.ReadLine()) - 1;

                    if (journals[journalNumber2] == null)
                    {
                        Console.WriteLine("Журнал не найден.");
                    }
                    else
                    {
                        Console.WriteLine(journals[journalNumber2]);
                    }
                    break;

                case 4:
                    try
                    {
                        FileStream fileStream = new FileStream(fileName, FileMode.Create);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, journals);
                        fileStream.Close();

                        Console.WriteLine($"Журналы сериализуются и сохраняются в {fileName}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка сериализации: {ex.Message}");
                    }
                    break;

                case 5:
                    try
                    {
                        FileStream fileStream = new FileStream(fileName, FileMode.Open);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        journals = (Journal[])binaryFormatter.Deserialize(fileStream);
                        fileStream.Close();

                        Console.WriteLine($"Журналы, десериализованные из {fileName}.");
                        Console.WriteLine($"Количество журналов: {count}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка десериализации: {ex.Message}");
                    }
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }

            Console.WriteLine();
        }
    }
}