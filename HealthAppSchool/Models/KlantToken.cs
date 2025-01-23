using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class KlantToken
    {
        public int Id { get; set; }
        public int KlantId {  get; set; }
        public Klant Klant { get; set; }
        public string KlantEmail {  get; set; }
        public string KlantWachtwoord {  get; set; }

        public KlantToken() { }
        public KlantToken(Klant klant, string wachtwoord) 
        {
            KlantId = klant.KlantId;
            KlantEmail = klant.Email;
            KlantWachtwoord = wachtwoord;
        }
    }


}
