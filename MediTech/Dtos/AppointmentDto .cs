using Core.Models.Enums;

namespace MediTech.Dtos
{
    public class AppointmentDto
    {
        public int AppointmentNumber { get; set; }
        public DateTime Date { get; set; }=DateTime.Now;
        public int DoctorId { get; set; }
        public string Doctor { get; set; } 
        public int PatientId { get; set; }
        public string Patient { get; set; } 
        public List<string> day {get ; set; }
        public TimeSpan DoctorStartTime { get; set; } 
        public TimeSpan DoctorEndTime { get; set; }

       
    }
}
