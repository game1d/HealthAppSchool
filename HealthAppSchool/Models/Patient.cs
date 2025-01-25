using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Patient
    {
        public int PatientId {  get; set; }
        public string PatientName { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public List<Medicijn> medicijnen { get; set; }
        public List<Consultant> consultanten { get; set; }
        public List<Afspraak> Afspraken { get; set; }
    }
}
