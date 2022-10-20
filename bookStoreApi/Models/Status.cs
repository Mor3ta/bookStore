using System;
using System.Collections.Generic;

namespace bookStoreApi.Models
{
    public partial class Status
    {
        public Status()
        {
            BookLists = new HashSet<BookList>();
        }

        public int IdStatus { get; set; }
        public string Status1 { get; set; } = null!;

        public virtual ICollection<BookList> BookLists { get; set; }
    }
}
