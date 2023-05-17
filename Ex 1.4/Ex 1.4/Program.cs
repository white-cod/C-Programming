class Website
{
    private string name;
    private string path;
    private string description;
    private string ipAddress;

    public Website(string name, string path, string description, string ipAddress)
    {
        this.name = name;
        this.path = path;
        this.description = description;
        this.ipAddress = ipAddress;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Path
    {
        get { return path; }
        set { path = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string IpAddress
    {
        get { return ipAddress; }
        set { ipAddress = value; }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Путь: {path}");
        Console.WriteLine($"Описание: {description}");
        Console.WriteLine($"IP Адрес: {ipAddress}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Website mySite = new Website("Мой сайт", "/home/index.html", "Это мой сайт", "192.168.0.1");
        mySite.PrintInfo();
    }
}
