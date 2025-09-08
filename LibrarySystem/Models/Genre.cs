namespace LibrarySystem.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string? Name { get; set; }
        public required ICollection<Book> Books { get; set; }
    }
}
