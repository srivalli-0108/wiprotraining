using LibrarySystem.Models; // Required to access Book and Genre

namespace LibrarySystem.Models
{
    public class BookGenre
    {
        public int BookID { get; set; }
        public Book? Book { get; set; }

        public int GenreID { get; set; }
        public Genre? Genre { get; set; }
    }
}
