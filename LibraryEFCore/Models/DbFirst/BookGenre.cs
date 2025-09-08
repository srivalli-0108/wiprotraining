namespace LibraryEFCore.Models.DbFirst
{
    public partial class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }

        // ✅ These are required for navigation
        public virtual Book Book { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}
