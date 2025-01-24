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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klant>().HasData(
                new Klant( "Jan", "Mango","JanMango@live.nl", "Wachtwoord1") { KlantId = 1}
                );
            
        }
    }

}
