using Core.Models;

namespace MediTech.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Profile_Picture { get; set; }
        public string Doctor_Name { get; set; }
        public string Doctor_Email { get; set; }
        public string Telephone { get; set; }
        public string Speachlization { get; set; }
        public string DateOfBirth { get; set; }
        public string Clinic { get; set; }
        public List<string> Workingdays { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        


    }
}
