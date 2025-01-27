using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Medicijn
    {
        public int MedicijnId { get; set; }
        public string MedicijnNaam {  get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        
    }
}
