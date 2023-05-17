using System;

class Journal
{
    private string name;
    private int yearOfFoundation;
    private string description;
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

    public void SetYearOfFoundation(int year)
    {
        yearOfFoundation = year;
    }

    public int GetYearOfFoundation()
    {
        return yearOfFoundation;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public string GetDescription()
    {
        return description;
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
        Console.Write("Введите название журнала: ");
        SetName(Console.ReadLine());

        Console.Write("Введите год основания: ");
        SetYearOfFoundation(int.Parse(Console.ReadLine()));

        Console.Write("Введите описание: ");
        SetDescription(Console.ReadLine());

        Console.Write("Введите номер контактного телефона: ");
        SetPhoneNumber(Console.ReadLine());

        Console.Write("Введите контактный адрес электронной почты: ");
        SetEmail(Console.ReadLine());
    }

    public void OutputData()
    {
        Console.WriteLine("Имя: " + GetName());
        Console.WriteLine("Год основания: " + GetYearOfFoundation());
        Console.WriteLine("Описание: " + GetDescription());
        Console.WriteLine("Номер контактного телефона: " + GetPhoneNumber());
        Console.WriteLine("Контактная почта: " + GetEmail());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        journal.InputData();

        Console.WriteLine("\nИнформация из журнала:");
        journal.OutputData();
    }
}
