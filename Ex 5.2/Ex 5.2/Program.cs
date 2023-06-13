using System;

public class Device
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    public Device(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public virtual void Sound()
    {
        Console.WriteLine($"{Name} издает звук.");
    }

    public void Show()
    {
        Console.WriteLine($"Устройство: {Name}");
    }

    public void Desc()
    {
        Console.WriteLine($"Описание: {Description}");
    }
}

public class Kettle : Device
{
    public Kettle(string name, string description) : base(name, description)
    {
    }

    public override void Sound()
    {
        Console.WriteLine($"{Name} свистки.");
    }
}

public class Microwave : Device
{
    public Microwave(string name, string description) : base(name, description)
    {
    }

    public override void Sound()
    {
        Console.WriteLine($"{Name} звуковые сигналы.");
    }
}

public class Car : Device
{
    public Car(string name, string description) : base(name, description)
    {
    }

    public override void Sound()
    {
        Console.WriteLine($"{Name} сигналит.");
    }
}

public class Steamboat : Device
{
    public Steamboat(string name, string description) : base(name, description)
    {
    }

    public override void Sound()
    {
        Console.WriteLine($"{Name} дует в свой паровозный свисток.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Device[] devices = new Device[]
        {
            new Kettle("Электрический чайник", "Этот чайник кипятит воду с помощью электричества."),
            new Microwave("Микроволновая печь", "Эта печь разогревает пищу с помощью микроволн."),
            new Car("Седан", "Этот автомобиль - четырехдверный."),
            new Steamboat("Paddle Steamer", "Этот пароход использует лопастные колеса для передвижения по воде.")
        };

        foreach (Device device in devices)
        {
            device.Show();
            device.Desc();
            device.Sound();
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}