using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.Entities
{
    public class EventContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        
        public EventContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected EventContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Artist
            modelBuilder.Entity<Artist>()
                .HasKey(a => a.IdArtist);

            modelBuilder.Entity<Artist>()
                .Property(a => a.Nickname)
                .HasMaxLength(30)
                .IsRequired(true);

            // Event
            modelBuilder.Entity<Event>()
                .HasKey(a => a.IdEvent);

            modelBuilder.Entity<Event>()
               .Property(a => a.Name)
               .HasMaxLength(100)
               .IsRequired(true);

            modelBuilder.Entity<Event>()
               .Property(a => a.StartDate)
               .IsRequired(true);

            modelBuilder.Entity<Event>()
               .Property(a => a.EndDate)
               .IsRequired(true);

            // Organiser
            modelBuilder.Entity<Organiser>()
                .HasKey(a => a.IdOrganiser);

            modelBuilder.Entity<Organiser>()
                .Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
