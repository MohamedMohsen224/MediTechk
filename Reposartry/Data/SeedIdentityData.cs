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
        public static async Task SeedUsersAsync(UserManager<AppUser> _userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!_userManager.Users.Any())
            {
                // Create user
                var Admin = new AppUser
                {
                    UserName = "Mohamed_Mohsen",
                    Email = "Mohamed_Mohsen12@MediTech.com",
                    Gender = "Male",
                    DateOfBirth = "1/1/1990",
                    Address = "Cairo",
                    NationalID = 123456789,
                  
                };

                var Result = await _userManager.CreateAsync(Admin, "Admin@123"); 
                if (Result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(Admin, "Admin");
                }
                else
                {
                       throw new Exception("Failed to create Admin");
                }


            }
        }
    }
}
