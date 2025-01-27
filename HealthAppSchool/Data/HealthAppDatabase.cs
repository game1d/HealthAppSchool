using HealthAppSchool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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
        public async void CreateFysiekeActiviteit(FysiekeActiviteit fa)
        {
            await _context.fysiekeActiviteitDb.AddAsync(fa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FysiekeActiviteit>> GetFysiekeActiviteiten()
        {
            List<FysiekeActiviteit> activiteiten = await _context.fysiekeActiviteitDb.ToListAsync();
            return activiteiten;
        }

        //voeding en voedingswaarde crud

        //slaappatroon crud

        //patient crud

        //medicijn en medicijn afspraak crud
        public async Task<List<Medicijn>>GetPatientByPatientId(int patientId)
        {
            return await _context.medicijnDb.Where(m => m.PatientId == patientId).ToListAsync();
        }
        public async Task<List<Medicijn>> GetMedicijnsIdAsync()
        {
            return await _context.medicijnDb.ToListAsync();
        }
        
        public async Task AddMedicijnAsync(Medicijn medicijn)
        {
             _context.medicijnDb.Add(medicijn);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMedicijn(int medicijnId)
        {
            var medicijn = await _context.medicijnDb.FirstOrDefaultAsync(m =>m.MedicijnId ==medicijnId);
            await _context.SaveChangesAsync();
        }

        //MedicijnHerinnering
        public async Task<List<MedicijnHerinnering>> GetMedicijnHerinneringByPatientId(int patientId)
        {
            return await _context.Set<MedicijnHerinnering>().Where(mh => mh.PatientId == patientId).ToListAsync();
        }
        public async Task<MedicijnHerinnering> GetMedicijnHerinneringById(int HerinneringId)
        {
            return await _context.Set<MedicijnHerinnering>().FirstOrDefaultAsync(mh => mh.MedicijnHerinneringId == HerinneringId);
        }
        public async Task AddMedicijnHerinnering(MedicijnHerinnering medicijnherinnering)
        {
            await _context.Set<MedicijnHerinnering>().AddAsync(medicijnherinnering);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMedicijnHerinnering(int herinneringId)
        {
            var herinnering = await _context.Set<MedicijnHerinnering>().FirstOrDefaultAsync(mh => mh.MedicijnHerinneringId == herinneringId);
            await _context.SaveChangesAsync();
        }


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

        internal async Task<IEnumerable> GetMedicijnByIdAsync()
        {
            throw new NotImplementedException();
        }

        //consulent crud

        //afspraak crud
    }
}
