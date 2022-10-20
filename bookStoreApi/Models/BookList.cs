using System;
using System.Collections.Generic;

namespace bookStoreApi.Models
{
    public partial class BookList
    {
        public int IdList { get; set; }
        public int? IdBooks { get; set; }
        public int IdStatus { get; set; }

        public virtual Status IdStatusNavigation { get; set; } = null!;
    }
}
