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
        public EventContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected EventContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasKey(a => a.IdArtist);

            modelBuilder.Entity<Artist>()
                .Property(a => a.Nickname)
                .HasMaxLength(30)
                .IsRequired(true);


            base.OnModelCreating(modelBuilder);
        }
    }
}
