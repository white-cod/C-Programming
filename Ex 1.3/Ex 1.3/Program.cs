class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Test 1:");
        int[] originalArray1 = new int[] { 1, 2, 6, -1, 88, 7, 6 };
        int[] arrayToFilter1 = new int[] { 6, 88, 7 };
        int[] filteredArray1 = FilterArray(originalArray1, arrayToFilter1);
        Console.WriteLine($"Оригинальный массив: [{string.Join(", ", originalArray1)}]");
        Console.WriteLine($"Массив для фильтрации: [{string.Join(", ", arrayToFilter1)}]");
        Console.WriteLine($"Отфильтрованный массив: [{string.Join(", ", filteredArray1)}]");

        Console.WriteLine("Test 2:");
        int[] originalArray2 = new int[] { 1, 2, 6, -1, 88, 7, 6 };
        int[] arrayToFilter2 = new int[] { 1, 6, 6 };
        int[] filteredArray2 = FilterArray(originalArray2, arrayToFilter2);
        Console.WriteLine($"Оригинальный массив: [{string.Join(", ", originalArray2)}]");
        Console.WriteLine($"Массив для фильтрации: [{string.Join(", ", arrayToFilter2)}]");
        Console.WriteLine($"Отфильтрованный массив: [{string.Join(", ", filteredArray2)}]");

        Console.WriteLine("Test 3:");
        int[] originalArray3 = new int[] { 1, 2, 3, 4, 5 };
        int[] arrayToFilter3 = new int[] { 6, 7, 8 };
        int[] filteredArray3 = FilterArray(originalArray3, arrayToFilter3);
        Console.WriteLine($"Оригинальный массив: [{string.Join(", ", originalArray3)}]");
        Console.WriteLine($"Массив для фильтрации: [{string.Join(", ", arrayToFilter3)}]");
        Console.WriteLine($"Отфильтрованный массив: [{string.Join(", ", filteredArray3)}]");
    }

    static int[] FilterArray(int[] originalArray, int[] arrayToFilter)
    {
        List<int> filteredList = new List<int>(originalArray);

        foreach (int filter in arrayToFilter)
        {
            filteredList.RemoveAll(x => x == filter);
        }

        return filteredList.ToArray();
    }
}