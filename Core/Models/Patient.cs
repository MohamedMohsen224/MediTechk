using Core.Models.Enums;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Patient : Base
    {
      
        public string? Profile_Picture { get; set; }    
        public string UserName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int NationalID { get; set; }
        public int? healthInsuranceNumber { get; set; }
        public string? HealthInsuranceCompany { get; set; }
        public string PhoneNumber { get; set; }




        // Navigation properties

        public ICollection<Clinic> Clinics { get; set; } = new HashSet<Clinic>();
        public ICollection<Prescription> prescriptions { get; set; } = new HashSet<Prescription>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();


        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Rooms Room { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey("AppUser")]
        public string AppuserId { get; set; }
        public AppUser AppUser { get; set; }




    }
}
