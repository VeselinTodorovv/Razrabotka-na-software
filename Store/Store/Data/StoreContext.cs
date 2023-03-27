using Microsoft.EntityFrameworkCore;
using Store.Data.Models;

namespace Store.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext() { }

        protected StoreContext(DbContextOptions options) :base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.StudentId, x.SubjectId });
        }
    }
}