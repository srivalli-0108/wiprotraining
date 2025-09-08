using System.ComponentModel.DataAnnotations;

public class Book
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [CustomIsbn]
    public string ISBN { get; set; }

    [Range(0.01, 1000.00, ErrorMessage = "Price must be between $0.01 and $1000")]
    public decimal Price { get; set; }

    private class CustomIsbnAttribute : Attribute
    {
    }
}
