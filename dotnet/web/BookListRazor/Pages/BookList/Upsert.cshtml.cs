using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Book Book { get; set; }

        public UpsertModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id is null) return Page();

            Book = await context.Book.FindAsync(id);
            if (Book is null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    await context.AddAsync(Book);
                }
                else
                {
                    context.Book.Update(Book);
                }

                await context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
