using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RazorPagesDemo.Pages
{
    public class EditBookModel : PageModel
    {
        private readonly string _jsonFilePath = "books.json";

        [BindProperty]
        public Book Book { get; set; }

        public IActionResult OnGet(string id)
        {
            string jsonData = System.IO.File.ReadAllText(_jsonFilePath);
            var books = JsonSerializer.Deserialize<List<Book>>(jsonData);

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

        public IActionResult OnPost()
        {
            try
            {
                string jsonData = System.IO.File.ReadAllText(_jsonFilePath);
                var books = JsonSerializer.Deserialize<List<Book>>(jsonData);

                var index = books.FindIndex(b => b.Id == Book.Id);
                if (index == -1)
                {
                    return NotFound();
                }

                books[index] = Book;

                string updatedJsonData = JsonSerializer.Serialize(books);

                System.IO.File.WriteAllText(_jsonFilePath, updatedJsonData);

                return RedirectToPage("/BookDetail", new { id = Book.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
