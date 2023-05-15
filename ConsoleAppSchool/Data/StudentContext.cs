using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StudentContext : DbContext
    {
        public StudentContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=StudentDB");
        }
        
        public DbSet<Students> Students { get; set; }
    }
}