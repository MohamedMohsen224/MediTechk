using Core.Models;

namespace MediTech.Dtos
{
    public class PrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;
        public string? DoctorName { get; set; }
        public string? PatientName { get; set; } 
        public string? IllnessDescription { get; set; }
      

        public DateTime NextVisit { get; set; }


        public List<PrescriptionMedicationDto> Medications { get; set; }
        public List<PrescriptionTestDto> Tests { get; set; }
        public List<PrescriptionDigitalXRayDto> DigitalXRays { get; set; }

    }
}
