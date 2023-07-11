using System;
using System.Collections.Generic;

public class Oceanarium<T> : IEnumerable<T> where T : SeaCreature
{
    private List<T> inhabitants;

    public Oceanarium()
    {
        inhabitants = new List<T>();
    }

    public void AddInhabitant(T inhabitant)
    {
        inhabitants.Add(inhabitant);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return inhabitants.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public abstract class SeaCreature
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
}

public class Dolphin : SeaCreature
{
    public int JumpHeight { get; set; }
}

public class Shark : SeaCreature
{
    public bool IsAggressive { get; set; }
}

public class FootballTeam<T> : IEnumerable<T> where T : Player
{
    private List<T> players;

    public FootballTeam()
    {
        players = new List<T>();
    }

    public void AddPlayer(T player)
    {
        players.Add(player);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return players.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Player
{
    public string Name { get; set; }
    public int Number { get; set; }
    public string Position { get; set; }
}

public class Cafe<T> : IEnumerable<T> where T : Employee
{
    private List<T> employees;

    public Cafe()
    {
        employees = new List<T>();
    }

    public void AddEmployee(T employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return employees.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        Oceanarium<SeaCreature> oceanarium = new Oceanarium<SeaCreature>();
        oceanarium.AddInhabitant(new Dolphin { Name = "Ласта", Species = "Бутылочный дельфин", Age = 12, JumpHeight = 10 });
        oceanarium.AddInhabitant(new Shark { Name = "Челюсти", Species = "Большая белая акула", Age = 20, IsAggressive = true });

        Console.WriteLine("Обитатели океанариума:");
        foreach (SeaCreature creature in oceanarium)
        {
            Console.WriteLine("{0} ({1}, {2} лет)", creature.Name, creature.Species, creature.Age);
        }

        Console.WriteLine();

        FootballTeam<Player> team = new FootballTeam<Player>();
        team.AddPlayer(new Player { Name = "Лионель Месси", Number = 10, Position = "Нападающий" });
        team.AddPlayer(new Player { Name = "Андрей Ярмоленко", Number = 7, Position = "Полузащитник" });

        Console.WriteLine("Игроки футбольной команды:");
        foreach (Player player in team)
        {
            Console.WriteLine("{0} ({1}, #{2})", player.Name, player.Position, player.Number);
        }

        Console.WriteLine();

        Cafe<Employee> cafe = new Cafe<Employee>();
        cafe.AddEmployee(new Employee { Name = "Алиса", Age = 20, Position = "Бариста" });
        cafe.AddEmployee(new Employee { Name = "Санджи", Age = 25, Position = "Шеф-повар" });

        Console.WriteLine("Работники кафе:");
        foreach (Employee employee in cafe)
        {
            Console.WriteLine("{0} ({1}, {2} лет)", employee.Name, employee.Position, employee.Age);
        }
    }
}