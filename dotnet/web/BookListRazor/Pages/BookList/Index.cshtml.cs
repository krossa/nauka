using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public IEnumerable<Book> Books { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task OnGetAsync()
        {
            Books = await context.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await context.Book.FindAsync(id);
            if(book is null) return NotFound();

            context.Remove(book);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
