<Query Kind="Statements" />

var firms = new List<Firma>
{
    new Firma { Name = "Acme Inc.", DateOfFoundation = new DateTime(1990, 1, 1), BusinessProfile = "IT", DirectorName = "John Smith", NumberOfEmployees = 100, Address = "123 Main St. London" },
	new Firma { Name = "STEP", DateOfFoundation = new DateTime(1995, 1, 1), BusinessProfile = "IT", DirectorName = "Dmitro Korchevsky", NumberOfEmployees = 200, Address = "1/3 Stanislavskoho St. Nikopol" },
    new Firma { Name = "ABC Marketing", DateOfFoundation = new DateTime(1980, 1, 1), BusinessProfile = "Marketing", DirectorName = "Jane Doe", NumberOfEmployees = 50, Address = "456 Second St. Rome" },
	new Firma { Name = "ABC FoodMarketing", DateOfFoundation = new DateTime(1985, 1, 1), BusinessProfile = "Marketing", DirectorName = "Jon Doe", NumberOfEmployees = 40, Address = "460 Second St. Rome" },
	new Firma { Name = "Silpo", DateOfFoundation = new DateTime(1985, 1, 1), BusinessProfile = "Marketing", DirectorName = "Walter White", NumberOfEmployees = 40, Address = "6A Krushelnytskoyi St. Dnipro" },
	new Firma { Name = "SilpoW", DateOfFoundation = new DateTime(2023, 1, 1), BusinessProfile = "Marketing", DirectorName = "Walter White", NumberOfEmployees = 40, Address = "7A Krushelnytskoyi St. Dnipro" },
	new Firma { Name = "Black & White", DateOfFoundation = new DateTime(2023, 1, 1), BusinessProfile = "Marketing", DirectorName = "Walter Black", NumberOfEmployees = 40, Address = "8A Krushelnytskoyi St. Dnipro" },
};

var itFirms = firms.Where(f => f.BusinessProfile == "IT");
var directors = firms.Select(f => f.DirectorName);

//=========1=========
var allFirms1 = from f in firms
               select new { f.Name, f.DateOfFoundation, f.BusinessProfile, f.DirectorName, f.NumberOfEmployees, f.Address };
foreach (var firm in allFirms1)
{
    Console.WriteLine($"Name: {firm.Name}, DateOfFoundation: {firm.DateOfFoundation}, BusinessProfile: {firm.BusinessProfile}, DirectorName: {firm.DirectorName}, NumberOfEmployees: {firm.NumberOfEmployees}, Address: {firm.Address}");
}
//=========2=========
var foodFirms1 = from f in firms
                where f.Name.Contains("Food")
                select f.Name;
foreach (var firm in foodFirms1)
{
    Console.WriteLine(firm);
}
//=========3=========
var marketingFirms1 = from f in firms
                     where f.BusinessProfile == "Marketing"
                     select f.Name;
foreach (var firm in marketingFirms1)
{
    Console.WriteLine(firm);
}
//=========4=========
var marketingOrITFirms1 = from f in firms
                         where f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT"
                         select f.Name;
foreach (var firm in marketingOrITFirms1)
{
    Console.WriteLine(firm);
}
//=========5=========
var largeFirms1 = from f in firms
                 where f.NumberOfEmployees > 100
                 select f.Name;
foreach (var firm in largeFirms1)
{
    Console.WriteLine(firm);
}
//=========6=========
var midSizedFirms1 = from f in firms
                    where f.NumberOfEmployees >= 100 && f.NumberOfEmployees <= 300
                    select f.Name;
foreach (var firm in midSizedFirms1)
{
    Console.WriteLine(firm);
}
//=========7=========
var londonFirms1 = from f in firms
                  where f.Address.Contains("London")
                  select f.Name;
foreach (var firm in londonFirms1)
{
    Console.WriteLine(firm);
}
//=========8=========
var whiteDirectorFirms1 = from f in firms
                         where f.DirectorName.EndsWith("White")
                         select f.Name;
