using AutoMapper;
using Core.Models;
using Core.Services;
using Core.Specfication;
using MediTech.Dtos;
using MediTech.Errors;
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
    public class PresiptionController : ControllerBase
    {
        private readonly IPreceptionServices _preceptionServices;
        private readonly IMapper _mapper;
        private readonly HospitalContext context;

        public PresiptionController(IPreceptionServices preceptionServices, IMapper mapper ,HospitalContext context)
        {
            _preceptionServices = preceptionServices;
            _mapper = mapper;
            this.context = context;
        }

        [HttpGet("prescriptions/{doctorId}/{patientId}")]
        public async Task<ActionResult<IEnumerable<PrescriptionDto>>> GetPrescriptionsByDoctorAndPatient(int doctorId, int patientId)
        {
            try
            {
                // Fetch prescriptions with doctor ID and patient ID
                var prescriptions = await _preceptionServices.GetPrescriptionsByDoctorAndPatient(doctorId, patientId);

                // Check if any prescriptions found
                if (prescriptions == null || !prescriptions.Any())
                {
                    return NotFound("No prescriptions found for the given doctor and patient combination.");
                }

                // Map prescriptions to DTOs
                var prescriptionDtos = _mapper.Map<IEnumerable<Prescription>, IEnumerable<PrescriptionDto>>(prescriptions);

                return Ok(prescriptionDtos);
            }
            catch (Exception ex)
            {
                var errorMessage = string.Join(", ", ex.Message);
                return BadRequest(new ApiErrorResponse(400, errorMessage));
            }
        }

        [HttpGet("prescriptions/{patientId}")]
        public async Task<ActionResult<PrescriptionDto>> GetPrescriptionsByPatientId(int patientId)
        {
            var prescriptions = await context.Prescriptions
                                              .Include(p => p.Medications)
                                              .ThenInclude(m => m.Medication)
                                              .Include(p=>p.X_Rays)
                                              .ThenInclude(d=>d.DigitalXRay)
                                              .Include(p => p.Tests)
                                              .ThenInclude(t => t.Test)
                                              .Include(p=>p.Patient)
                                              .Include(p=>p.Doctor)
                                              .Where(p => p.PatientId == patientId)
                                              .ToListAsync();

            if (!prescriptions.Any())
            {
                return NoContent();
            }

            var mappedPrescriptions = prescriptions.Select(p => new PrescriptionDto
            {
                PrescriptionId = p.Id,
                PrescriptionDate = p.PrescriptionDate,
                NextVisit = p.NextVisit,
                DoctorName = p.Doctor?.DisplayName,
                PatientName= p.Patient?.UserName, 
                IllnessDescription= p.IllnessDescription,
                Medications = p.Medications?.Select(m => m.Medication != null ?
                    new PrescriptionMedicationDto
                    {
                        Name = m.Medication.Medication_Name,
                        Dose = m.Dose

                    } : null).ToList(),
                DigitalXRays = p.X_Rays?.Select(d => d.DigitalXRay != null ?
                      new PrescriptionDigitalXRayDto
                      {
                          Id = d.DigitalXRayId,
                          Name = d.DigitalXRay.Name,
                          Price = d.DigitalXRay.Price
                      } : null).ToList(),
                Tests = p.Tests?.Select(t => t.Test != null ?
                    new PrescriptionTestDto
                    {
                        Id = t.TestId,
                        Name = t.Test.TestName,
                        Price = t.Test.TestPrice
                    } : null).ToList(),
             

            }).ToList();
            //foreach (var prescription in mappedPrescriptions)
            //{
            //    if (!prescription.Tests.Any())
            //    {
            //        prescription.Tests = new List<PrescriptionTestDto>() { new PrescriptionTestDto { Message = "No Tests Ordered" } };
            //    }

            //    if (!prescription.DigitalXRays.Any())
            //    {
            //        prescription.DigitalXRays = new List<PrescriptionDigitalXRayDto>() { new PrescriptionDigitalXRayDto { Message = "No Digital X-Rays Ordered" } };
            //    }
            //}

            return Ok(mappedPrescriptions);
        }

        [HttpPost("CreatePrescription")]
        public async Task<ActionResult<PrescriptionDto>> CreatePrescription([FromBody] NewPresiptionDto prescriptionDtoo)
        {


            try
            {
                // 1. Map to internal Prescription object (consider data transformation)
                var mappedPrescription = _mapper.Map<NewPresiptionDto, Prescription>(prescriptionDtoo);

                // 2. Create the prescription in the system
                var createdPrescription = await _preceptionServices.CreatePrescription(mappedPrescription);

                // 3. Map the created prescription back to PrescriptionDto for response
                var prescriptionDto = _mapper.Map<Prescription, PrescriptionDto>(createdPrescription);

                // ... (rest of your code)

                return prescriptionDto;
            }
            catch (Exception ex)
            {
                var errorMessage = string.Join(", ", ex.Message);
                return BadRequest(new ApiErrorResponse(400, errorMessage));
            }
        }

        [HttpDelete]
        [Route("Deleteprescriptions/{prescriptionId}")]
        public async Task<IActionResult> DeletePrescription(int prescriptionId)
        {
            var isDeleted = await _preceptionServices.DeletePrescription(prescriptionId);
            if (isDeleted)
            {
                return Ok("Prescription deleted successfully");
            }
            else
            {
                return NotFound("Prescription not found");
            }
        }


      
    }


}





