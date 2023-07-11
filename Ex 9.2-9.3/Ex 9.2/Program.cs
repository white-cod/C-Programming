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
        return $"Название: {name}\nПерсонажи: {characters}\nОбъявление: {announcement}";
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
        string result = $"Название: {name}\nИздатель: {publisher}\nДата: {date}\nСтраниц: {pages}\n";

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
        Journal journal = null;
        string fileName = "journal.dat";

        while (true)
        {
            Console.WriteLine("1. Введите информацию о журнале");
            Console.WriteLine("2. Добавить статью в журнал");
            Console.WriteLine("3. Вывод информации о журнале");
            Console.WriteLine("4. Сохраните сериализованный журнал в файл");
            Console.WriteLine("5. Загрузка сериализованного журнала из файла");
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

                    journal = new Journal(name, publisher, date, pages);
                    break;

                case 2:
                    if (journal == null)
                    {
                        Console.WriteLine("Информация о журнале не введена.");
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
                        journal.AddArticle(article);

                        Console.WriteLine("Статья добавлена в журнал.");
                    }
                    break;

                case 3:
                    if (journal == null)
                    {
                        Console.WriteLine("Информация о журнале не введена.");
                    }
                    else
                    {
                        Console.WriteLine(journal);
                    }
                    break;

                case 4:
                    if (journal == null)
                    {
                        Console.WriteLine("Информация о журнале не введена.");
                    }
                    else
                    {
                        try
                        {
                            FileStream fileStream = new FileStream(fileName, FileMode.Create);
                            BinaryFormatter binaryFormatter = new BinaryFormatter();
                            binaryFormatter.Serialize(fileStream, journal);
                            fileStream.Close();

                            Console.WriteLine($"Информация журнала сериализуется и сохраняется в {fileName}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка сериализации: {ex.Message}");
                        }
                    }
                    break;

                case 5:
                    try
                    {
                        FileStream fileStream = new FileStream(fileName, FileMode.Open);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        journal = (Journal)binaryFormatter.Deserialize(fileStream);
                        fileStream.Close();

                        Console.WriteLine($"Информация о журнале, десериализованная из {fileName}.");
                        Console.WriteLine(journal);
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