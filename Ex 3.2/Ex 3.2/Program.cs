using System;

class Shop
{
    private string name;
    private string address;
    private string profileDescription;
    private string phoneNumber;
    private string email;
    private int storeArea;

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetAddress(string address)
    {
        this.address = address;
    }

    public string GetAddress()
    {
        return address;
    }

    public void SetProfileDescription(string description)
    {
        profileDescription = description;
    }

    public string GetProfileDescription()
    {
        return profileDescription;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    public string GetPhoneNumber()
    {
        return phoneNumber;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }

    public string GetEmail()
    {
        return email;
    }

    public void SetStoreArea(int area)
    {
        storeArea = area;
    }

    public int GetStoreArea()
    {
        return storeArea;
    }

    public void InputData()
    {
        Console.Write("Введите название магазина: ");
        SetName(Console.ReadLine());

        Console.Write("Введите адрес: ");
        SetAddress(Console.ReadLine());

        Console.Write("Описание профиля типа: ");
        SetProfileDescription(Console.ReadLine());

        Console.Write("Введите номер контактного телефона: ");
        SetPhoneNumber(Console.ReadLine());

        Console.Write("Введите адрес контактной электронной почты: ");
        SetEmail(Console.ReadLine());

        Console.Write("Введите площадь магазина: ");
        SetStoreArea(int.Parse(Console.ReadLine()));
    }

    public void OutputData()
    {
        Console.WriteLine("Имя: " + GetName());
        Console.WriteLine("Адрес: " + GetAddress());
        Console.WriteLine("Описание профиля: " + GetProfileDescription());
        Console.WriteLine("Номер контактного телефона: " + GetPhoneNumber());
        Console.WriteLine("Контактная почта: " + GetEmail());
        Console.WriteLine("Площадь магазина: " + GetStoreArea());
    }

    public static Shop operator +(Shop shop, int area)
    {
        Shop newShop = new Shop();
        newShop.SetName(shop.GetName());
        newShop.SetAddress(shop.GetAddress());
        newShop.SetProfileDescription(shop.GetProfileDescription());
        newShop.SetPhoneNumber(shop.GetPhoneNumber());
        newShop.SetEmail(shop.GetEmail());
        newShop.SetStoreArea(shop.GetStoreArea() + area);
        return newShop;
    }

    public static Shop operator -(Shop shop, int area)
    {
        Shop newShop = new Shop();
        newShop.SetName(shop.GetName());
        newShop.SetAddress(shop.GetAddress());
        newShop.SetProfileDescription(shop.GetProfileDescription());
        newShop.SetPhoneNumber(shop.GetPhoneNumber());
        newShop.SetEmail(shop.GetEmail());
        newShop.SetStoreArea(shop.GetStoreArea() - area);
        return newShop;
    }

    public static bool operator ==(Shop shop1, Shop shop2)
    {
        return shop1.GetStoreArea() == shop2.GetStoreArea();
    }

    public static bool operator !=(Shop shop1, Shop shop2)
    {
        return shop1.GetStoreArea() != shop2.GetStoreArea();
    }

    public static bool operator <(Shop shop1, Shop shop2)
    {
        return shop1.GetStoreArea() < shop2.GetStoreArea();
    }

    public static bool operator >(Shop shop1, Shop shop2)
    {
        return shop1.GetStoreArea() > shop2.GetStoreArea();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Shop))
        {
            return false;
        }

        Shop shop = (Shop)obj;
        return GetStoreArea() == shop.GetStoreArea();
    }

    public override int GetHashCode()
    {
        return GetStoreArea().GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shop shop1 = new Shop();
        shop1.InputData();

        Shop shop2 = new Shop();
        shop2.InputData();

        Console.WriteLine("информация shop1:");
        shop1.OutputData();

        Console.WriteLine("информация shop2:");
        shop2.OutputData();

        Shop shop3 = shop1 + 100;
        Console.WriteLine("информация о shop3 (после добавления 100 к площади shop1):");
        shop3.OutputData();

        Shop shop4 = shop2 - 50;
        Console.WriteLine("информация о shop4 (после вычитания 50 из площади shop2):");
        shop4.OutputData();

        Console.WriteLine("shop1 и shop2 имеют равные площади магазинов: " + (shop1 == shop2));
        Console.WriteLine("shop1 и shop2 имеют разные площади магазинов: " + (shop1 != shop2));
        Console.WriteLine("shop1 имеет меньшую площадь магазина, чем shop2: " + (shop1 < shop2));
        Console.WriteLine("shop1 имеет большую площадь магазина, чем shop2: " + (shop1 > shop2));
    }
}