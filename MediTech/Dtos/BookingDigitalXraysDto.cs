namespace MediTech.Dtos
{
    public class BookingDigitalXraysDto
    {
        public int BookingID { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } // Assuming Patient has a Name property
        public DateTime AppointmentDateTime { get; set; }= DateTime.Now;
        public string DigitalXRayName{ get; set; }
        public int? PrescriptionId { get; set; }
        public object DigitalXRayId { get; internal set; }
    }
}
