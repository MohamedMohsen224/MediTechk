using Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MediTech.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Profile_Picture { get; set; }
        public string UserName { get; set; }    
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public long NationalId { get; set; }
        

    }
}
