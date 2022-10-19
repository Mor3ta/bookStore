using books_store.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using bookStoreApi.Models;
using System.Diagnostics;

namespace booksContext.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
        {

        }
        public DbSet<Books> Books { get; set; } = null!;
        public DbSet<Author> Author { get; set; } = null!;
        public DbSet<Store> Store { get; set; } = null!;

    
    }
}
