using System;

public class Piece : IDisposable
{
    private string title;
    private string author;
    private string genre;
    private int year;
    private bool disposed = false;

    public Piece(string title, string author, string genre, int year)
    {
        this.title = title;
        this.author = author;
        this.genre = genre;
        this.year = year;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public string Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {

            }

            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Piece()
    {
        Dispose(false);
        Console.WriteLine("Объект Piece был удален.");
    }
}

public class Program
{
    public static void Main()
    {
        using (Piece myPiece = new Piece("Гамлет", "Уильям Шекспир", "Трагедия", 1603))
        {
            Console.WriteLine("Название: " + myPiece.Title);
            Console.WriteLine("Автор: " + myPiece.Author);
            Console.WriteLine("Жанр: " + myPiece.Genre);
            Console.WriteLine("Год: " + myPiece.Year);

            myPiece.Title = "Макбет";
            myPiece.Year = 1606;
            Console.WriteLine("Название: " + myPiece.Title);
            Console.WriteLine("Год: " + myPiece.Year);
        }

        Console.ReadLine();
    }
}