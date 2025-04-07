using System;
using Microsoft.EntityFrameworkCore;
using CLDVapp.Models;

namespace CLDVapp.Models
{ 
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Venue> Venue { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }

    
}
