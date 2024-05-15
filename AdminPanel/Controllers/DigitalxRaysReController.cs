using AdminPanel.services;
using MediTech.Dtos;
using MediTech.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class DigitalxRaysReController : Controller
    {
        private readonly HospitalContext context;

        public DigitalxRaysReController(HospitalContext context)
        {
            this.context = context;
        }

        [HttpGet] // Display the list of tests
        public async Task<IActionResult> Index()
        {
            var digitalxrays = await context.PreciptionDigitalxrays
                .Include(pt => pt.Prescription)
                .Include(pt=>pt.DigitalXRay)
                .ToListAsync();
            return View(digitalxrays);
        }
        [HttpGet]
        public async Task<IActionResult> SeedDigitalResult(int PresciptionDigitalId)
        {
            var DigitalResult = await context.PreciptionDigitalxrays
                .Include(pt => pt.Prescription)
                .Include(pt => pt.DigitalXRay)
                .FirstOrDefaultAsync(pt => pt.Id == PresciptionDigitalId);

            if (DigitalResult == null)
            {
                return NotFound();
            }
            var model = new GetDigitalXrayResult
            {
                Id = DigitalResult.Id,
                Presiptionid = DigitalResult.PrescriptionId,
                DigitalXrayid = DigitalResult.DigitalXRayId,
                ImageUrl = DigitalResult.ImagePath,
                Status = DigitalResult.Status
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SeedDigitalResult(GetDigitalXrayResult model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingDigitalxray = await context.PreciptionDigitalxrays
                .FirstOrDefaultAsync(pt => pt.PrescriptionId == model.Presiptionid && pt.DigitalXRayId == model.DigitalXrayid);

            if (existingDigitalxray == null)
            {
                return NotFound();
            }
            existingDigitalxray.ImagePath = services.SeedImgeService.UploadImage(model.Image, "Images");
            existingDigitalxray.Status = model.Status;



            context.PreciptionDigitalxrays.Update(existingDigitalxray);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

