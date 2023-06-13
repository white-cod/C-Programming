using System;

public class Money
{
    private int dollars;
    private int cents;

    public Money(int dollars, int cents)
    {
        this.dollars = dollars;
        this.cents = cents;
    }

    public int Dollars
    {
        get { return dollars; }
        set { dollars = value; }
    }

    public int Cents
    {
        get { return cents; }
        set { cents = value; }
    }

    public void Display()
    {
        Console.WriteLine("{0}.{1:00}", dollars, cents);
    }
}

public class Product
{
    private string name;
    private Money price;

    public Product(string name, Money price)
    {
        this.name = name;
        this.price = price;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Money Price
    {
        get { return price; }
        set { price = value; }
    }

    public void ReducePrice(int amount)
    {
        int newCents = price.Cents - amount;
        if (newCents < 0)
        {
            price.Cents = 100 + newCents;
            price.Dollars--;
        }
        else
        {
            price.Cents = newCents;
        }
    }

    public void Display()
    {
        Console.WriteLine("{0}: {1}.{2:00}", name, price.Dollars, price.Cents);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Money price1 = new Money(10, 99);
        Money price2 = new Money(5, 50);

        Product product1 = new Product("Пример продукта 1", price1);
        Product product2 = new Product("Пример продукта 2", price2);

        Console.WriteLine("Начальные цены:");
        product1.Display();
        product2.Display();

        product1.ReducePrice(50);
        product2.ReducePrice(20);

        Console.WriteLine("Цены после снижения:");
        product1.Display();
        product2.Display();

        Console.ReadKey();
    }
}