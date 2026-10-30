using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RazorPagesDemo.Pages
{
    public class BookDetailModel : PageModel
    {
        private readonly string _jsonFilePath = "books.json";

        public Book Book { get; set; }

        public IActionResult OnGet(string id)
        {
            string jsonData = System.IO.File.ReadAllText(_jsonFilePath);
            var books = JsonSerializer.Deserialize<Book[]>(jsonData);

            if (int.TryParse(id, out int bookId))
            {
                Book = books.FirstOrDefault(b => b.Id == bookId);
            }
            else
            {
                return NotFound();
            }

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostDelete(string id)
        {
            string jsonData = System.IO.File.ReadAllText(_jsonFilePath);
            var books = JsonSerializer.Deserialize<List<Book>>(jsonData);

            var bookToRemove = books.FirstOrDefault(b => b.Id == int.Parse(id));
            if (bookToRemove == null)
            {
                return NotFound();
            }

            books.Remove(bookToRemove);

            string updatedJsonData = JsonSerializer.Serialize(books);
            System.IO.File.WriteAllText(_jsonFilePath, updatedJsonData);

            return RedirectToPage("/Index");
        }
    }
}
