using System;
using System.Collections.Generic;

namespace LibraryEFCore.Models.DbFirst
{
    public partial class Book
    {
        public Book()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;

        // ✅ ADD THIS:
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
