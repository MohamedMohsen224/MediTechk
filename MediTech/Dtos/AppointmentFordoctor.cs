namespace MediTech.Dtos
{
    public class AppointmentFordoctor
    {
        public int AppointmentNumber { get; set; }
        public DateTime Date { get; set; } 
        public int PatientId { get; set; }
        public string Patient { get; set; }
        public string  day { get; set; }
      
    }
}
