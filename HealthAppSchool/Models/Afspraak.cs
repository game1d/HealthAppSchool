﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAppSchool.Models
{
    public class Afspraak
    {
        public int AfspraakId { get; set; }
        public int KlantId { get; set; }
        public Klant Klant { get; set; }
        public int ConsultantId {  get; set; }
        public Consultant Consultant { get; set; }
        public DateOnly datum {  get; set; }
        public TimeOnly time { get; set; }
    }
}
