public class Author
{
    public int AuthorID { get; set; }
    public string? Name { get; set; }
    public string? Bio { get; set; }

    public List<Book> Books { get; set; } = new();
}
