using Microsoft.EntityFrameworkCore;

namespace mvc.Db
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Note> Notes { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            
        }
    } 
}
