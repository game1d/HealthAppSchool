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
        public string Voedsel {  get; set; }
        public int Gram {  get; set; }
    }
}
