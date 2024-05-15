using Core.IdentityServices;
using Core.Models;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class AuthServices : IAuthServices
    {
        private readonly IConfiguration configuration;

        public AuthServices(IConfiguration configuration )
        {
            this.configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager)
        {
            var authClaims = new List<Claim>();


            if (await userManager.IsInRoleAsync(user, "Patient") )
            {

                var patient = user.Patient;  
                if (user.Id == user.Patient.AppuserId)
                {
                    authClaims.Add(new Claim("UserName", patient.UserName));
                    authClaims.Add(new Claim("Email", patient.Email));
                    authClaims.Add(new Claim("PhoneNumber", patient.PhoneNumber));
                    authClaims.Add(new Claim("DateOfBirth", patient.DateOfBirth));
                    authClaims.Add(new Claim("Address", patient.Address));
                    authClaims.Add(new Claim("Id", patient.Id.ToString())); 

                }
            }
            else if (await userManager.IsInRoleAsync(user, "Doctor"))
            {

                var Doctor = user.Doctor;  
                if (user.Id == user.Doctor.AppuserId)
                {
                    authClaims.Add(new Claim("GivenName", Doctor.DisplayName));
                    authClaims.Add(new Claim("Email", Doctor.Email));
                    authClaims.Add(new Claim("MobilePhone", Doctor.PhoneNumber));
                    authClaims.Add(new Claim("DateOfBirth", Doctor.DateOfBirth));
                    authClaims.Add(new Claim("Country", Doctor.Address));
                    authClaims.Add(new Claim("Id", Doctor.Id.ToString()));
                    authClaims.Add(new Claim("Profile_Picture", Doctor.Profile_Picture));
                     

                }
            }


            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
                authClaims.Add(new Claim("Role", role));

            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));



            var token = new JwtSecurityToken(

                audience: configuration["JWT:ValidAudience"],
                issuer: configuration["JWT:ValidIssuer"],
                expires: DateTime.UtcNow.AddDays(double.Parse(configuration["JWT:DurationInDays"])),
                claims: authClaims,

                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256)
                );



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
