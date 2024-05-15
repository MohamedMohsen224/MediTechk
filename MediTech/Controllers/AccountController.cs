using AutoMapper;
using Core.IdentityServices;
using Core.Models;
using Core.Models.Enums;
using Core.Models.Identity;
using MediTech.Dtos;
using MediTech.Errors;
using MediTech.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reposatry.DAta;
using Srevices;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IAuthServices authService;
        private readonly HospitalContext context;
        private readonly IMailSetting mailSetting;
        public SignInManager<AppUser> SignInManager;
        public AccountController(
           UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager,
           IAuthServices authService,
           HospitalContext context,
           IMailSetting mailSetting
           )
        {
            this.userManager = userManager;
            SignInManager = signInManager;
            this.authService = authService;
            this.context = context;
            this.mailSetting = mailSetting;
        }

        //============================================================================================
        // Multible login For Patient and Doctor
        [HttpPost("login")] 
        public async Task<ActionResult<UserDto>> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Ensure case-insensitive email comparison
            var email = model.Email.ToLowerInvariant();

            // Find user by email 
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Unauthorized(new ApiErrorResponse(401 , "Email or password is incorrect"));
            }

            if(model.Password == null)
            {
                return Unauthorized(new ApiErrorResponse(401,  "Password is required"));
            }

            var result = await SignInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded )
            {
                return Unauthorized(new ApiErrorResponse(401 , "Email or password is incorrect"));
            }

            if (await userManager.IsInRoleAsync(user, "Patient"))
            {
                // Patient Login Logic
                var patient = await context.Patients.FirstOrDefaultAsync(p => p.AppuserId == user.Id);
                if (patient != null)
                {
                    var patientId = patient.Id; // Extract PatientId
                    var patientDto = new UserDto() // Assuming UserDto is the response object
                    {
                        Id = patientId, // Use PatientId instead of user.Id
                        Profile_Picture = user.Profile_Picture,
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = await authService.CreateTokenAsync(user, userManager),
                        Telephone = user.PhoneNumber,
                        Address = user.Address,
                        DateOfBirth = user.DateOfBirth.ToString(),
                        NationalID = user.NationalID,
                        HealthInsuranceId = user.healthInsuranceNumber,
                        HealthInsuranceCompany= user.HealthInsuranceCompany,
                        Gender = user.Gender,
                    };

                    return Ok(patientDto);
                }
                else
                {
                    // Handle scenario where no associated patient record is found (log or return error)
                    return BadRequest(new ApiErrorResponse(400, "InvalidLogin.Patient record not found"));
                }
            }
            else if (await userManager.IsInRoleAsync(user, "Doctor"))
            {
                try
                {
                    var doctor = await context.Doctors.FirstOrDefaultAsync(p => p.AppuserId == user.Id);
                    if (doctor != null)
                    {
                        var doctorId = doctor.Id; 

                        var doctorDto = new UserDto() 
                        {
                            Id = doctorId,
                            Profile_Picture = user.Profile_Picture,
                            UserName = user.UserName,
                            Email = user.Email,
                            Token = await authService.CreateTokenAsync(user, userManager),
                            Telephone = user.PhoneNumber,
                            Address = user.Address,
                            DateOfBirth = user.DateOfBirth.ToString(),
                            NationalID = user.NationalID,
                            HealthInsuranceId = user.healthInsuranceNumber,
                            Gender = user.Gender,
                            
                           
                        };

                        return Ok(doctorDto);
                    }
                    else
                    {

                        return BadRequest(new ApiErrorResponse(400, "InvalidLogin.Doctor record not found"));
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(new ApiErrorResponse(400, "An error occurred. Please try again later."));
                }
            }
            else
            {
                return Unauthorized(new ApiErrorResponse(401, "Unauthorized access. User does not have patient or doctor role"));
            }
        }
        //register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingUser = await userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest(new ApiErrorResponse(400 , "Email address already in use"));
            }

            var user = new AppUser()
            {
                
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.telephone,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                NationalID = model.NationalID,
                healthInsuranceNumber = model.HealthInsuranceNumber,
                HealthInsuranceCompany = model.HealthInsuranceCompany,
                Gender = model.Gender,
                Profile_Picture = model.ProfilePictureUrl

               
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                await userManager.AddToRoleAsync(user, "Patient");
                var patient = new Patient()
                {
                    Profile_Picture = user.Profile_Picture,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth,
                    NationalID = user.NationalID,
                    healthInsuranceNumber = user.healthInsuranceNumber,
                    HealthInsuranceCompany = user.HealthInsuranceCompany,
                    Gender = user.Gender,
                    AppuserId=user.Id

                };
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
                return Ok(new UserDto()
                {
                    Id = patient.Id,
                    Profile_Picture = user.Profile_Picture,
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = await authService.CreateTokenAsync(user, userManager),
                    Telephone = user.PhoneNumber,
                    Address = user.Address,
                    DateOfBirth = user.DateOfBirth.ToString(),
                    NationalID = user.NationalID,
                    HealthInsuranceId = user.healthInsuranceNumber,
                    HealthInsuranceCompany = user.HealthInsuranceCompany,
                    Gender = user.Gender,
                });

            }
            else
            {
                return BadRequest(new { message = "Registration failed." });

            }


        }
        //logout
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok("LogOut Succefully");
        }
        //=============================================================================================
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile formFile)
        {
            // Validate content type (adjust extensions as needed)
            if (!formFile.ContentType.StartsWith("image/"))
            {
                return BadRequest("Only image uploads are allowed.");
            }

            // Generate a unique filename with extension
            string filename = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";

            // Create uploads folder if it doesn't exist
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Uploadimages\\");
            Directory.CreateDirectory(uploadsFolder); // Create folder if missing

            // Combine path with filename
            string filePath = Path.Combine(uploadsFolder, filename);

            // Use a try-catch block for error handling
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }

                // Return success message without revealing the path
                return Ok(filePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error uploading image: {ex.Message}");
            }
        }


    }



}

 


