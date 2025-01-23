using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Klant
    {
        public int KlantId { get; set; }
        public string KlantName { get; set; }
        public string Email {  get; set; }
        public string WachtWoord {  get; set; }
        public List<VoedselInname> VoedselInnames { get; set; }
        public List<Voedingswaarde> Voedingswaarden { get; set; }
        public List<SlaapPatroon> SlaapPatronen { get; set; }
        public List<FysiekeActiviteit> FysiekeActiviteiten { get; set; }
        public KlantToken Token { get; set; }

        public Klant() { }
        public Klant(string email, string wachtWoord) 
        {
            Email = email;
            WachtWoord = wachtWoord;
            VoedselInnames = new List<VoedselInname>();
            Voedingswaarden = new List<Voedingswaarde>();
            SlaapPatronen = new List<SlaapPatroon>();
            FysiekeActiviteiten = new List<FysiekeActiviteit>(); 
        }
    }
}
