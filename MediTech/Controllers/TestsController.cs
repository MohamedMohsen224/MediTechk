using AutoMapper;
using Core.Models;
using Core.Services;
using Core.Specfication;
using Core.Specfication.Params;
using MediTech.Dtos;
using MediTech.Errors;
using MediTech.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using Srevices;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestServices testServices;
        private readonly IMapper mapper;
        private readonly HospitalContext context;

        public TestsController(ITestServices testServices, IMapper mapper,HospitalContext context)
        {
            this.testServices = testServices;
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TestDto>> AddTest(TestDto testsDto)
        {
            var tests = mapper.Map<TestDto, Core.Models.Tests>(testsDto);
            var test = await testServices.AddTest(tests);
            if (test == null) return BadRequest(new ApiErrorResponse(400));
            var data = mapper.Map<Core.Models.Tests, TestDto>(test);
            return Ok(data);
        }

        [HttpPut]
        public async Task<ActionResult<TestDto>> UpdateTest(TestDto testsDto)
        {
            var tests = mapper.Map<TestDto, Core.Models.Tests>(testsDto);
            var test = await testServices.UpdateTest(tests);
            if (test == null) return BadRequest(new ApiErrorResponse(400));
            var data = mapper.Map<Core.Models.Tests, TestDto>(test);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<ActionResult<TestDto>> DeleteTest(TestDto testsDto)
        {
            var tests = mapper.Map<TestDto, Core.Models.Tests>(testsDto);
            var test = await testServices.DeleteTest(tests);
            if (test == null) return BadRequest(new ApiErrorResponse(400));
            var data = mapper.Map<Core.Models.Tests, TestDto>(test);
            return Ok(data);
        }



        [HttpGet("Alltests")]   
        public async Task<ActionResult<TestDto>> GetTests([FromQuery] string searchTerm = null)
        {
            var medications = await testServices.GetAllTests(searchTerm);
            var medicationsDto = mapper.Map<IEnumerable<Tests>, IEnumerable<TestDto>>(medications);
            return Ok(medicationsDto);
        }


        [HttpPut("Test/{prescriptionId}")]
        public async Task<IActionResult> UpdateTestResult(int prescriptionId, int patientId, GetTestResultDto testResultDto)
        {
            // Validate data (example)
            if (prescriptionId <= 0 || patientId <= 0 || string.IsNullOrEmpty(testResultDto.Result))
            {
                return BadRequest("Invalid prescription ID, patient ID, or test result data.");
            }

            // Find existing record (assuming relationship with Prescription)
            var existingTest = await context.PrescriptionTests
                .Include(pt => pt.Prescription) // Eager loading for Prescription
                .FirstOrDefaultAsync(pt =>
                    pt.prescriptionId == prescriptionId &&
                    pt.TestId == testResultDto.TestId &&
                    pt.Prescription.PatientId == patientId);

            if (existingTest != null)
            {
                // Update existing record
                existingTest.TestResult = testResultDto.Result;
                existingTest.Detailsforresult = testResultDto.DetailsForResult;

                context.PrescriptionTests.Update(existingTest);
                await context.SaveChangesAsync();

                return Ok("Test result updated successfully.");
            }
            else
            {
                return NotFound("Test result not found for this prescription and patient.");
            }
        }



        [HttpGet("Test/{prescriptionId}/Result")]
        public async Task<IActionResult> GetTestResultByPatientAndPrescription(int patientId, int prescriptionId)
        {
            // Validate data (optional)
            if (patientId <= 0 || prescriptionId <= 0)
            {
                return BadRequest("Invalid patient ID or prescription ID.");
            }

            // Eager loading with projection (corrected casing and navigation property)
             var testResult = await context.PrescriptionTests
               .Include(pt => pt.Test)
               .Where(pt => pt.Prescription.PatientId == patientId && pt.prescriptionId == prescriptionId)
                .Select(pt => new GetTestResultDto
                {
                     TestId = pt.TestId,
                     TestName = pt.Test.TestName,
                     Result = pt.TestResult,
                     DetailsForResult = pt.Detailsforresult,
                     PresiptionId = pt.prescriptionId // Corrected spelling
                })
                  .FirstOrDefaultAsync();

            if (testResult == null)
            {
                return NotFound("Test result not found for this patient and prescription.");
            }

            return Ok(testResult);
        }

        [HttpPost("Booking/Tests")]
        public async Task<ActionResult<BookingTestDto>> ScheduleTestAppointment(Bookingtest bookingtest)
        {
            try
            {
                
                var booking = await testServices.ScheduleTestAppointment(bookingtest.TestId, bookingtest.PatientId, bookingtest.PrescriptionId);
                var mappedBooking = mapper.Map<Booking, BookingTestDto>(booking);
                if (booking != null)
                {
                    return mappedBooking; // Created 201 response
                }
                else
                {
                    return BadRequest("Failed to schedule appointment."); // 400 Bad Request
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500 Internal Server Error
            }
        }


        [HttpGet("Booking/{patientId}")]
        public async Task<ActionResult<BookingTestDto>> GetBookingsByPatientId(int patientId)
        {
            var bookings = await testServices.GetBookingsByPatientId(patientId);
            if (bookings != null)
            {
               
                var testAppointments = bookings.Where(b => b.TestId.HasValue)
                    .Select(b => new BookingTestDto
                    {
                        BookingID = b.BookingID,
                        PatientId = b.PatientId,
                        PatientName = b.Patient.UserName, // Assuming Patient has a Name property
                        TestName = b.Test.TestName,
                        PrescriptionId = b.PrescriptionId,
                        AppointmentDateTime = b.AppointmentDateTime,
                        Expired = b.AppointmentDateTime.AddDays(2)

                    })
                    .ToList();
                return Ok(testAppointments); // 200 OK response with test appointment DTOs
            }
            else
            {
                return NotFound("No bookings test found for this patient."); // 404 Not Found
            }
        }

        
    }
}
  













