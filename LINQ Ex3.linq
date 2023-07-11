<Query Kind="Statements" />

var firms = new List<Firma>
{
    new Firma { 
        Name = "Acme Inc.", 
        DateOfFoundation = new DateTime(1990, 1, 1), 
        BusinessProfile = "IT", 
        DirectorName = "John Smith", 
        NumberOfEmployees = 100, 
        Address = "123 Main St. London",
        Employees = new List<Employee> {
            new Employee {FullName = "Alice Johnson", Position = "Software Engineer", PhoneNumber = "233-456-7890", Email = "alice@acme.com", Salary = 7500},
            new Employee {FullName = "Bob Smith", Position = "Project Manager", PhoneNumber = "555-555-5555", Email = "dibob@acme.com", Salary = 9000}
        }
    },
    new Firma { 
        Name = "STEP", 
        DateOfFoundation = new DateTime(1995, 1, 1), 
        BusinessProfile = "IT", 
        DirectorName = "Dmitro Korchevsky", 
        NumberOfEmployees = 200, 
        Address = "1/3 Stanislavskoho St. Nikopol",
        Employees = new List<Employee> {
            new Employee {FullName = "Charlie Lee", Position = "Frontend Developer", PhoneNumber = "777-777-7777", Email = "charlie@step.com", Salary = 6000},
            new Employee {FullName = "David Kim", Position = "Database Administrator", PhoneNumber = "999-999-9999", Email = "david@step.com", Salary = 8000}
        }
    },
	    new Firma { 
        Name = "Black & White", 
        DateOfFoundation = new DateTime(1995, 1, 1), 
        BusinessProfile = "Walter White", 
        DirectorName = "Marketing", 
        NumberOfEmployees = 200, 
        Address = "1/3 Stanislavskoho St. Nikopol",
        Employees = new List<Employee> {
            new Employee {FullName = "Jane Doe", Position = "Project Manager", PhoneNumber = "777-777-7777", Email = "charlie@step.com", Salary = 6000},
            new Employee {FullName = "Lionel Doe", Position = "Database Administrator", PhoneNumber = "999-999-9999", Email = "david@step.com", Salary = 8000}
        }
    },
};

//=========1=========
Console.WriteLine(1);
var acmeEmployees = firms.Where(f => f.Name == "Acme Inc.").SelectMany(f => f.Employees);
foreach (var employee in acmeEmployees)
{
	Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.Salary:C}");
}
Console.WriteLine();

//=========2=========
Console.WriteLine(2);
var highPaidAcmeEmployees = firms.Where(f => f.Name == "Acme Inc.").SelectMany(f => f.Employees).Where(e => e.Salary > 8000);
foreach (var employee in highPaidAcmeEmployees)
{
	Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.Salary:C}");
}
Console.WriteLine();

//=========3=========
Console.WriteLine(3);
var managerEmployees = firms.Where(f => f.Employees.Any(e => e.Position == "Project Manager")).SelectMany(f => f.Employees);
foreach (var employee in managerEmployees)
{
    Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.Salary:C}");
}
Console.WriteLine();

//=========4=========
Console.WriteLine(4);
var phoneStartsWith23Employees = firms.SelectMany(f => f.Employees).Where(e => e.PhoneNumber.StartsWith("23"));
foreach (var employee in phoneStartsWith23Employees)
{
    Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.PhoneNumber}");
}
Console.WriteLine();

//=========5=========
Console.WriteLine(5);
var emailStartsWithDiEmployees = firms.SelectMany(f => f.Employees).Where(e => e.Email.StartsWith("di"));
foreach (var employee in emailStartsWithDiEmployees)
{
    Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.Email}");
}
Console.WriteLine();

//=========6=========
Console.WriteLine(6);
var lionelEmployees = firms.SelectMany(f => f.Employees).Where(e => e.FullName.Contains("Lione"));
foreach (var employee in lionelEmployees)
{
    Console.WriteLine($"{employee.FullName} ({employee.Position}): {employee.Email}");
}         

public class Firma
{
    public string Name { get; set; }
    public DateTime DateOfFoundation { get; set; }
    public string BusinessProfile { get; set; }
    public string DirectorName { get; set; }
    public int NumberOfEmployees { get; set; }
    public string Address { get; set; }
    public List<Employee> Employees { get; set; }
}

public class Employee
{
    public string FullName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}