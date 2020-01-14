using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.BookController
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;

        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(new { data = await context.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await context.Book.FindAsync(id);
            if (book is null) return Json(new { success = false, message = "Error hile deleting" });

            context.Remove(book);
            await context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}