using BookShopSchool.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopSchool.Data
{
    public class BookShopSchoolContext : DbContext
    {
        public BookShopSchoolContext() { }

        public BookShopSchoolContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AuthorBook>().HasKey(x => new { x.AuthorId, x.BookId });
        }
    }
}