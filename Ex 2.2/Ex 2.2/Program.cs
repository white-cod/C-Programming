using System;

namespace WordToNumberConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число словами (от нуля до девяти): ");

            string input = Console.ReadLine().ToLower();
            int output;

            switch (input)
            {
                case "ноль":
                    output = 0;
                    break;
                case "один":
                    output = 1;
                    break;
                case "два":
                    output = 2;
                    break;
                case "три":
                    output = 3;
                    break;
                case "четыре":
                    output = 4;
                    break;
                case "пять":
                    output = 5;
                    break;
                case "шесть":
                    output = 6;
                    break;
                case "семь":
                    output = 7;
                    break;
                case "восемь":
                    output = 8;
                    break;
                case "девять":
                    output = 9;
                    break;
                default:
                    Console.WriteLine("Неверный ввод!");
                    return;
            }

            Console.WriteLine($"Номер {output}");

        }
    }
}
