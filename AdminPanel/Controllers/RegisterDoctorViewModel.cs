using AdminPanel.Models;
using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Controllers
{
    public class RegisterDoctorViewModel
    {
        public string? ProfilePicture { get;set;}

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The password must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
         public string speciality { get; set; }
        public int ClinicId { get; set; }
        public string Gender { get;  set; }
        public int NationalID { get; set; }
        public int healthInsuranceNumber { get;  set; }
        public List<string> WorkingDays { get; set; } 
        public TimeSpan StartTime { get;  set; }
        public TimeSpan EndTime { get; set; }

        

    }

}