using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelDestinationAPI.Models;

namespace TravelDestinationAPI.Data
{
    public class TravelDestinationAPIContext : DbContext
    {
        public TravelDestinationAPIContext (DbContextOptions<TravelDestinationAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Destination> Destination { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>(entity =>
            {
                entity.Property(p => p.CityName).IsRequired();
                entity.Property(p => p.Country).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(200);
                entity.Property(p => p.Rating).HasDefaultValue(3);                
            });
        }
    }
}
