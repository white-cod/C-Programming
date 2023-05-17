using System;

public class ForeignPassport
{
    private string passportNumber;
    private string ownerName;
    private DateTime dateOfIssue;
    private DateTime expirationDate;

    public ForeignPassport(string passportNumber, string ownerName, DateTime dateOfIssue, DateTime expirationDate)
    {
        if (string.IsNullOrWhiteSpace(passportNumber)) throw new ArgumentException("Номер паспорта не может быть нулевым.");
        if (string.IsNullOrWhiteSpace(ownerName)) throw new ArgumentException("Имя владельца не может быть нулевым.");
        if (dateOfIssue > expirationDate) throw new ArgumentException("Дата выдачи не может быть позже даты окончания срока действия.");

        this.passportNumber = passportNumber;
        this.ownerName = ownerName;
        this.dateOfIssue = dateOfIssue;
        this.expirationDate = expirationDate;
    }

    public string PassportNumber
    {
        get { return passportNumber; }
    }

    public string OwnerName
    {
        get { return ownerName; }
    }

    public DateTime DateOfIssue
    {
        get { return dateOfIssue; }
    }

    public DateTime ExpirationDate
    {
        get { return expirationDate; }
    }

}

class Program
{
    static void Main(string[] args)
    {

        ForeignPassport passport1 = new ForeignPassport("AB123456", "John Doe", new DateTime(2021, 1, 1), new DateTime(2026, 1, 1));
        Console.WriteLine("Номер паспорта: {0}", passport1.PassportNumber);
        Console.WriteLine("Имя владельца: {0}", passport1.OwnerName);
        Console.WriteLine("Дата выпуска: {0}", passport1.DateOfIssue);
        Console.WriteLine("Срок действия: {0}", passport1.ExpirationDate);

        try
        {
            ForeignPassport passport2 = new ForeignPassport(null, "John Doe", new DateTime(2021, 1, 1), new DateTime(2026, 1, 1));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            ForeignPassport passport3 = new ForeignPassport("AB123456", null, new DateTime(2021, 1, 1), new DateTime(2026, 1, 1));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            ForeignPassport passport4 = new ForeignPassport("AB123456", "John Doe", new DateTime(2026, 1, 1), new DateTime(2021, 1, 1));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.ReadLine();
    }
}