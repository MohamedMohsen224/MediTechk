using Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MediTech.Dtos
{
    public class RegisterDto
    {
        public string? ProfilePictureUrl{ get; set; }

        public IFormFile? Image { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required(ErrorMessage = "Telephone number is required.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Telephone number must be 11 digits.")]
        public string telephone { get; set; }
        [Required(ErrorMessage ="Please Enter The Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date of birth is required.")]
        public string DateOfBirth { get; set; }
        [Required]
        public int NationalID { get; set; }
        public int? HealthInsuranceNumber { get; set; }
        public string? HealthInsuranceCompany { get; set; }

       

    }
}
