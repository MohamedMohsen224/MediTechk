namespace MediTech.Dtos
{
    public class NewPresiptionDto
    {
        public List<PrescriptionMedicationDto> MedicationNames { get; set; }
        public List<PrescriptionTestDto> TestNames { get; set; }
        public List<PrescriptionDigitalXRayDto> DigitalXRayNames { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string IllnessDescription { get; set; }
       

    }
}
