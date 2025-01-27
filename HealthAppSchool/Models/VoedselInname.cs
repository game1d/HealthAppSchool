using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class VoedselInname
    {
        public int VoedselInnameId { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public string VoedselNaam {  get; set; }
        public int VoedselGewichtInGram {  get; set; }
        public DateOnly Datum { get; set; }
    }
}
