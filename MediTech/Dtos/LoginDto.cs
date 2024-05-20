using System.ComponentModel.DataAnnotations;

namespace MediTech.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage =("Email Address Is Required"))]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage =("Password Is Required"))]
        public string Password { get; set; }
    }
}
