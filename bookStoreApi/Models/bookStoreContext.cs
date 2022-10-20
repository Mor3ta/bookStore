using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bookStoreApi.Models
{
    public partial class bookStoreContext : DbContext
    {
        public bookStoreContext()
        {
        }

        public bookStoreContext(DbContextOptions<bookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookList> BookLists { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=56-1415\\SQLEXPRESS; Initial Catalog=bookStore; Trusted_Connection=false; User Id=developer; Password=Caasd21215@@; MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.ToTable("Author");

                entity.Property(e => e.Bio)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("bio");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBooks);

                entity.ToTable("Book");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Idiom)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopsis).IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Author1");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Genre");
            });

            modelBuilder.Entity<BookList>(entity =>
            {
                entity.HasKey(e => e.IdList);

                entity.ToTable("BookList");

                entity.Property(e => e.IdList).ValueGeneratedNever();

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.BookLists)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookList_status");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre);

                entity.ToTable("Genre");

                entity.Property(e => e.Genre1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Genre");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus);

                entity.ToTable("status");

                entity.Property(e => e.IdStatus).ValueGeneratedNever();

                entity.Property(e => e.Status1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
