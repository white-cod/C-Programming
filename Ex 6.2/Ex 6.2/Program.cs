using System;
public class Array : IOutput2
{
    private readonly int[] array;
    public Array(int[] array)
    {
        this.array = array;
    }
    public void ShowEven()
    {
        foreach (int value in array)
        {
            if (value % 2 == 0)
            {
                Console.WriteLine(value);
            }
        }
    }
    public void ShowOdd()
    {
        foreach (int value in array)
        {
            if (value % 2 != 0)
            {
                Console.WriteLine(value);
            }
        }
    }
}
public interface IOutput2
{
    void ShowEven();
    void ShowOdd();
}
public class Test
{
    public static void Main(string[] args)
    {
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var output = new Array(array);
        output.ShowEven();
        Console.WriteLine("");
        output.ShowOdd();
    }
}