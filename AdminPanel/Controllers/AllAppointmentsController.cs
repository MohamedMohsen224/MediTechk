using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class AllAppointmentsController : Controller
    {
        private readonly HospitalContext context;

        public AllAppointmentsController(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Appointments = await context.Appointments.Include(PT=>PT.Patient).Include(PT=>PT.Doctor).ToListAsync();
            return View(Appointments);
        }
    }
}
