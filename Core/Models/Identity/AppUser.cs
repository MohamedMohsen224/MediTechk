using Core.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Identity
{
    public class AppUser : IdentityUser
    {
         public string? Profile_Picture { get; set; }
         public string Gender { get; set; }
         public string DateOfBirth { get; set; }
         public string Address { get; set; }
         public long NationalID { get; set; }
         public long? healthInsuranceNumber { get; set; }
         public string? HealthInsuranceCompany { get; set; }
         public Patient Patient { get; set; }
         public Doctor Doctor { get; set; }


    }
}
