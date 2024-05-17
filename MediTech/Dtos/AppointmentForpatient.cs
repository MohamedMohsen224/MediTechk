namespace MediTech.Dtos
{
    public class AppointmentForpatient
    {
        public int id { get; set; }
        public int AppointmentNumber { get; set; }
        public DateTime Date { get; set; }
        public string Doctor { get; set; }
        public string   day { get; set; }
        public string Specialization { get; set; }

        public string ProfilePicture { get; set; }
        public TimeSpan DoctorStartTime { get; set; } 
        public TimeSpan DoctorEndTime { get; set; }
    }
}
