using AutoMapper;
using Core;
using Core.Models;
using Core.Models.Enums;
using Core.Services;
using MediTech.Dtos;
using MediTech.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reposatry;
using Reposatry.DAta;
using Srevices;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices appointmentServices;
        private readonly IMapper mapper;

        public AppointmentController(IAppointmentServices appointmentServices, IMapper mapper)
        {
            this.appointmentServices = appointmentServices;
            this.mapper = mapper;        }
        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment(Create_appointmentDto dto)
        {
            try
            {
                var appointments = new Appointment
               {
                   DoctorId = dto.DoctorId,
                   PatientId = dto.PatientId, 
                   SelectedDay = dto.SelectedDay

               };
                var appointment = await appointmentServices.CreateAppointment(appointments);
                return Ok("Appointment created successfully!"); // Simple success message
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //=====================================================================
        [HttpGet]
        [Route("appointmentsDoctor/{doctorId}/{dayOfWeek}")]
        public async Task<ActionResult<AppointmentFordoctor>> GetAppointmentsByDoctorId(int doctorId,string dayOfWeek)
        {
            try
            {
                var appointments = await appointmentServices.GetAppointmentByDoctorId(doctorId,dayOfWeek);
                if (appointments == null )
                {
                    return NotFound(appointments); 
                }
                var mappedAppointments = mapper.Map<List<Appointment>,List<AppointmentFordoctor>>(appointments);
                return Ok(mappedAppointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet]
        [Route("appointmentsPatient/{patientId}")]
        public async Task<ActionResult<IReadOnlyList<AppointmentForpatient>>> GetAppointmentsByPatientId(int patientId)
        {
            try
            {
                var appointments = await appointmentServices.GetAppointmentByPatientId(patientId);
                if (appointments == null || !appointments.Any())
                {
                    return NotFound(); // Handle empty list scenario
                }
                var mappedAppointments = mapper.Map<IReadOnlyList<Appointment>, IReadOnlyList<AppointmentForpatient>>(appointments);
                return Ok(mappedAppointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("appointments/{id}")]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            try
            {
                await appointmentServices.CancelAppointment(id);
                return Ok("Appointment cancelled successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Specific response for not found case
            }
           
        }
    }
 }

