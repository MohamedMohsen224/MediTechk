using AutoMapper;
using Core.Models.Identity;
using MediTech.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly HospitalContext _context; // Replace with your data access context
        private readonly IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;

        public AdminController(UserManager<AppUser> userManager, HospitalContext context, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }



        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user is null)
            {
                ModelState.AddModelError("Email", "Invalid Email or Password");
                return View(loginModel);
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (!result.Succeeded || !await _userManager.IsInRoleAsync(user, "Admin"))
            {

                ModelState.AddModelError(string.Empty, "NotUthroized");
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }   
    }
}
