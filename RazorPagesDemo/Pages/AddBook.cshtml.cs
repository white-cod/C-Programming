using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RazorPagesDemo.Pages
{
    public class AddBookModel : PageModel
    {
        private readonly string _jsonFilePath = "books.json";

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            string jsonData = System.IO.File.ReadAllText(_jsonFilePath);
            var books = JsonSerializer.Deserialize<List<Book>>(jsonData);

            int newId = 1;
            if (books.Count > 0)
            {
                newId = books[books.Count - 1].Id + 1;
            }

            Book.Id = newId;
            books.Add(Book);

            string updatedJsonData = JsonSerializer.Serialize(books);
            System.IO.File.WriteAllText(_jsonFilePath, updatedJsonData);

            return RedirectToPage("/Books");
        }
    }
}
