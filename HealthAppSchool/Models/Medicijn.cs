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
        public int PatietnId { get; set; }
        public Patient Patient { get; set; }
    }
}
