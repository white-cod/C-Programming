using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

class Program
{
    private const string ConnectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=LibraryDB;Integrated Security=True;";

    static void Main()
    {
        Console.WriteLine($"Вывести список должников:");
        PrintDebtors();

        Console.WriteLine($"\nВывести список авторов книги #3:");
        PrintAuthorsOfBook(3);

        Console.WriteLine($"\nВывести список доступных книг:");
        PrintAvailableBooks();

        Console.WriteLine($"\nВывести список книг, имеющихся у пользователя #2:");
        PrintBooksForUser(2);
    }

    private static void PrintDebtors()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Debtors";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"DebtorID: {reader["DebtorID"]}, DebtorName: {reader["DebtorName"]}, Debt: {reader["Debt"]}");
            }
        }
    }

    private static void PrintAuthorsOfBook(int bookID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = @"SELECT Authors.AuthorName 
                             FROM Authors 
                             JOIN BooksAuthors ON Authors.AuthorID = BooksAuthors.AuthorID
                             WHERE BooksAuthors.BookID = @BookID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookID", bookID);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Author: {reader["AuthorName"]}");
            }
        }
    }

    private static void PrintAvailableBooks()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = "SELECT * FROM Books WHERE IsAvailable = 1";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"BookID: {reader["BookID"]}, BookName: {reader["BookName"]}");
            }
        }
    }

    private static void PrintBooksForUser(int userID)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string query = @"SELECT Books.BookID, Books.BookName 
                             FROM Books 
                             JOIN Borrowings ON Books.BookID = Borrowings.BookID
                             WHERE Borrowings.DebtorID = @DebtorID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DebtorID", userID);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"BookID: {reader["BookID"]}, BookName: {reader["BookName"]}");
            }
        }
    }
}
