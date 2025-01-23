using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Consultant
    {
        public int ConsultantId {  get; set; }
        List<Afspraak> Afspraken { get; set; }
    }
}
