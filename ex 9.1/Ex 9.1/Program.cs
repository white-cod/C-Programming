using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

[Serializable]
public struct Fraction
{
    public int Numerator;
    public int Denominator;

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public override string ToString()
    {
        return Numerator + "/" + Denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество дробей: ");
        int n = int.Parse(Console.ReadLine());

        Fraction[] fractions = new Fraction[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите числитель дроби {0}: ", i + 1);
            int numerator = int.Parse(Console.ReadLine());

            Console.Write("Введите знаменатель дроби {0}: ", i + 1);
            int denominator = int.Parse(Console.ReadLine());

            fractions[i] = new Fraction(numerator, denominator);
        }

        Console.WriteLine("Введены дроби: ");
        foreach (Fraction f in fractions)
        {
            Console.WriteLine(f);
        }

        Console.Write("Введите имя файла для сохранения сериализованных дробей: ");
        string fileName = Console.ReadLine();

        SerializeFractions(fractions, fileName);

        Console.Write("Введите имя файла для загрузки сериализованных дробей: ");
        fileName = Console.ReadLine();

        Fraction[] loadedFractions = DeserializeFractions(fileName);

        Console.WriteLine("Дробь загружена: ");
        foreach (Fraction f in loadedFractions)
        {
            Console.WriteLine(f);
        }
    }

    static void SerializeFractions(Fraction[] fractions, string fileName)
    {
        FileStream stream = new FileStream(fileName, FileMode.Create);

        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, fractions);

        stream.Close();
    }

    static Fraction[] DeserializeFractions(string fileName)
    {
        FileStream stream = new FileStream(fileName, FileMode.Open);

        BinaryFormatter formatter = new BinaryFormatter();
        Fraction[] fractions = (Fraction[])formatter.Deserialize(stream);

        stream.Close();

        return fractions;
    }
}