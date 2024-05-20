
using Core.Models.Enums;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Models
{
        public class Doctor : Base
        {
        
            public string? Profile_Picture { get; set; }
            public string DisplayName { get; set; }
            public string Gender { get; set; }
            public string DateOfBirth { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public long NationalID { get; set; }
            public long? healthInsuranceId { get; set; }
            public string PhoneNumber { get; set; }
            public string Speachlization { get; set; }
            public List<string> WorkingDays { get; set; } 
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }





        // Navigation properties

            [ForeignKey("Clinic")]
            public int ClinicId { get; set; }
            public Clinic Clinic { get; set; }

            [ForeignKey("AppUser")]
            public string AppuserId { get; set; }
            public AppUser AppUser { get;  set; }
            public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
            public ICollection<Prescription> prescriptions { get; set;} = new HashSet<Prescription>();
       


        }
}