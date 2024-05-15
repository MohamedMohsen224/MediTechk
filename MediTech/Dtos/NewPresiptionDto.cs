namespace MediTech.Dtos
{
    public class NewPresiptionDto
    {
        public List<PrescriptionMedicationDto> MedicationNames { get; set; }
        public string[] TestNames { get; set; }
        public string[] DigitalXRayNames { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Illness { get; set; }
        public string Description { get; set; }

    }
}
