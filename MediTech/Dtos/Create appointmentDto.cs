using System.ComponentModel.DataAnnotations;

namespace MediTech.Dtos
{
    public class Create_appointmentDto
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string SelectedDay { get; set; }
        [Required]
        public int PatientId { get; set; } 
    }
}
