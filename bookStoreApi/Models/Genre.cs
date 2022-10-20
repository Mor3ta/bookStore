using System;
using System.Collections.Generic;

namespace bookStoreApi.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int IdGenre { get; set; }
        public string? Genre1 { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
