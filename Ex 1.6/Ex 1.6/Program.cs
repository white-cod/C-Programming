using System;

class Shop
{
    private string name;
    private string address;
    private string profileDescription;
    private string phoneNumber;
    private string email;

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

    public void InputData()
    {
        Console.Write("Введите название магазина: ");
        SetName(Console.ReadLine());

        Console.Write("Введите адрес: ");
        SetAddress(Console.ReadLine());

        Console.Write("Введите описание профиля: ");
        SetProfileDescription(Console.ReadLine());

        Console.Write("Введите номер контактного телефона: ");
        SetPhoneNumber(Console.ReadLine());

        Console.Write("Введите контактный адрес электронной почты: ");
        SetEmail(Console.ReadLine());
    }

    public void OutputData()
    {
        Console.WriteLine("Имя: " + GetName());
        Console.WriteLine("Адрес: " + GetAddress());
        Console.WriteLine("Описание профиля: " + GetProfileDescription());
        Console.WriteLine("Номер контактного телефона: " + GetPhoneNumber());
        Console.WriteLine("Контактная почта: " + GetEmail());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();

        shop.InputData();

        Console.WriteLine("\nИнформация о магазине:");
        shop.OutputData();
    }
}