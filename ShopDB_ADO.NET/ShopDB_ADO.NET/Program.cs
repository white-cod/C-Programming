using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-C85D6OJ\\SQLEXPRESS;Database=ShopDB;Integrated Security=True;";

        DataSet ShopDB = new DataSet();

        DataTable Sellers = new DataTable("Sellers");
        DataTable Customers = new DataTable("Customers");
        DataTable Sales = new DataTable("Sales");

        ShopDB.Tables.Add(Sellers);
        ShopDB.Tables.Add(Customers);
        ShopDB.Tables.Add(Sales);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlDataAdapter sellersAdapter = new SqlDataAdapter("SELECT * FROM Sellers", connection);
            SqlDataAdapter customersAdapter = new SqlDataAdapter("SELECT * FROM Customers", connection);
            SqlDataAdapter salesAdapter = new SqlDataAdapter("SELECT * FROM Sales", connection);

            sellersAdapter.Fill(Sellers);
            customersAdapter.Fill(Customers);
            salesAdapter.Fill(Sales);

            Sellers.PrimaryKey = new DataColumn[] { Sellers.Columns["ID"] };
            Customers.PrimaryKey = new DataColumn[] { Customers.Columns["ID"] };
            Sales.PrimaryKey = new DataColumn[] { Sales.Columns["ID"] };
        }

        ForeignKeyConstraint fkSeller = new ForeignKeyConstraint("FK_Seller", Sellers.Columns["ID"], Sales.Columns["IDSeller"]);
        ForeignKeyConstraint fkCustomer = new ForeignKeyConstraint("FK_Customer", Customers.Columns["ID"], Sales.Columns["IDCustomer"]);
        Sales.Constraints.Add(fkSeller);
        Sales.Constraints.Add(fkCustomer);

        Console.WriteLine("Tables in Data Set: " + ShopDB.Tables.Count);
        Console.WriteLine("Tables in Data Set:");

        foreach (DataTable table in ShopDB.Tables)
        {
            Console.WriteLine(table.TableName);
            Console.WriteLine(new string('-', 30));

            foreach (DataColumn col in table.Columns)
            {
                Console.Write(col.ColumnName.PadRight(20));
            }

            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item.ToString().PadRight(20));
                }
                Console.WriteLine();
            }

            Console.WriteLine(new string('-', 30));
        }
    }
}