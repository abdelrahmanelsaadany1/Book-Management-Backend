using Book_Management_Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Management_Backend
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

    }
}
