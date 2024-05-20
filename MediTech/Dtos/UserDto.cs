namespace MediTech.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public long NationalID { get; set; }
        public string Gender { get; set; }
        public long? HealthInsuranceId { get; set; }
        public string? HealthInsuranceCompany { get; set; }
        public string? Profile_Picture { get; set; }
        public string Token { get; set; }
        
      
       
    
    }
}
