using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Voedingswaarde
    {
        public int VoedingswaardeId { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
    }
}
