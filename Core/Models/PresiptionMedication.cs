using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PresiptionMedication:Base
    {
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        public int? Dose { get; set; }

    }
}
