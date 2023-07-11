using System;
using System.Collections.Generic;
using System.IO;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Создайте словарь");
                Console.WriteLine("2. Добавить слово и перевод");
                Console.WriteLine("3. Заменить слово или перевод");
                Console.WriteLine("4. Удалить слово или перевод");
                Console.WriteLine("5. Поиск перевода");
                Console.WriteLine("6. Экспорт словаря");
                Console.WriteLine("0. Выход");
                Console.Write("Введите свой выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDictionary(dictionaries);
                        break;
                    case "2":
                        AddWordAndTranslation(dictionaries);
                        break;
                    case "3":
                        ReplaceWordOrTranslation(dictionaries);
                        break;
                    case "4":
                        RemoveWordOrTranslation(dictionaries);
                        break;
                    case "5":
                        SearchForTranslation(dictionaries);
                        break;
                    case "6":
                        ExportDictionary(dictionaries);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу, чтобы продолжить...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CreateDictionary(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();
            Console.Write("Введите исходный язык: ");
            string sourceLanguage = Console.ReadLine();
            Console.Write("Введите целевой язык: ");
            string targetLanguage = Console.ReadLine();

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            dictionaries.Add(name, dictionary);
            Console.WriteLine($"Словарь '{name}' ({sourceLanguage} -> {targetLanguage}) создан успешно. Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        static void AddWordAndTranslation(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (!dictionaries.ContainsKey(name))
            {
                Console.WriteLine($"Словарь '{name}' не найдено. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            Console.Write("Введите перевод: ");
            string translation = Console.ReadLine();

            if (!dictionaries[name].ContainsKey(word))
            {
                dictionaries[name].Add(word, new List<string>());
            }

            dictionaries[name][word].Add(translation);
            Console.WriteLine($"Слово '{word}' с переводом '{translation}' добавлен в словарь '{name}'. Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        static void ReplaceWordOrTranslation(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (!dictionaries.ContainsKey(name))
            {
                Console.WriteLine($"Словарь '{name}' не найдено. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            if (!dictionaries[name].ContainsKey(word))
            {
                Console.WriteLine($"Слово '{word}' не найден в словаре '{name}'. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите перевод для замены (для замены слова оставьте пустым): ");
            string oldTranslation = Console.ReadLine();
            Console.Write("Введите новое слово или перевод: ");
            string newWordOrTranslation = Console.ReadLine();

            if (string.IsNullOrEmpty(oldTranslation))
            {
                dictionaries[name].Remove(word);
                dictionaries[name].Add(newWordOrTranslation, new List<string>());
            }
            else
            {
                dictionaries[name][word].Remove(oldTranslation);
                dictionaries[name][word].Add(newWordOrTranslation);
            }

            Console.WriteLine($"'{word}' '{oldTranslation}' заменён на '{newWordOrTranslation}' в словаре '{name}'. Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        static void RemoveWordOrTranslation(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (!dictionaries.ContainsKey(name))
            {
                Console.WriteLine($"Словарь '{name}' не найдено. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            if (!dictionaries[name].ContainsKey(word))
            {
                Console.WriteLine($"Слово '{word}' не найден в словаре '{name}'.Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите перевод для удаления (оставьте пустым, чтобы удалить все переводы слова): ");
            string translationToRemove = Console.ReadLine();

            if (string.IsNullOrEmpty(translationToRemove))
            {
                dictionaries[name].Remove(word);
            }
            else
            {
                dictionaries[name][word].Remove(translationToRemove);
            }

            Console.WriteLine($"'{word}' '{translationToRemove}' удалено из словаря '{name}'. Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        static void SearchForTranslation(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (!dictionaries.ContainsKey(name))
            {
                Console.WriteLine($"Словарь '{name}' не найдено. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            if (!dictionaries[name].ContainsKey(word))
            {
                Console.WriteLine($"Слово '{word}' не найден в словаре '{name}'. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Переводы '{word}' в словаре '{name}':");

            foreach (string translation in dictionaries[name][word])
            {
                Console.WriteLine($"- {translation}");
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }

        static void ExportDictionary(Dictionary<string, Dictionary<string, List<string>>> dictionaries)
        {
            Console.Clear();
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (!dictionaries.ContainsKey(name))
            {
                Console.WriteLine($"Словарь '{name}' не найдено. Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите имя файла экспорта: ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, List<string>> entry in dictionaries[name])
                {
                    writer.WriteLine($"{entry.Key}:");

                    foreach (string translation in entry.Value)
                    {
                        writer.WriteLine($"- {translation}");
                    }
                }
            }

            Console.WriteLine($"Словарь '{name}' экспортировано в файл '{fileName}'. Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }
}