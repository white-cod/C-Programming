using System;

delegate bool IntPredicate(int n);
delegate bool StringPredicate(string s);

class Program
{
    static void Main()
    {
        int[] numbers = { 7, 14, 21, -3, 4, -7, -7, 0, -3 };

        int countDivisibleBySeven = CountMatchingNumbers(numbers, IsDivisibleBySeven);
        Console.WriteLine($"Количество элементов, кратных 7: {countDivisibleBySeven}");

        int countPositiveNumbers = CountMatchingNumbers(numbers, IsPositive);
        Console.WriteLine($"Количество положительных чисел: {countPositiveNumbers}");

        int countUniqueNegativeNumbers = CountUniqueNegativeNumbers(numbers, IsNegative);
        Console.WriteLine($"Количество уникальных отрицательных чисел: {countUniqueNegativeNumbers}");

        string[] words = { "привет", "мир" };
        string wordToFind = "мир";
        bool containsWord = ContainsString(words, wordToFind);
        Console.WriteLine($"'{wordToFind}' находится в массиве: {containsWord}");
    }

    static int CountMatchingNumbers(int[] numbers, IntPredicate predicate)
    {
        int count = 0;
        foreach (int number in numbers)
        {
            if (predicate(number))
            {
                count++;
            }
        }
        return count;
    }

    static bool IsDivisibleBySeven(int n)
    {
        return n % 7 == 0;
    }

    static bool IsPositive(int n)
    {
        return n > 0;
    }

    static int CountUniqueNegativeNumbers(int[] numbers, IntPredicate predicate)
    {
        int count = 0;
        int[] uniqueNegatives = new int[numbers.Length];
        int index = 0;
        foreach (int number in numbers)
        {
            if (predicate(number) && !uniqueNegatives.Contains(number))
            {
                count++;
                uniqueNegatives[index] = number;
                index++;
            }
        }
        return count;
    }

    static bool IsNegative(int n)
    {
        return n < 0;
    }

    static bool ContainsString(string[] words, string wordToFind)
    {
        foreach (string word in words)
        {
            if (word.Equals(wordToFind))
            {
                return true;
            }
        }
        return false;
    }
}