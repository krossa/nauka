using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Book Book { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task OnGet(int id)
        {
            Book = await context.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var book = await context.Book.FindAsync(Book.Id);
                book.Author = Book.Author;
                book.Name = Book.Name;
                book.ISBN = Book.ISBN;
                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
