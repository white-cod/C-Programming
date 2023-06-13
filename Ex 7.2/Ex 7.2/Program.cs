using System;
using System.Collections.Generic;

class Backpack
{
    public string Color { get; set; }
    public string Manufacturer { get; set; }
    public string Fabric { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public List<Item> Contents { get; set; } = new List<Item>();

    public event EventHandler<ItemAddedEventArgs> ItemAdded;

    public void FillCharacteristics(string color, string manufacturer, string fabric, double weight, double volume)
    {
        Color = color;
        Manufacturer = manufacturer;
        Fabric = fabric;
        Weight = weight;
        Volume = volume;
    }

    public void AddItem(Item item)
    {
        if (item.Volume > Volume - GetTotalVolume())
        {
            throw new Exception("Не удается добавить предмет в рюкзак. Превышен лимит объема.");
        }

        Contents.Add(item);
        ItemAdded?.Invoke(this, new ItemAddedEventArgs(item));
    }

    public double GetTotalVolume()
    {
        double totalVolume = 0;

        foreach (var item in Contents)
        {
            totalVolume += item.Volume;
        }

        return totalVolume;
    }
}

class Item
{
    public string Name { get; set; }
    public double Volume { get; set; }

    public Item(string name, double volume)
    {
        Name = name;
        Volume = volume;
    }
}

class ItemAddedEventArgs : EventArgs
{
    public Item Item { get; }

    public ItemAddedEventArgs(Item item)
    {
        Item = item;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var backpack = new Backpack();
        backpack.FillCharacteristics("синий", "Nike", "нейлон", 2.5, 30);

        backpack.ItemAdded += (sender, e) =>
        {
            Console.WriteLine($"Добавлено {e.Item.Name} в рюкзак.");
        };

        try
        {
            backpack.AddItem(new Item("книга", 5));
            backpack.AddItem(new Item("бутылка воды", 1));
            backpack.AddItem(new Item("куртка", 10));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}