using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAuto.Entities;

namespace WebAuto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
            Database.EnsureCreated();
        }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}