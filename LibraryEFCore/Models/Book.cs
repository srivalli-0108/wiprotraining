public class Book
{
    public int BookID { get; set; }
    public string? Title { get; set; }

    // Navigation
    public int AuthorID { get; set; }
    public Author? Author { get; set; }

    public List<BookGenre> BookGenres { get; set; } = new();
}
