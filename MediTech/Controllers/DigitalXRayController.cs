using AutoMapper;
using Core.Models;
using Core.Services;
using MediTech.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reposatry.DAta;
using Srevices;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DigitalXRayController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDigitalXraySrevices digitalXraySrevices;
        private readonly HospitalContext context;

        public DigitalXRayController(IMapper mapper, IDigitalXraySrevices digitalXraySrevices, HospitalContext context)
        {
            this.mapper = mapper;
            this.digitalXraySrevices = digitalXraySrevices;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<DigitalXRayDto>> AddDigitalXray(Digital_x_rays digitalXray)
        {
            var ddigitalXray = await digitalXraySrevices.AddDigitalXray(digitalXray);
            return Ok(digitalXray);
        }
        [HttpPut]
        public async Task<ActionResult<DigitalXRayDto>> UpdateDigitalXray(Digital_x_rays digitalXray)
        {
            var ddigitalXray = await digitalXraySrevices.UpdateDigitalXray(digitalXray);
            return Ok(digitalXray);
        }
        [HttpDelete]
        public async Task<ActionResult<DigitalXRayDto>> DeleteDigitalXray(Digital_x_rays digitalXray)
        {
            var ddigitalXray = await digitalXraySrevices.DeleteDigitalXray(digitalXray);
            return Ok(digitalXray);
        }

        [HttpGet]
        public async Task<ActionResult<DigitalXRayDto>> GetDigitalxrays([FromQuery] string searchTerm = null)
        {
            var medications = await digitalXraySrevices.GetAllDigitalXrays(searchTerm);
            var medicationsDto = mapper.Map<IEnumerable<Digital_x_rays>, IEnumerable<DigitalXRayDto>>(medications);
            return Ok(medicationsDto);
        }

        [HttpPut("DigitalXray/{prescriptionId}/CreateResultDigitalXray")]
        public async Task<IActionResult> UpdateDigitalXrayStatus(int prescriptionId, int patientId, GetDigitalXrayResult result)
        {
            // Validate data (optional)
            if (prescriptionId <= 0 || patientId <= 0 || string.IsNullOrEmpty(result.Status) || result.DigitalXrayid <= 0)
            {
                return BadRequest("Invalid prescription ID, patient ID, status, or digital X-ray ID.");
            }

            // Find the PreciptionDigitalxray record (assuming relationship with Prescription)
            var digitalXray = await context.PreciptionDigitalxrays
                .Include(pdx => pdx.Prescription) // Eager loading for Prescription
                .Where(pdx =>
                    pdx.PrescriptionId == prescriptionId &&
                    pdx.DigitalXRayId == result.DigitalXrayid &&
                    pdx.Prescription.PatientId == patientId) // Filter by prescription ID, digital X-ray ID, and patient ID
                .FirstOrDefaultAsync();

            if (digitalXray == null)
            {
                return NotFound("Digital X-ray not found for this prescription and patient.");
            }

            // Update status from GetDigitalXrayResult
            digitalXray.Status = result.Status;

            await context.SaveChangesAsync();

            return Ok("Digital X-ray status updated successfully.");
        }

        [HttpGet("DigitalXray/{prescriptionId}/Result")]
        public async Task<IActionResult> GetDigitalXrayByPrescriptionId(int PatientId, int? prescriptionId)
        {
            if (PatientId <= 0 || prescriptionId <= 0)
            {
                return BadRequest("Invalid patient ID or prescription ID.");
            }

            // Eager loading with projection
            var digitalXrayResult = await context.PreciptionDigitalxrays
                .Include(pdx => pdx.DigitalXRay)
                .Where(pdx => pdx.PrescriptionId == prescriptionId && pdx.Prescription.PatientId == PatientId)
                .Select(pdx => new GetDigitalXrayResult
                {
                    DigitalXrayid = pdx.DigitalXRayId,
                    DigitalXrayName=pdx.DigitalXRay.Name,
                    //ImageUrl = pdx.ImagePath, // Assuming Image stores the URL
                    Status = pdx.Status,
                    Presiptionid = pdx.PrescriptionId
                })
                .FirstOrDefaultAsync();

            if (digitalXrayResult == null)
            {
                return NotFound("Digital X-ray not found for this prescription.");
            }

            return Ok(digitalXrayResult);
        }

        [HttpPost("Booking/DigitalxRay")]
        public async Task<ActionResult<BookingDigitalXraysDto>> ScheduleTestAppointment(Digitalbooking digitalbooking)
        {
            try
            {

                var booking = await digitalXraySrevices.ScheduleTestAppointment(digitalbooking.DigitalXrayId, digitalbooking.patientId, digitalbooking.preciptionid);
                var mappedBooking = mapper.Map<Booking, BookingDigitalXraysDto>(booking);
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

        [HttpGet("BookingXray/{patientId}")] 
        public async Task<ActionResult<BookingDigitalXraysDto>> GetBookingsByPatientId(int patientId)
        {
            var bookings = await digitalXraySrevices.GetBookingsByPatientId(patientId); // Assuming digitalXraySrevices handles both tests and digital x-rays
            if (bookings != null && bookings.Any())
            {
                var bookingDtos = bookings.Where(b => b.DigitalXRayId.HasValue) // Filter for bookings with digital x-rays only
                    .Select(b => new BookingDigitalXraysDto
                    {
                        BookingID = b.BookingID,
                        PatientId = b.PatientId,
                        PatientName = b.Patient.UserName, // Assuming Patient has a Name property
                        DigitalXRayName = b.DigitalXRayId.HasValue ? b.DigitalXRay.Name : null,
                        PrescriptionId = b.PrescriptionId,
                        Expired = b.AppointmentDateTime.AddDays(2)

                    })
                    .ToList();
                return Ok(bookingDtos); // 200 OK response with booking DTOs containing digital x-ray information only
            }
            else
            {
                return NotFound("No bookings with digital x-rays found for this patient."); // 404 Not Found (adjusted message)
            }
        }
    }
}
