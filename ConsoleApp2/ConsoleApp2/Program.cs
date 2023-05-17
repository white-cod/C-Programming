using System;

class Program
{
    //Задание 1
    ////////////////////////////////////////////////////////////////////////////////
    static void Main(string[] args)
    {
        Console.WriteLine("EX1\n\n");
        decimal[] A = new decimal[5];

        Console.WriteLine("Введите 5 значений для массива A:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"A[{i}]: ");
            A[i] = decimal.Parse(Console.ReadLine());
        }

        decimal[,] B = new decimal[3, 4];

        Random rand = new Random();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                B[i, j] = (decimal)rand.NextDouble();
            }
        }

        Console.WriteLine("Массив A:");
        foreach (decimal a1 in A)
        {
            Console.Write($"{a1} ");
        }
        Console.WriteLine();

        Console.WriteLine("Массив B:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{B[i, j],-10:F2}");
            }
            Console.WriteLine();
        }

        decimal maxA = A[0], minA = A[0], sumA = 0, prodA = 1, evenSumA = 0, oddColSumB = 0;
        for (int i = 0; i < 5; i++)
        {
            if (A[i] > maxA)
            {
                maxA = A[i];
            }
            if (A[i] < minA)
            {
                minA = A[i];
            }
            sumA += A[i];
            prodA *= A[i];
            if (i % 2 == 0)
            {
                evenSumA += A[i];
            }
        }
        for (int j = 0; j < 4; j++)
        {
            if (j % 2 == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    oddColSumB += B[i, j];
                }
            }
        }

        Console.WriteLine($"Максимальное значение в массиве A: {maxA}");
        Console.WriteLine($"Минимальное значение в массиве A: {minA}");
        Console.WriteLine($"Сумма всех элементов в массиве A: {sumA}");
        Console.WriteLine($"Произведение всех элементов в массиве A: {prodA}");
        Console.WriteLine($"Сумма четных элементов в массиве A: {evenSumA}");
        Console.WriteLine($"Сумма нечетных столбцов в массиве B: {oddColSumB}");

        //Задание 2
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX2\n\n");
        int[,] arr = new int[5, 5];

        Random rand1 = new Random();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                arr[i, j] = rand1.Next(-100, 101);
            }
        }

        Console.WriteLine("Массив:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write($"{arr[i, j],5}");
            }
            Console.WriteLine();
        }

        int min = arr[0, 0], max = arr[0, 0];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (arr[i, j] < min)
                {
                    min = arr[i, j];
                }
                if (arr[i, j] > max)
                {
                    max = arr[i, j];
                }
            }
        }

        int sum = 0;
        bool foundMin = false, foundMax = false;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (arr[i, j] == min)
                {
                    foundMin = true;
                }
                if (arr[i, j] == max)
                {
                    foundMax = true;
                }
                if (foundMin && !foundMax)
                {
                    sum += arr[i, j];
                }
                if (foundMax && !foundMin)
                {
                    sum += arr[i, j];
                }
            }
        }

        Console.WriteLine($"Сумма элементов между {min} и {max}: {sum}");

        //Задание 3
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX3\n\n");
        Console.WriteLine("Введите строку для шифрования:");
        string message = Console.ReadLine().ToUpper();

        Console.WriteLine("На сколько позиций нужно сдвинуть символы вправо:");
        int shift = int.Parse(Console.ReadLine());

        string encryptedMessage = Encrypt(message, shift);
        Console.WriteLine($"Зашифрованная строка: {encryptedMessage}");

        string decryptedMessage = Decrypt(encryptedMessage, shift);
        Console.WriteLine($"Расшифрованная строка: {decryptedMessage}");

        static string Encrypt(string message, int shift)
        {
            string encrypted = "";

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(((c - 'A' + shift) % 26) + 'A');
                    encrypted += shifted;
                }
                else
                {
                    encrypted += c;
                }
            }

            return encrypted;
        }

        static string Decrypt(string message, int shift)
        {
            string decrypted = "";

            foreach (char c in message)
            {
                if (char.IsLetter(c))
                {
                    char shifted = (char)(((c - 'A' - shift + 26) % 26) + 'A');
                    decrypted += shifted;
                }
                else
                {
                    decrypted += c;
                }
            }

            return decrypted;
        }

        //Задание 4
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX4\n\n");
        Matrix a = new Matrix(2, 2);
        a.SetElement(0, 0, 1);
        a.SetElement(0, 1, 2);
        a.SetElement(1, 0, 3);
        a.SetElement(1, 1, 4);

        Matrix b = new Matrix(2, 2);
        b.SetElement(0, 0, 5);
        b.SetElement(0, 1, 6);
        b.SetElement(1, 0, 7);
        b.SetElement(1, 1, 8);

        Console.WriteLine("Матрица a:");
        a.Print();

        Console.WriteLine("Матрица b:");
        b.Print();

        Console.WriteLine("a * 2:");
        (a * 2).Print();

        Console.WriteLine("a + b:");
        (a + b).Print();

        Console.WriteLine("a * b:");
        (a * b).Print();

        //Задание 5
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX5\n\n");
        Console.Write("Введите арифметическое выражение, содержащее только операторы + и -: ");
        string input = Console.ReadLine();

        int result = 0;
        int currentNumber = 0;
        char lastOperator = '+';

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];

            if (char.IsDigit(c))
            {
                currentNumber = currentNumber * 10 + (c - '0');
            }

            if (!char.IsDigit(c) || i == input.Length - 1)
            {
                if (lastOperator == '+')
                {
                    result += currentNumber;
                }
                else if (lastOperator == '-')
                {
                    result -= currentNumber;
                }

                currentNumber = 0;
                lastOperator = c;
            }
        }
        Console.WriteLine("Результат: " + result);

        //Задание 6
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX6\n\n");
        Console.Write("Введите текст: ");
        string input1 = Console.ReadLine();

        string[] sentences = input1.Split(new char[] { '.', '?', '!' });

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = sentences[i].Trim();

            if (sentence.Length > 0)
            {
                char[] chars = sentence.ToCharArray();
                chars[0] = char.ToUpper(chars[0]);
                sentences[i] = new string(chars);
            }
        }

        string result1 = string.Join(" ", sentences);

        Console.WriteLine(result1);

        //Задание 7
        ////////////////////////////////////////////////////////////////////////////////

        Console.WriteLine("\nEX7\n\n");
        string[] invalidWords = { "die" };

        Console.Write("Введите текст (Английский): ");
        string input2 = Console.ReadLine();

        int substitutions = 0;
        List<string> words = new List<string>(input2.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries));
        for (int i = 0; i < words.Count; i++)
        {
            if (Array.IndexOf(invalidWords, words[i].ToLower()) != -1)
            {
                words[i] = new string('*', words[i].Length);
                substitutions++;
            }
        }

        string result2 = string.Join(" ", words);

        Console.WriteLine("\nРезультат работы:");
        Console.WriteLine(result2);
        Console.WriteLine("Статистика: {0} замен для слов {1}.", substitutions, string.Join(", ", invalidWords));
    }
}   

