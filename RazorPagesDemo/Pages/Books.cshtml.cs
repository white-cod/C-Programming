using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RazorPagesDemo.Pages
{
    public class BooksModel : PageModel
    {
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            string jsonData = System.IO.File.ReadAllText("books.json");
            Books = JsonSerializer.Deserialize<List<Book>>(jsonData);
        }
    }
}