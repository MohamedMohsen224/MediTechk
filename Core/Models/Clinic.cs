using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Clinic:Base
    {
    
        public string Clinic_Name { get; set; }
        public string Clinic_Location { get; set; }
        public string Clinic_Phone { get; set; } 
        public decimal AmoutForBook { get; set; }

        // Navigation properties

        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
        public ICollection<Patient> Patients_clinic { get; set; } = new HashSet<Patient>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
     
   





    }
}