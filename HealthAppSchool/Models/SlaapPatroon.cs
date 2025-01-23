using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class SlaapPatroon
    {
        public int SlaapPatroonId { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public int DuurMinuten {  get; set; }
        public string SlaapDiepte {  get; set; }
    }
}
