using AdminPanel.services;
using AutoMapper;
using Core.IdentityServices;
using Core.Models;
using Core.Models.Identity;
using MediTech.Dtos;
using MediTech.Errors;
using MediTech.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Reposatry.DAta;
using System;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace AdminPanel.Controllers
{
    public class DoctorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly HospitalContext _context; // Replace with your data access context
        private readonly IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;

        public DoctorController(UserManager<AppUser> userManager, HospitalContext context ,IMapper mapper,SignInManager<AppUser> signInManager) { 
            _userManager = userManager;
            _context = context;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        // GET: Doctors
        [HttpGet]
        public async Task<ActionResult<Doctor>> Index()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return View(doctors); 
        }

        // GET: Doctors/Create
        [HttpGet]
        // Restrict access to Admins only
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        public async Task<IActionResult> Create(RegisterDoctorViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel); // Return with validation errors
            }
            if (registerModel.WorkingDays == null)
            {
                registerModel.WorkingDays = new List<string>(); // Initialize empty list
            }

            // Get selected days from the hidden input
            var selectedDays = Request.Form["hiddenWorkingDays"];

            // Clear existing WorkingDays list (if any)
            registerModel.WorkingDays.Clear();

            // Add selected days to the list (if any)
            if (selectedDays.Count > 0)
            {
                foreach (var day in selectedDays.ToHashSet()) // Remove duplicates
                {
                    registerModel.WorkingDays.Add(day);
                }
            }

            var user = new AppUser
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
                Address = registerModel.Address,
                DateOfBirth = registerModel.DateOfBirth,
                Gender = registerModel.Gender,
                NationalID = registerModel.NationalID,
                healthInsuranceNumber = registerModel.healthInsuranceNumber,
                Profile_Picture = registerModel.ProfilePicture
            };
            var createUserResult = await _userManager.CreateAsync(user, registerModel.Password);

                if (createUserResult.Succeeded)
                { 
                    await _userManager.AddToRoleAsync(user, "Doctor");
                var doctorObj = new Doctor
                {
                    ClinicId = registerModel.ClinicId, // Assign Clinic ID from the model
                    DisplayName = user.UserName,
                    Profile_Picture = user.Profile_Picture, // Set the uploaded filename
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email,
                    Address = user.Address,
                    NationalID = user.NationalID,
                    healthInsuranceId = user.healthInsuranceNumber,
                    PhoneNumber = user.PhoneNumber,
                    Speachlization = registerModel.speciality,
                    Gender = user.Gender,
                    StartTime = registerModel.StartTime,
                    EndTime = registerModel.EndTime,
                    WorkingDays = registerModel.WorkingDays,
                    AppuserId = user.Id
                    };
                    _context.Doctors.Add(doctorObj);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home", new { doctors = await _context.Doctors.ToListAsync() });
                    
                }else
                {
                    foreach (var error in createUserResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                 return View(registerModel);

        }
        public static string GetDayString(DayOfWeek day)
        {
            return day.ToString(); // Returns string representation of the enum value (e.g., "Monday")
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDto loginModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loginModel);
        //    }

        //    var user = await _userManager.FindByEmailAsync(loginModel.Email);
        //    if (user is null)
        //    {
        //        ModelState.AddModelError("", "Invalid Email or Password");
        //        return View(loginModel);
        //    }
        //    var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
        //    if (!result.Succeeded || await _userManager.IsInRoleAsync(user,"Doctor"))
        //    {


        //    }


        //}

    }
}
    




