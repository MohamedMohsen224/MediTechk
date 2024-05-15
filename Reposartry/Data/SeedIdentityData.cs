using Core.Models;
using Core.Models.Enums;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatry.Data
{
    public class SeedIdentityData
    {
        //public static async Task SeedUsersAsync(UserManager<AppUser> _userManager, RoleManager<IdentityRole<int>> roleManager,HospitalContext context)
        //{

        //    if (!_userManager.Users.Any())
        //    {
        //        // Create user
        //        var user = new AppUser
        //        {
        //            Profile_Picture = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2F717761877898366%2F&psig=AOvVaw3Z9Z6Z9Q6Z9Z6",
        //            UserName = "mohamed.Mohsen",
        //            Email = "mohamed.mohsen@gmail.com",
        //            PhoneNumber = "01000000000",
        //            Address = "Cairo",
        //            DateOfBirth = "29/11/2002",
        //            NationalID = 123456789,
        //            Type = "Patient",
        //            healthInsuranceNumber = 123456789,
        //            HealthInsuranceCompany = "AXA",
        //            Gender = "Male",
                    
        //        };
        //        var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
        //        if (result.Succeeded)
        //        {
        //            // Assign role
        //            await _userManager.AddToRoleAsync(user, "Patient");


        //            // Optionally, create associated data in Patient table
        //            var patient = new Patient
        //            {
        //                Id = user.Id,
        //                Profile_Picture = user.Profile_Picture,
        //                DisplayName = user.UserName,
        //                Email = user.Email,
        //                PhoneNumber = user.PhoneNumber,
        //                Address = user.Address,
        //                DateOfBirth = user.DateOfBirth,
        //                NationalID = user.NationalID,
        //                Type = user.Type,
        //                healthInsuranceNumber = user.healthInsuranceNumber,
        //                Gender = user.Gender,
        //                RoomId = 1,
                       
                        
        //            };
        //            // Save changes to the database
        //             context.Patients.Add(patient);
        //            await context.SaveChangesAsync();

        //        }

        //    }


        //}
    }
}
