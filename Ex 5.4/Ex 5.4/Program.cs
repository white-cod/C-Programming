using System;
using static Manager;

public abstract class Worker
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public abstract void Print();
}

public class President : Worker
{
    public int Shares { get; set; }

    public override void Print()
    {
        Console.WriteLine("Имя: {0}, Возраст: {1}, Зарплата: {2:C}, Акции: {3}",
            Name, Age, Salary, Shares);
    }
}

public class Security : Worker
{
    public string GuardType { get; set; }

    public override void Print()
    {
        Console.WriteLine("Имя: {0}, Возраст: {1}, Зарплата: {2:C}, Тип охраны: {3}",
            Name, Age, Salary, GuardType);
    }
}

public class Manager : Worker
{
    public string Department { get; set; }

    public override void Print()
    {
        Console.WriteLine("Имя: {0}, Возраст: {1}, Зарплата: {2:C}, Отдел: {3}",
            Name, Age, Salary, Department);
    }

    public class Engineer : Worker
    {
        public string Specialty { get; set; }

        public override void Print()
        {
            Console.WriteLine("Имя: {0}, Возраст: {1}, Зарплата: {2:C}, Специальность: {3}",
                Name, Age, Salary, Specialty);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        President president = new President
        {
            Name = "Джон Смит",
            Age = 50,
            Salary = 1000000,
            Shares = 1000
        };
        president.Print();

        Security security = new Security
        {
            Name = "Джон Дой",
            Age = 30,
            Salary = 50000,
            GuardType = "Вооруженные"
        };
        security.Print();

        Manager manager = new Manager
        {
            Name = "Боб Джонсон",
            Age = 45,
            Salary = 75000,
            Department = "Продажи"
        };
        manager.Print();

        Engineer engineer = new Engineer
        {
            Name = "Алиса Ли",
            Age = 28,
            Salary = 60000,
            Specialty = "Программное обеспечение"
        };
        engineer.Print();
    }
}