namespace MediTech.Dtos
{
    public class BookingTestDto
    {
        public int BookingID { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } 
        public DateTime AppointmentDateTime { get; set; }= DateTime.Now.AddDays(1);
        public string TestName{ get; set; } 
        public int? PrescriptionId { get; set; }
    }
}
