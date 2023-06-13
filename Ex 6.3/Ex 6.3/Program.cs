using System;
public class Array : ICalc2
{
    private readonly int[] array;
    public Array(int[] array)
    {
        this.array = array;
    }
    public int CountDistinct()
    {
        var set = new HashSet<int>(array);
        return set.Count;
    }
    public int EqualToValue(int valueToCompare)
    {
        int count = 0;
        foreach (int value in array)
        {
            if (value == valueToCompare)
            {
                count++;
            }
        }
        return count;
    }
}
public interface ICalc2
{
    int CountDistinct();
    int EqualToValue(int valueToCompare);
}
public class Test
{
    public static void Main(string[] args)
    {
        var array = new int[] { 1, 2, 3, 2, 1, 4, 5, 6 };
        var output = new Array(array);
        Console.WriteLine("Количество уникальных значений в массиве равно: " + output.CountDistinct());
        Console.WriteLine("Количество значений, равных 2, в массиве равно: " + output.EqualToValue(2));
    }
}