using AdminPanel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await roleManager.Roles.ToListAsync(); 
            return View(roles);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleFormViewModel roleName)
        {
            if (ModelState.IsValid)
            {
                var RoleExist = await roleManager.RoleExistsAsync(roleName.Name);
                if (!RoleExist)
                {
                     await roleManager.CreateAsync(new IdentityRole(roleName.Name.Trim()));
                    return RedirectToAction("Index"); 
                }
                else { 
                    ModelState.AddModelError("Name", "Role already exist");
                    return View("Index" , await roleManager.Roles.ToListAsync());
                }
                
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> delete (string id)
        {
            var role = await roleManager.FindByIdAsync(id);
             await roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var Mapped =new RoleViewModel()
            {
                Name = role.Name
            };
            return View(Mapped);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,RoleViewModel role)
        {
            if (!ModelState.IsValid)
            {
                var RoleExist = await roleManager.RoleExistsAsync(role.Name);
                if (!RoleExist)
                {
                    var roleEntity = await roleManager.FindByIdAsync(id.ToString());
                    roleEntity.Name = role.Name;
                    await roleManager.UpdateAsync(roleEntity);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Role already exist");
                    return View(role);
                }
            }
            return RedirectToAction("Index");
           
        }
    }
}
