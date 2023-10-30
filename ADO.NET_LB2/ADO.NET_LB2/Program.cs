using System;
using System.Data;
using System.Data.SqlClient;

public class LibraryQueries
{
    private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=LibraryDB;Integrated Security=True;";

    public static void Main()
    {
        Console.WriteLine("1) Вывести список должников:");
        PrintDebtors();

        Console.WriteLine("\n2) Вывести список авторов книги 3:");
        PrintAuthorsOfBook(3);

        Console.WriteLine("\n3) Вывести список книг, которые доступны в данный момент:");
        PrintAvailableBooks();

        Console.WriteLine("\n4) Печать списка книг, имеющихся у пользователя 2:");
        PrintBooksOnHand(2);

        Console.WriteLine("\n5) Вывести список книг, которые были взяты за последние 2 недели:");
        PrintBorrowedBooksLastTwoWeeks();

        Console.WriteLine("\n6) Обнулить долги всех должников:");
        ZeroOutDebts();
        int borrowerID = 1;
        int booksBorrowedLastYear = GetBooksBorrowedLastYear(borrowerID);
        Console.WriteLine("\n7) Вывести количество книг, взятых определенным посетителем за последний год:");
        Console.WriteLine($"Visitor #{borrowerID} заимствовал {booksBorrowedLastYear} книги за последний год.");

        Console.WriteLine("\n8) Вывести всех пользователей, которые взяли книгу «Война и мир»");
        GetUsersBorrowingBook("War and Peace");

        Console.WriteLine("\n9) Вывести авторов книги «Война и мир»:");
        GetAuthorsOfBook("War and Peace");

        Console.WriteLine("\n10) Вывести список книг, которые были взяты после указанной даты:");
        GetBooksTakenAfterDate(new DateTime(2022, 10, 01));

        Console.WriteLine("\n11) Вывести цены тех книг, которые на руках у определенного в параметре пользователя (2):");
        GetPricesOfBooksInUserPossession(2);

        Console.WriteLine("\n12) Вывести все книги, цена которых больше указанной, вышедшие не позднее указанной во втором параметре даты:");
        GetBooksAbovePriceAndPublishedBeforeDate(50.00m, new DateTime(2022, 01, 01));

        Console.WriteLine("\n13) Вывести количество книг в библиотеке:");
        int numberOfBooks = GetNumberOfBooks();
        Console.WriteLine($"Количество книг в библиотеке: {numberOfBooks}");

        Console.WriteLine("\n14) Вывести сумму цен всех книг:");
        decimal totalBookPrice = GetTotalBookPrice();
        Console.WriteLine($"Общая стоимость всех книг: {totalBookPrice}");

        Console.WriteLine("\n15) Вывести сумму страниц всех книг:");
        int authorID = 1;
        int totalPagesByAuthor = GetTotalPagesByAuthor(authorID);
        Console.WriteLine($"Общее количество страниц, написанных автором {authorID}: {totalPagesByAuthor}");


    }

    public static void PrintDebtors()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Debtors";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Debtor ID: {reader["DebtorID"]}, Debtor Name: {reader["DebtorName"]}, Debt: {reader["Debt"]}");
            }
        }
    }

    public static void PrintAuthorsOfBook(int bookID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Authors.AuthorName " +
                           "FROM Authors " +
                           "JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                           $"WHERE Books.BookID = {bookID}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Author Name: {reader["AuthorName"]}");
            }
        }
    }

    public static void PrintAvailableBooks()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Books WHERE IsAvailable = 1";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book ID: {reader["BookID"]}, Book Name: {reader["BookName"]}");
            }
        }
    }

    public static void PrintBooksOnHand(int debtorID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Books.BookID, Books.BookName " +
                           "FROM Books " +
                           "JOIN Borrowings ON Books.BookID = Borrowings.BookID " +
                           $"WHERE Borrowings.DebtorID = {debtorID}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book ID: {reader["BookID"]}, Book Name: {reader["BookName"]}");
            }
        }
    }

    public static void PrintBorrowedBooksLastTwoWeeks()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Books.BookID, Books.BookName " +
                           "FROM Books " +
                           "JOIN Borrowings ON Books.BookID = Borrowings.BookID " +
                           "WHERE Borrowings.BorrowDate >= DATEADD(week, -2, GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book ID: {reader["BookID"]}, Book Name: {reader["BookName"]}");
            }
        }
    }

    public static void ZeroOutDebts()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "UPDATE Debtors SET Debt = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Долги были обнулены.");
        }
    }

    public static int GetBooksBorrowedLastYear(int borrowerID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) " +
                           "FROM Borrowings " +
                           "WHERE DebtorID = @DebtorID " +
                           "AND BorrowDate >= DATEADD(year, -1, GETDATE())";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DebtorID", borrowerID);
            return (int)command.ExecuteScalar();
        }
    }

    ////////////////////////////////////////////////////////////

    public static void GetUsersBorrowingBook(string bookName)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Debtors.DebtorID, Debtors.DebtorName " +
                           "FROM Borrowings " +
                           "JOIN Debtors ON Borrowings.DebtorID = Debtors.DebtorID " +
                           "JOIN Books ON Borrowings.BookID = Books.BookID " +
                           "WHERE Books.BookName = @BookName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookName", bookName);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Debtor ID: {reader["DebtorID"]}, Debtor Name: {reader["DebtorName"]}");
            }
        }
    }

    public static void GetAuthorsOfBook(string bookName)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Authors.AuthorName " +
                           "FROM Authors " +
                           "JOIN Books ON Authors.AuthorID = Books.AuthorID " +
                           "WHERE Books.BookName = @BookName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookName", bookName);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Author Name: {reader["AuthorName"]}");
            }
        }
    }

    public static void GetBooksTakenAfterDate(DateTime borrowDate)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Books.BookName " +
                           "FROM Borrowings " +
                           "JOIN Books ON Borrowings.BookID = Books.BookID " +
                           "WHERE Borrowings.BorrowDate > @BorrowDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BorrowDate", borrowDate);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book Name: {reader["BookName"]}");
            }
        }
    }

    public static void GetPricesOfBooksInUserPossession(int debtorID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT Books.BookName, Books.Price " +
                           "FROM Books " +
                           "JOIN Borrowings ON Books.BookID = Borrowings.BookID " +
                           "WHERE Borrowings.DebtorID = @DebtorID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DebtorID", debtorID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book Name: {reader["BookName"]}, Price: {reader["Price"]}");
            }
        }
    }

    public static void GetBooksAbovePriceAndPublishedBeforeDate(decimal price, DateTime publishDate)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string query = "SELECT BookName, Price " +
                           "FROM Books " +
                           "WHERE Price > @Price AND PublishDate <= @PublishDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@PublishDate", publishDate);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Book Name: {reader["BookName"]}, Price: {reader["Price"]}");
            }
        }
    }

    /// <summary>
    /// /////////////
    /// </summary>
    /// <returns></returns>

    public static int GetNumberOfBooks()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("GetNumberOfBooks", connection);
            command.CommandType = CommandType.StoredProcedure;
            return (int)command.ExecuteScalar();
        }
    }

    public static decimal GetTotalBookPrice()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("GetTotalBookPrice", connection);
            command.CommandType = CommandType.StoredProcedure;
            return (decimal)command.ExecuteScalar();
        }
    }

    public static int GetTotalPagesByAuthor(int authorID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("GetTotalPagesByAuthor", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@AuthorID", authorID);
            return (int)command.ExecuteScalar();
        }
    }
}