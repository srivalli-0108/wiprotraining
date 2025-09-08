using Microsoft.EntityFrameworkCore;

namespace LibraryEFCore.Models.DbFirst
{
    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<BookGenre> BookGenres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuthorId);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Bio).HasMaxLength(1000);
            });

            // Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);
                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(e => e.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(e => e.AuthorId);
            });

            // Genre
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            // BookGenre (Join Table)
            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.GenreId });

                entity.HasOne(e => e.Book)
                      .WithMany(b => b.BookGenres)
                      .HasForeignKey(e => e.BookId);

                entity.HasOne(e => e.Genre)
                      .WithMany(g => g.BookGenres)
                      .HasForeignKey(e => e.GenreId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
