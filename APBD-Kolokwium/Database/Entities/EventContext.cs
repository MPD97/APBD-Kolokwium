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
        public DbSet<ArtistEvent> ArtistEvents { get; set; }
        public DbSet<EventOrganiser> EventOrganisers { get; set; }

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

            modelBuilder.Entity<Artist>()
              .HasMany(a => a.ArtistEvents)
              .WithOne(a => a.Artist);

            // ArtistEvent
            modelBuilder.Entity<ArtistEvent>()
            .HasKey(a => new { a.IdArtist, a.IdEvent });

            modelBuilder.Entity<ArtistEvent>()
                .Property(a => a.PerformanceDate)
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

            modelBuilder.Entity<Event>()
               .HasMany(a => a.ArtistEvents)
               .WithOne(a => a.Event);

            modelBuilder.Entity<Event>()
               .HasMany(a => a.EventOrganisers)
               .WithOne(a => a.Event);

            // EventOrganiser
            modelBuilder.Entity<EventOrganiser>()
               .HasKey(a => new { a.IdEvent, a.IdOrganiser });


            // Organiser
            modelBuilder.Entity<Organiser>()
                .HasKey(a => a.IdOrganiser);

            modelBuilder.Entity<Organiser>()
                .Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired(true);

            modelBuilder.Entity<Organiser>()
                .HasMany(a => a.EventOrganisers)
                .WithOne(a => a.Organiser);


            modelBuilder.Entity<Artist>()
               .HasData(new Artist
               {
                   IdArtist = 1,
                   Nickname = "test",
               },
               new Artist
               {
                IdArtist = 2,
                   Nickname = "test",
               });

            modelBuilder.Entity<Event>()
             .HasData(new Event
             {
                IdEvent = 1,
                Name = "Tevent",
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(-5),
             },
             new Event
             {
                 IdEvent = 2,
                 Name = "Tevent",
                 StartDate = DateTime.Now.AddDays(5),
                 EndDate = DateTime.Now.AddDays(15),
             });

            modelBuilder.Entity<ArtistEvent>()
            .HasData(new ArtistEvent
            {
               IdArtist = 1,
               IdEvent = 1,
               PerformanceDate = DateTime.Now.AddDays(-7),
            },
            new ArtistEvent
            {
                IdArtist = 2,
                IdEvent = 2,
                PerformanceDate = DateTime.Now.AddDays(10),
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
