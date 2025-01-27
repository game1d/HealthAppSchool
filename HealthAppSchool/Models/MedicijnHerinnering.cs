using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class MedicijnHerinnering
    {
        public int MedicijnHerinneringId { get; set; }
        public int PatientId { get; set; }
        public Medicijn MedicijnNaam { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public TimeOnly Tijdstip { get; set; }
        public string TijdstipString
        {
             get=> Tijdstip.ToString("HH:mm");
            set => Tijdstip = TimeOnly.Parse(value);

        }

        
    }
}
