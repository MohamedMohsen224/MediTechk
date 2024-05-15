using Core.Models;
using MediTech.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;

namespace AdminPanel.Controllers
{
    public class ResultsController : Controller
    {
        private readonly HospitalContext context;

        public ResultsController(HospitalContext context)
        {
            this.context = context;
        }

        [HttpGet] // Display the list of tests
        public async Task<IActionResult> Index()
        {
            var tests = await context.PrescriptionTests
                .Include(pt => pt.Prescription) // Eager loading for Prescription (if needed)
                .ToListAsync();
            return View(tests);
        }
        [HttpGet]
        public async Task<IActionResult> SeedTestResult(int PresciptionTestId)
        {
            var testResult = await context.PrescriptionTests
                .Include(pt => pt.Prescription) // Eager loading for Prescription (optional)
                .Include(pt => pt.Test) // Eager loading for Test (optional)
                .FirstOrDefaultAsync(pt => pt.Id == PresciptionTestId);

            if (testResult == null)
            {
                return NotFound();
            }

            var model = new GetTestResultDto
            {
                Id = testResult.Id, // Pre-populate ID for editing (optional)
                PresiptionId = testResult.prescriptionId,
                TestId = testResult.TestId, 
                TestName = testResult.Test.TestName,
                Result = testResult.TestResult,
                DetailsForResult = testResult.Detailsforresult
            };

            return View(model);
        }

        [HttpPost] // Updated route for seeding
        public async Task<IActionResult> SeedTestResult(GetTestResultDto model)
        {
            if (model.PresiptionId <= 0 || string.IsNullOrEmpty(model.Result))
            {
                return BadRequest("Invalid prescription ID or test result data.");
            }

            var existingTest = await context.PrescriptionTests.FindAsync(model.Id);

            if (existingTest == null)
            {
                return NotFound();
            }

            existingTest.TestResult = model.Result;
            existingTest.Detailsforresult = model.DetailsForResult;

            // Removed update for TestId

            context.PrescriptionTests.Update(existingTest);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }

}





