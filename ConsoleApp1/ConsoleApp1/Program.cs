using System;

class Class
{
    static void Main(string[] args)
    {
        //Задание 1

        Console.Write("Task 1\n\n");
        Console.Write("Введите число от 1 до 100: ");
        int number = int.Parse(Console.ReadLine());

        if (number < 1 || number > 100)
        {
            Console.WriteLine("Ошибка: число должно быть от 1 до 100.");
            return;
        }

        if (number % 3 == 0 && number % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (number % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (number % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(number);
        }

        //Задание 2

        Console.Write("\nTask 2\n");
        Console.Write("Введите число: ");
        double number1 = double.Parse(Console.ReadLine());

        Console.Write("Введите процент: ");
        double percentage = double.Parse(Console.ReadLine());

        double result = (number * percentage) / 100;

        Console.WriteLine("{0}% от {1} равно {2}", percentage, number, result);

        //Задание 3

        Console.Write("\nTask 3\n");
        Console.Write("Введите первую цифру: ");
        int firstDigit = int.Parse(Console.ReadLine());

        Console.Write("Введите вторую цифру: ");
        int secondDigit = int.Parse(Console.ReadLine());

        Console.Write("Введите третью цифру: ");
        int thirdDigit = int.Parse(Console.ReadLine());

        Console.Write("Введите четвертую цифру: ");
        int fourthDigit = int.Parse(Console.ReadLine());

        int number2 = (firstDigit * 1000) + (secondDigit * 100) + (thirdDigit * 10) + fourthDigit;

        Console.WriteLine("Созданный номер: {0}", number);

        //Задание 4

        Console.Write("\nTask 4\n");
        Console.Write("Введите шестизначное число: ");
        int number3 = int.Parse(Console.ReadLine());

        if (number3 < 100000 || number3 > 999999)
        {
            Console.WriteLine("Ошибка: число должно состоять из шести цифр.");
            return;
        }

        Console.Write("Введите первую цифру: ");
        int firstIndex = int.Parse(Console.ReadLine());

        Console.Write("Введите вторую цифру: ");
        int secondIndex = int.Parse(Console.ReadLine());

        int[] digits = new int[6];

        for (int i = 5; i >= 0; i--)
        {
            digits[i] = number3 % 10;
            number3 /= 10;
        }

        int temp = digits[firstIndex - 1];
        digits[firstIndex - 1] = digits[secondIndex - 1];
        digits[secondIndex - 1] = temp;

        int result2 = (digits[0] * 100000) + (digits[1] * 10000) + (digits[2] * 1000) + (digits[3] * 100) + (digits[4] * 10) + digits[5];

        Console.WriteLine("Обмененный номер: {0}", result2);

        //Задание 5

        Console.Write("\nTask 5\n");
        Console.WriteLine("Введите дату в формате ММ/ДД/ГГГГ:");
        string dateString = Console.ReadLine();

        DateTime date;
        if (!DateTime.TryParse(dateString, out date))
        {
            Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате ММ/ДД/ГГГГ.");
            return;
        }

        string season;
        switch (date.Month)
        {
            case 12:
            case 1:
            case 2:
                season = "Зима";
                break;
            case 3:
            case 4:
            case 5:
                season = "Весна";
                break;
            case 6:
            case 7:
            case 8:
                season = "Лето";
                break;
            case 9:
            case 10:
            case 11:
                season = "Осень";
                break;
            default:
                Console.WriteLine("Неверный месяц. Пожалуйста, введите действительный месяц (1-12).");
                return;
        }

        string dayOfWeek = date.DayOfWeek.ToString();

        Console.WriteLine($"{season} {dayOfWeek}");

        //Задание 6

        Console.Write("\nTask 6\n");
        Console.WriteLine("Введите температуру:");
        string temperatureString = Console.ReadLine();

        if (!double.TryParse(temperatureString, out double temperature))
        {
            Console.WriteLine("Неверный формат температуры. Пожалуйста введите правильное число.");
            return;
        }

        Console.WriteLine("Введите «F», чтобы преобразовать в градусы Фаренгейта, или «C», чтобы преобразовать в градусы Цельсия:");
        string unitString = Console.ReadLine();

        if (unitString.ToUpper() != "F" && unitString.ToUpper() != "C")
        {
            Console.WriteLine("Недопустимая единица измерения. Пожалуйста, введите «F» для Фаренгейта или «C» для Цельсия.");
            return;
        }

        double convertedTemperature;
        string outputUnit;
        if (unitString.ToUpper() == "F")
        {
            convertedTemperature = (temperature - 32) * 5 / 9;
            outputUnit = "Цельсия";
        }
        else
        {
            convertedTemperature = temperature * 9 / 5 + 32;
            outputUnit = "по Фаренгейту";
        }

        Console.WriteLine($"{temperature} градусов {unitString.ToUpper()} is {convertedTemperature:F2} градусов {outputUnit}.");

        //Задание 7

        Console.Write("\nTask 7\n");
        Console.WriteLine("Введите два числа:");

        Console.Write("Первое число: ");
        string firstString = Console.ReadLine();
        if (!int.TryParse(firstString, out int first))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            return;
        }

        Console.Write("Второе число: ");
        string secondString = Console.ReadLine();
        if (!int.TryParse(secondString, out int second))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            return;
        }

        if (first > second)
        {
            int temp2 = first;
            first = second;
            second = temp2;
            Console.WriteLine($"Границы диапазона были переставлены. Новые границы: {first}, {second}.");
        }

        Console.WriteLine($"Четные числа в диапазоне от {first} до {second}:");
        for (int i = first; i <= second; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}