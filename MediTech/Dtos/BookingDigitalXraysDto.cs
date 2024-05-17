namespace MediTech.Dtos
{
    public class BookingDigitalXraysDto
    {
        public int BookingID { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } // Assuming Patient has a Name property
        public DateTime AppointmentDateTime { get; set; }= DateTime.UtcNow.AddDays(1);
        public string DigitalXRayName{ get; set; }
        public int? PrescriptionId { get; set; }
        public DateTime Expired { get; set; }

    }
}
