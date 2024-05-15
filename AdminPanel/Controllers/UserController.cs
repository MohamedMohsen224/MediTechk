using AdminPanel.Models;
using Core.Models.Enums;
using Core.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }



        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.Select( u => new UserViewModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Roles =  userManager.GetRolesAsync(u).Result.ToList()
            }).ToListAsync();

            return View(users);
        }


        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var roles = await roleManager.Roles.ToListAsync();
            var model = new UserRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(r => new RoleViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    IsSelected = userManager.IsInRoleAsync(user, r.Name).Result

                }).ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRoleViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId.ToString());


            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            foreach (var role in model.Roles)
            {
                if (roles.Any(d => d == role.Name && !role.IsSelected))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                if (!roles.Any(d => d == role.Name && role.IsSelected))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
};
           

 
