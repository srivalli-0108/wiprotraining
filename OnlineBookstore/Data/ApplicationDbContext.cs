using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Book> Books { get; set; }
        // Add more DbSets as needed
    }
}
