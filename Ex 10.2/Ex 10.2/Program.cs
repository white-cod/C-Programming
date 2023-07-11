using System;

public class Shop : IDisposable
{
    private string name;
    private string address;
    private string type;
    private bool disposed = false;

    public Shop(string name, string address, string type)
    {
        this.name = name;
        this.address = address;
        this.type = type;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {

            }


            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Shop()
    {
        Dispose(false);
        Console.WriteLine("Объект Shop был удален.");
    }

    public void Open()
    {
        Console.WriteLine("{0} теперь открыт.", name);
    }

    public void Close()
    {
        Console.WriteLine("{0} теперь закрыт.", name);
    }
}

public class Program
{
    public static void Main()
    {
        using (Shop myShop = new Shop("Мой магазин", "123 Шевченка.", " Продовольственный"))
        {
            Console.WriteLine("Название: " + myShop.Name);
            Console.WriteLine("Адрес: " + myShop.Address);
            Console.WriteLine("Type: " + myShop.Type);

            myShop.Open();
            myShop.Close();

            myShop.Name = "Новый магазин";
            myShop.Address = "456 Шевченка.";
            myShop.Type = "Хозяйственный";
        }

    }
}