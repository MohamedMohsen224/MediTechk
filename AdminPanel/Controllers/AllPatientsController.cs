using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class AllPatientsController : Controller
    {
        private readonly HospitalContext context;

        public AllPatientsController(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await context.Patients.ToListAsync();
            return View(patients);
        }
    }
}
