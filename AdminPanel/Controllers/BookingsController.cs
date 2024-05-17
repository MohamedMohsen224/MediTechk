using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class BookingsController : Controller
    {
        private readonly HospitalContext context;

        public BookingsController(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var bookings = await context.Bookings.Include(pt=>pt.Patient).Include(pt=>pt.Test).Include(pt=>pt.DigitalXRay).ToListAsync();
            return View(bookings);
            
        }
    }
}
