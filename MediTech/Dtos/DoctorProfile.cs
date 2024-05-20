namespace MediTech.Dtos
{
    public class DoctorProfile
    {
        public int Id { get; set; }
        public string? Profile_Picture { get; set; }
        public string DisplayName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long NationalID { get; set; }
        public long? healthInsuranceId { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Workingdays { get; set; }

    }
}
