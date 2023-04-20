using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FirmContext : DbContext
    {
        public FirmContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=.; Integrated Security=true; Database=FirmDB");
        }
        
        public DbSet<Employee> Employees { get; set; }    
    }
}