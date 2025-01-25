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
        public DbSet<Patient> PatientDb { get; set; }
        public DbSet<KlantToken> KlantTokenDb { get; set; }
        
        public DbSet<Medicijn> medicijnDb {  get; set; }

        public DbSet<FysiekeActiviteit> fysiekeActiviteitDb { get; set; }

        public DbSet<KennisClip> KennisClipDb { get; set; }
        public DbSet<StressManagement> stressManagementDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klant>().HasData(
                new Klant("Jan", "Mango", "JanMango@live.nl", "Wachtwoord1") { KlantId = 1 }
                );

            modelBuilder.Entity<KennisClip>().HasData(
                new KennisClip() { KennisClipId = 1, Name = "clip1", Description = "Dit is kennisclip 1", Url = "url1" },
                new KennisClip() { KennisClipId = 2, Name = "clip2", Description = "Dit is kennisclip 2", Url = "url2" },
                new KennisClip() { KennisClipId = 3, Name = "clip3", Description = "Dit is kennisclip 3", Url = "url3" }
                );
            modelBuilder.Entity<Medicijn>().HasData(
                new Medicijn() { MedicijnId = 1, MedicijnNaam = "Paracetamol", PatientId=1 },
                new Medicijn() { MedicijnId = 2, MedicijnNaam = "Ibuprofen", PatientId = 1 },
                new Medicijn() { MedicijnId = 3, MedicijnNaam = "Rennie", PatientId = 1 }
                );
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { KlantId=1, PatientId=1, PatientName = "John" }
                );
            modelBuilder.Entity<StressManagement>().HasData(
                new StressManagement() { StressManagementId = 1, Name = "StressClip1", Description = "Dit is stressclip 1", Url = "url1" },
                new StressManagement() { StressManagementId = 2, Name = "StressClip2", Description = "Dit is stressclip 2", Url = "url2" }
                );

            modelBuilder.Entity<FysiekeActiviteit>().HasData(
                new FysiekeActiviteit() { FysiekeActiviteitId = 1, KlantId = 1, Datum = new DateOnly(2024, 8, 14), DuurMinuten = 30, SoortActiviteit = "Rennen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 2, KlantId = 1, Datum = new DateOnly(2024, 8, 14), DuurMinuten = 20, SoortActiviteit = "Zwemmen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 3, KlantId = 1, Datum = new DateOnly(2024, 8, 14), DuurMinuten = 15, SoortActiviteit = "Fietsen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 4, KlantId = 1, Datum = new DateOnly(2024, 8, 15), DuurMinuten = 20, SoortActiviteit = "Rennen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 5, KlantId = 1, Datum = new DateOnly(2024, 8, 15), DuurMinuten = 25, SoortActiviteit = "Zwemmen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 6, KlantId = 1, Datum = new DateOnly(2024, 8, 15), DuurMinuten = 45, SoortActiviteit = "Fietsen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 7, KlantId = 1, Datum = new DateOnly(2024, 8, 16), DuurMinuten = 30, SoortActiviteit = "Rennen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 8, KlantId = 1, Datum = new DateOnly(2024, 8, 16), DuurMinuten = 10, SoortActiviteit = "Rennen" },
                new FysiekeActiviteit() { FysiekeActiviteitId = 9, KlantId = 1, Datum = new DateOnly(2024, 8, 16), DuurMinuten = 30, SoortActiviteit = "Fietsen" }
                );

        }
    }

}
