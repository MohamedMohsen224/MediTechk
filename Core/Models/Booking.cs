using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
        public class Booking
        {
            public int BookingID { get; set; }
            public int? TestId { get; set; } 
            public Tests Test { get; set; } 

            public int? DigitalXRayId { get; set; } 
            public Digital_x_rays DigitalXRay { get; set; } 

            public int PatientId { get; set; } 
            public Patient Patient { get; set; } 

            public int? PrescriptionId { get; set; } 
            public DateTime AppointmentDateTime { get; set; }= DateTime.Now;
        }
}