class Matrix //Задание 4
{
    private int[,] data;
    private int rows;
    private int cols;

    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        data = new int[rows, cols];
    }

    public void SetData(int[,] data)
    {
        if (data.GetLength(0) != rows || data.GetLength(1) != cols)
        {
            throw new ArgumentException("Недопустимые размеры данных");
        }

        this.data = data;
    }

    public void SetElement(int row, int col, int value)
    {
        data[row, col] = value;
    }

    public int GetElement(int row, int col)
    {
        return data[row, col];
    }

    public int Rows
    {
        get { return rows; }
    }

    public int Cols
    {
        get { return cols; }
    }

    public void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{data[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    public static Matrix operator *(Matrix m, int scalar)
    {
        Matrix result = new Matrix(m.Rows, m.Cols);

        for (int i = 0; i < m.Rows; i++)
        {
            for (int j = 0; j < m.Cols; j++)
            {
                result.SetElement(i, j, m.GetElement(i, j) * scalar);
            }
        }

        return result;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
        {
            throw new ArgumentException("Размеры матрицы не совпадают");
        }

        Matrix result = new Matrix(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
            {
                result.SetElement(i, j, a.GetElement(i, j) + b.GetElement(i, j));
            }
        }

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (a.Cols != b.Rows)
        {
            throw new ArgumentException("Размеры матрицы не совпадают");
        }

        Matrix result = new Matrix(a.Rows, b.Cols);

        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Cols; j++)
            {
                int sum = 0;

                for (int k = 0; k < a.Cols; k++)
                {
                    sum += a.GetElement(i, k) * b.GetElement(k, j);
                }

                result.SetElement(i, j, sum);
            }
        }

        return result;
    }
}