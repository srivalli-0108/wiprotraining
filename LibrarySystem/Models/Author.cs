using LibrarySystem.Models;

public class Author
{
    public int AuthorID { get; set; }
    public string? Name { get; set; }
    public string? Bio { get; set; }

    public required ICollection<Book> Books { get; set; }
}
