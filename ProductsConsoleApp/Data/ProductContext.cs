using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed class ProductContext : DbContext
    {
        public ProductContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=ProductDB");
        }
        
        public DbSet<Product> Products { get; set; }
    }
}