foreach (var firm in whiteDirectorFirms1)
{
    Console.WriteLine(firm);
}
//=========9=========
var oldFirms1 = from f in firms
               where DateTime.Now.Subtract(f.DateOfFoundation).TotalDays > 730
               select f.Name;
foreach (var firm in oldFirms1)
{
    Console.WriteLine(firm);
}
//=========10=========
var recentlyFoundedFirms1 = from f in firms
                           where DateTime.Now.Subtract(f.DateOfFoundation).TotalDays < 123
                           select f.Name;
foreach (var firm in recentlyFoundedFirms1)
{
    Console.WriteLine(firm);
}
//=========11=========
var blackDirectorWhiteNameFirms1 = from f in firms
                                  where f.DirectorName.EndsWith("Black") && f.Name.Contains("White")
                                  select f.Name;
foreach (var firm in blackDirectorWhiteNameFirms1)
{
    Console.WriteLine(firm);
}

//Синтаксис методов расширений.

//=========1=========
var allFirms = firms.Select(f => new { f.Name, f.DateOfFoundation, f.BusinessProfile, f.DirectorName, f.NumberOfEmployees, f.Address });
foreach (var firm in allFirms)
{
    Console.WriteLine($"Name: {firm.Name}, DateOfFoundation: {firm.DateOfFoundation}, BusinessProfile: {firm.BusinessProfile}, DirectorName: {firm.DirectorName}, NumberOfEmployees: {firm.NumberOfEmployees}, Address: {firm.Address}");
}
//=========2=========
var foodFirms = firms.Where(f => f.Name.Contains("Food"));
foreach (var firm in foodFirms)
{
    Console.WriteLine(firm.Name);
}
//=========3=========
var marketingFirms = firms.Where(f => f.BusinessProfile == "Marketing");
foreach (var firm in marketingFirms)
{
    Console.WriteLine(firm.Name);
}
//=========4=========
var marketingOrITFirms = firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT");
foreach (var firm in marketingOrITFirms)
{
    Console.WriteLine(firm.Name);
}
//=========5=========
var largeFirms = firms.Where(f => f.NumberOfEmployees > 100);
foreach (var firm in largeFirms)
{
    Console.WriteLine(firm.Name);
}
//=========6=========
var midSizedFirms = firms.Where(f => f.NumberOfEmployees >= 100 && f.NumberOfEmployees <= 300);
foreach (var firm in midSizedFirms)
{
    Console.WriteLine(firm.Name);
}
//=========7=========
var londonFirms = firms.Where(f => f.Address.Contains("London"));
foreach (var firm in londonFirms)
{
    Console.WriteLine(firm.Name);
}
//=========8=========
var whiteDirectorFirms = firms.Where(f => f.DirectorName.EndsWith("White"));
foreach (var firm in whiteDirectorFirms)
{
    Console.WriteLine(firm.Name);
}
//=========9=========
var oldFirms = firms.Where(f => DateTime.Now.Subtract(f.DateOfFoundation).TotalDays > 730);
foreach (var firm in oldFirms)
{
    Console.WriteLine(firm.Name);
}
//=========10=========
var recentlyFoundedFirms = firms.Where(f => DateTime.Now.Subtract(f.DateOfFoundation).TotalDays < 123);
foreach (var firm in recentlyFoundedFirms)
{
    Console.WriteLine(firm.Name);
}
//=========11=========
var blackDirectorWhiteNameFirms = firms.Where(f => f.DirectorName.EndsWith("Black") && f.Name.Contains("White"));
foreach (var firm in blackDirectorWhiteNameFirms)
{
    Console.WriteLine(firm.Name);
}

public class Firma
{
    public string Name { get; set; }
    public DateTime DateOfFoundation { get; set; }
    public string BusinessProfile { get; set; }
    public string DirectorName { get; set; }
    public int NumberOfEmployees { get; set; }
    public string Address { get; set; }
}
