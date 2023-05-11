using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirlineTickets.Models;

namespace AirlineTickets.Data
{
    public class AirlineTicketsContext : DbContext
    {
        public AirlineTicketsContext (DbContextOptions<AirlineTicketsContext> options)
            : base(options) { }

        public DbSet<Client> Client { get; set; }

        public DbSet<Flight> Flight { get; set; }
        
        public DbSet<Reservation> Planes { get; set; }

        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<AirlineTickets.Models.Plane> Plane { get; set; }
    }
}