class Journal
{
    private string name;
    private int yearOfFoundation;
    private string description;
    private string phoneNumber;
    private string email;
    private int numEmployees;

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

    public int NumEmployees
    {
        get { return numEmployees; }
        set { numEmployees = value; }
    }

    public static Journal operator +(Journal j, int num)
    {
        j.NumEmployees += num;
        return j;
    }

    public static Journal operator -(Journal j, int num)
    {
        j.NumEmployees -= num;
        return j;
    }

    public static bool operator ==(Journal j1, Journal j2)
    {
        return j1.NumEmployees == j2.NumEmployees;
    }

    public static bool operator !=(Journal j1, Journal j2)
    {
        return j1.NumEmployees != j2.NumEmployees;
    }

    public static bool operator <(Journal j1, Journal j2)
    {
        return j1.NumEmployees < j2.NumEmployees;
    }

    public static bool operator >(Journal j1, Journal j2)
    {
        return j1.NumEmployees > j2.NumEmployees;
    }

    public override bool Equals(object obj)
    {
        Journal j = obj as Journal;
        if (j == null)
        {
            return false;
        }
        return NumEmployees == j.NumEmployees;
    }

    public void InputData()
    {
        Console.Write("Введите имя журнала: ");
        SetName(Console.ReadLine());

        Console.Write("Введите год основания: ");
        SetYearOfFoundation(int.Parse(Console.ReadLine()));

        Console.Write("Введите описание: ");
        SetDescription(Console.ReadLine());

        Console.Write("Введите номер контактного телефона: ");
        SetPhoneNumber(Console.ReadLine());

        Console.Write("Введите адрес контактной электронной почты: ");
        SetEmail(Console.ReadLine());

        Console.Write("Введите количество сотрудников: ");
        NumEmployees = int.Parse(Console.ReadLine());
    }

    public void OutputData()
    {
        Console.WriteLine("Имя: " + GetName());
        Console.WriteLine("Год основания: " + GetYearOfFoundation());
        Console.WriteLine("Описание: " + GetDescription());
        Console.WriteLine("Номер контактного телефона: " + GetPhoneNumber());
        Console.WriteLine("Контактная почта: " + GetEmail());
        Console.WriteLine("Количество сотрудников: " + NumEmployees);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal j1 = new Journal();
        j1.InputData();

        Journal j2 = new Journal();
        j2.InputData();

        Console.WriteLine("\nЖурнал 1:");
        j1.OutputData();

        Console.WriteLine("\nЖурнал 2:");
        j2.OutputData();

        Journal j3 = j1 + 5;
        Journal j4 = j2 - 10;

        Console.WriteLine("\nЖурнал 3:");
        j3.OutputData();

        Console.WriteLine("\nЖурнал 4:");
        j4.OutputData();

        Console.WriteLine("\nСравнение количества сотрудников:");
        Console.WriteLine("Журнал 1 == Журнал 2: " + (j1 == j2));
        Console.WriteLine("Журнал 2 != Журнал 3: " + (j2 != j3));
        Console.WriteLine("Журнал 3 < Журнал 4: " + (j3 < j4));
        Console.WriteLine("Журнал 4 > Журнал 1: " + (j4 > j1));
    }
}