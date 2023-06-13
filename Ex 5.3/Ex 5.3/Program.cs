using System;
using static Trombone;

public class MusicalInstrument
{
    protected string name;
    protected string description;
    protected string history;

    public MusicalInstrument(string name, string description, string history)
    {
        this.name = name;
        this.description = description;
        this.history = history;
    }

    public virtual void Sound()
    {
        Console.WriteLine("Этот инструмент издает звук.");
    }

    public void Show()
    {
        Console.WriteLine($"Это {name}.");
    }

    public void Desc()
    {
        Console.WriteLine(description);
    }

    public void History()
    {
        Console.WriteLine(history);
    }
}

public class Violin : MusicalInstrument
{
    public Violin() : base("Скрипка", "Струнный инструмент, издающий высокотональный звук.", "Скрипка имеет долгую историю, в Италии 16 века .") { }

    public override void Sound()
    {
        Console.WriteLine("Скрипка издает приятный, певучий тон.");
    }
}

public class Trombone : MusicalInstrument
{
    public Trombone() : base("Тромбон", "Духовой инструмент с подвижной трубкой, которая изменяет высоту тона.", "Тромбон существует с 15 века и первоначально был сделан из дерева.") { }

    public override void Sound()
    {
        Console.WriteLine("Тромбон издает ровный, богатый звук.");
    }

    public class Ukulele : MusicalInstrument
    {
        public Ukulele() : base("Укулеле", "Небольшой четырехструнный инструмент, обычно ассоциирующийся с гавайской музыкой.", "Укулеле был разработан в конце 19 века на Гавайях.") { }

        public override void Sound()
        {
            Console.WriteLine("Укулеле издает яркий, веселый звук.");
        }
    }

    public class Cello : MusicalInstrument
    {
        public Cello() : base("Виолончель", "Большой струнный инструмент, издающий глубокий, насыщенный звук.", "Виолончель существует с 16 века и первоначально использовалась в основном в оркестровой музыке.") { }

        public override void Sound()
        {
            Console.WriteLine("Виолончель издает теплый, мягкий тон.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MusicalInstrument violin = new Violin();
        MusicalInstrument trombone = new Trombone();
        MusicalInstrument ukulele = new Ukulele();
        MusicalInstrument cello = new Cello();

        Console.WriteLine("--- Скрипка ---");
        violin.Show();
        violin.Desc();
        violin.History();
        violin.Sound();

        Console.WriteLine("--- Тромбон ---");
        trombone.Show();
        trombone.Desc();
        trombone.History();
        trombone.Sound();

        Console.WriteLine("--- Укулеле ---");
        ukulele.Show();
        ukulele.Desc();
        ukulele.History();
        ukulele.Sound();

        Console.WriteLine("--- Виолончель ---");
        cello.Show();
        cello.Desc();
        cello.History();
        cello.Sound();

        Console.ReadLine();
    }
}