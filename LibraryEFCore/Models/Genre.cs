public class Genre
{
    public int GenreID { get; set; }
    public string? Name { get; set; }

    public List<BookGenre> BookGenres { get; set; } = new();
}

public class BookGenre
{
    public int BookID { get; set; }
    public Book? Book { get; set; }

    public int GenreID { get; set; }
    public Genre? Genre { get; set; }
}
