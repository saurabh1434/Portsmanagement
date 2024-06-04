using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PortsManagement.Models;

namespace MaritimeAPI.Data
{
    public class MaritimeContext : DbContext
    {
        public MaritimeContext(DbContextOptions<MaritimeContext> options) : base(options) { }

        public DbSet<Port> Ports { get; set; }
        public DbSet<Terminal> Terminals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Port>()
                .HasIndex(p => p.PortCode)
                .IsUnique();

            modelBuilder.Entity<Terminal>()
                .HasIndex(t => new { t.Name, t.PortCode })
                .IsUnique();

            // Seed data
            modelBuilder.Entity<Port>().HasData(
                new Port { PortCode = "PORT1", Name = "Port One", AddedDate = DateTime.UtcNow, LastEditedDate = DateTime.UtcNow },
                new Port { PortCode = "PORT2", Name = "Port Two", AddedDate = DateTime.UtcNow, LastEditedDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Terminal>().HasData(
                new Terminal { Id = 1, Name = "Terminal 1A", PortCode = "PORT1", Latitude = 10.0, Longitude = 20.0, IsActive = true, AddedDate = DateTime.UtcNow, LastEditedDate = DateTime.UtcNow },
                new Terminal { Id = 2, Name = "Terminal 2A", PortCode = "PORT2", Latitude = 30.0, Longitude = 40.0, IsActive = true, AddedDate = DateTime.UtcNow, LastEditedDate = DateTime.UtcNow }
            );
        }
    }
}