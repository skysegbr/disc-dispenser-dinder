using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinderDisc.Models;

namespace FinderDisc.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<FinderDisc.Models.Disc> Disc { get; set; }        
        public DbSet<FinderDisc.Models.Band> Band { get; set; }
        public DbSet<FinderDisc.Models.Dispenser> Dispenser { get; set; }
        public DbSet<FinderDisc.Models.Music> Music { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disc>().ToTable("Disc");
            modelBuilder.Entity<Band>().ToTable("Band");
            modelBuilder.Entity<Dispenser>().ToTable("Dispenser");
            modelBuilder.Entity<Music>().ToTable("Music");
        }

    }
}
