using System;

class Array : ICalc
{
    private int[] array;

    public Array(int[] array)
    {
        this.array = array;
    }

    public int Less(int valueToCompare)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < valueToCompare)
            {
                count++;
            }
        }
        return count;
    }

    public int Greater(int valueToCompare)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > valueToCompare)
            {
                count++;
            }
        }
        return count;
    }
}

interface ICalc
{
    int Less(int valueToCompare);
    int Greater(int valueToCompare);
}
public class Test
{
    public static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, 5 };
        Array calc = new Array(array);

        Console.WriteLine("Число элементов меньших 3: " + calc.Less(3));
        Console.WriteLine("Число элементов больше 3: " + calc.Greater(3));
    }
}