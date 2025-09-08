using System;
using System.Collections.Generic;

namespace LibraryEFCore.Models.DbFirst
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; } = null!;

        // ✅ ADD THIS:
        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
