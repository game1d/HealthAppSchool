using HealthAppSchool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Data
{
    public class HealthAppDatabase
    {
        DataContext _context;

        public HealthAppDatabase(DataContext dataContext)
        {
            _context = dataContext;
        }
        // klanttoken crud
        public KlantToken GetKlantToken() 
        { 
            KlantToken result = new KlantToken();
            
            result = _context.KlantTokenDb.FirstOrDefault();
            return result;
        }
        public async void CreateKlantToken(Klant klant, string wachtwoord)
        {
            KlantToken klantToken = new KlantToken(klant,wachtwoord);

            await _context.KlantTokenDb.AddAsync(klantToken);
            await _context.SaveChangesAsync();
        }
        public async void DeleteKlantToken(KlantToken klantToken)
        {
            _context.KlantTokenDb.Remove(klantToken);
            await _context.SaveChangesAsync();
        }

        //klant crud
        public async Task<Klant> GetKlantOnEmail(string email)
        {
            Klant Result = new Klant();
            List<Klant> klanten = await _context.KlantDb.ToListAsync();
            foreach (Klant k in klanten)
            {
                if (k.Email == email)
                { Result = k; break; }
            }
            return Result;
        }

        //Nieuwe Klant aanmaken en opslaan in de database
        public async void CreateKlant(Klant klant)
        {
            await _context.KlantDb.AddAsync(klant);
            await _context.SaveChangesAsync();
        }

        //fysieke activiteit en verbranding crud

        //voeding en voedingswaarde crud

        //slaappatroon crud

        //patient crud

        //medicijn en medicijn afspraak crud

        //kennisclips en stressmanagement crud
        public async Task<List<KennisClip>> GetKennisClips()
        {
            List<KennisClip> result = new List<KennisClip>();
            result = await _context.KennisClipDb.ToListAsync();
            return result;
        }
        public async Task<List<StressManagement>> GetStressManagement()
        {
            List<StressManagement> result = new List<StressManagement>();
            result = await _context.stressManagementDb.ToListAsync();
            return result;
        }

        //consulent crud

        //afspraak crud
    }
}
