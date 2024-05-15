using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Prescription : Base
    {
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;
        public DateTime NextVisit { get; set; }
        public string Illness { get; set; }
        public string Description { get; set; }

       

        // Navigation properties
        public ICollection<PresiptionMedication> Medications { get; set; } = new HashSet<PresiptionMedication>();
        public ICollection<PresciptionTests> Tests { get; set; } = new HashSet<PresciptionTests>();
        public ICollection<PreciptionDigitalxrays> X_Rays { get; set; } = new HashSet<PreciptionDigitalxrays>();

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public void AddTest(Tests test)
        {
            Tests.Add(new PresciptionTests { Test = test });
        }

        // Method to add Digital_x_rays with automatic linking to Patient_Digital_x_Ray (via PrescriptionDigitalXRay)
        public void AddDigitalXRay(Digital_x_rays xray)
        {
            X_Rays.Add(new PreciptionDigitalxrays { DigitalXRay = xray });
        }

        
    }
}

