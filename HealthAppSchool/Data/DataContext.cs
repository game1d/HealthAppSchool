using HealthAppSchool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Klant> KlantDb { get; set; }
        public DbSet<KlantToken> KlantTokenDb { get;set;}

        public DbSet<KennisClip> KennisClipDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klant>().HasData(
                new Klant("JanMango@live.nl", "Wachtwoord1") { KlantId = 1, KlantName = "Jan Mango"  }
                );

            modelBuilder.Entity<KennisClip>().HasData(
                new KennisClip() { KennisClipId=1, Name="clip1", Description="Dit is kennisclip 1"},
                new KennisClip() { KennisClipId = 2, Name = "clip2", Description = "Dit is kennisclip 2" },
                new KennisClip() { KennisClipId = 3, Name = "clip3", Description = "Dit is kennisclip 3" }
                );
            
        }
    }

}
