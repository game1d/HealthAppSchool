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
        public async Task UpdateKlantTokenEmail(KlantToken KlantToken, string Email)
        {
            KlantToken klantToken = KlantToken;

            klantToken.KlantEmail = Email;
            _context.KlantTokenDb.Update(klantToken);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateKlantTokenWachtwoord(KlantToken KlantToken, string wachtwoord)
        {
            KlantToken klantToken = KlantToken;

            klantToken.KlantWachtwoord = wachtwoord;
            _context.KlantTokenDb.Update(klantToken);
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

        public async Task<Klant> GetKlantOnId(int Id)
        {
            Klant Result = new Klant();
            List<Klant> klanten = await _context.KlantDb.ToListAsync();
            foreach (Klant k in klanten)
            {
                if (k.KlantId == Id)
                { Result = k; break; }
            }
            return Result;
        }

        public async Task UpdateKlantVoornaam(int KlantId,string nieuweVoornaam)
        {
            Klant klant = new Klant();
            klant = await GetKlantOnId(KlantId);
            klant.Voornaam = nieuweVoornaam;
            _context.KlantDb.Update(klant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateKlantAchternaam(int KlantId, string nieuweAchternaam)
        {
            Klant klant = new Klant();
            klant = await GetKlantOnId(KlantId);
            klant.Achternaam = nieuweAchternaam;
            _context.KlantDb.Update(klant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateKlantEmail(int KlantId, string Email)
        {
            Klant klant = new Klant();
            klant = await GetKlantOnId(KlantId);
            klant.Email = Email;
            _context.KlantDb.Update(klant);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateKlantWachtWoord(int KlantId, string Wachtwoord)
        {
            Klant klant = new Klant();
            klant = await GetKlantOnId(KlantId);
            klant.WachtWoord = Wachtwoord;
            _context.KlantDb.Update(klant);
            await _context.SaveChangesAsync();
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

        public async Task<List<FysiekeActiviteit>> GetFysiekeActiviteitenOnKlant(int klantId)
        {
            List<FysiekeActiviteit> result= new List<FysiekeActiviteit>();
            List<FysiekeActiviteit> activiteiten = await _context.fysiekeActiviteitDb.ToListAsync();
            foreach (FysiekeActiviteit act  in activiteiten)
            {
                if (act.KlantId == klantId)
                {
                    result.Add(act);
                }
            }
            return result;
        }

        public async void DeleteFysiekeActiviteit(FysiekeActiviteit fysiekeActiviteit)
        {
            _context.fysiekeActiviteitDb.Remove(fysiekeActiviteit);
            await _context.SaveChangesAsync();
            
        }

        //voeding en voedingswaarde crud

        public async Task<List<VoedselInname>> GetVoedselInnamesOnKlant(int klantId)
        {

            List<VoedselInname> result = new List<VoedselInname>();
            List<VoedselInname> voedselInnames = await _context.VoedselInnamesDb.ToListAsync();

            foreach (VoedselInname vi in voedselInnames)
            {
                if (vi.KlantId == klantId)
                {
                    result.Add(vi);
                }
            }
            return result;
        }
        public async Task<List<Voedingswaarde>> GetVoedingswaardenOnKlant(int klantId)
        {
            List<Voedingswaarde> result = new List<Voedingswaarde>();
            List<Voedingswaarde> voedingswaarden = await _context.voedingswaardenDb.ToListAsync();
            foreach (Voedingswaarde vw in voedingswaarden)
            {
                if (vw.KlantId == klantId)
                {
                    result.Add(vw);
                }
            }
            return result;
        }
        public async void CreateVoedselInname(VoedselInname voedselInname)
        {
            await _context.VoedselInnamesDb.AddAsync(voedselInname);
            await _context.SaveChangesAsync();
        }

      

        public async void CreateVoedingswaarde(Voedingswaarde voedingswaarde)
        {
            await _context.voedingswaardenDb.AddAsync(voedingswaarde);
            await _context.SaveChangesAsync();
        }

        public async void DeleteVoedingswaarde(Voedingswaarde voedingswaarde)
        {
            _context.voedingswaardenDb.Remove(voedingswaarde);
            await _context.SaveChangesAsync();
        }
        public async void DeleteVoedselInname(VoedselInname voedselInname)
        {
            _context.VoedselInnamesDb.Remove(voedselInname);
            await _context.SaveChangesAsync();
        }

        //slaappatroon crud

        //patient crud

        //medicijn en medicijn afspraak crud
        public async Task<List<Medicijn>>GetMedicijnByPatientId(int patientId)
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

        

        //consulent crud

        //afspraak crud
    }
}
