using System;
using System.Collections.Generic;

namespace bookStoreApi.Models
{
    public partial class Book
    {
        public int IdBooks { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Sinopsis { get; set; }
        public string? Idiom { get; set; }
        public int IdGenre { get; set; }
        public int? Pages { get; set; }
        public int IdAuthor { get; set; }
        public virtual Author IdAuthorNavigation { get; set; } = null!;
        public virtual Genre IdGenreNavigation { get; set; } = null!;
    }
}
