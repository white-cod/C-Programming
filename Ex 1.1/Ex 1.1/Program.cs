class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Test 1:\n");
        DrawSquare(1, '#');

        Console.WriteLine("Test 2:\n");
        DrawSquare(3, '@');

        Console.WriteLine("Test 3:\n");
        DrawSquare(5, '*');
    }

    static void DrawSquare(int sideLength, char symbol)
    {
        for (int i = 0; i < sideLength; i++)
        {
            for (int j = 0; j < sideLength; j++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}
