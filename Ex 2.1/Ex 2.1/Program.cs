using System;

namespace NumberSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста, выберите направление конвертации:");
            Console.WriteLine("1. Перевод десятичной системы в двоичную");
            Console.WriteLine("2. Перевод двоичной системы в десятичную");

            int conversionDirection;
            do
            {
                Console.Write("Введите свой выбор (1 или 2): ");
            } while (!int.TryParse(Console.ReadLine(), out conversionDirection) || (conversionDirection != 1 && conversionDirection != 2));

            Console.Write("Введите число для преобразования: ");
            string numberToConvert = Console.ReadLine();

            try
            {
                switch (conversionDirection)
                {
                    case 1:
                        int decimalNumber = int.Parse(numberToConvert);
                        string binaryNumber = DecimalToBinary(decimalNumber);
                        Console.WriteLine($"Двоичное представление {decimalNumber} это {binaryNumber}");
                        break;
                    case 2:
                        int binaryAsDecimal = BinaryToDecimal(numberToConvert);
                        Console.WriteLine($"Десятичное представление {numberToConvert} это {binaryAsDecimal}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber < 0) throw new ArgumentException("Вводимое число должно быть неотрицательным.");

            string binaryNumber = Convert.ToString(decimalNumber, 2);
            return binaryNumber;
        }

        static int BinaryToDecimal(string binaryNumber)
        {
            if (!IsBinary(binaryNumber)) throw new ArgumentException("Входное число должно быть двоичным числом.");

            int decimalNumber = Convert.ToInt32(binaryNumber, 2);
            return decimalNumber;
        }

        static bool IsBinary(string binaryNumber)
        {
            foreach (char digit in binaryNumber)
            {
                if (digit != '0' && digit != '1') return false;
            }
            return true;
        }
    }
}