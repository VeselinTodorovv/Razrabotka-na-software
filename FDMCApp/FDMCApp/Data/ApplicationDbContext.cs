using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FDMCApp.Models;

namespace FDMCApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FDMCApp.Models.Cat> Cat { get; set; }
        public DbSet<FDMCApp.Models.Dog> Dog { get; set; }
    }
}
