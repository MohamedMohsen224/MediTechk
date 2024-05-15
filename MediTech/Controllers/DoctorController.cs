using AutoMapper;
using Core.Models;
using Core.Services;
using Core.Specfication;
using Core.Specfication.Params;
using MediTech.Dtos;
using MediTech.Errors;
using MediTech.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Srevices;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IDoctorServises doctorServises;

        public DoctorController(IMapper mapper,IDoctorServises doctorServises )
        {
            this.mapper = mapper;
            this.doctorServises = doctorServises;
        }

        [HttpGet]
        public async Task<ActionResult<DoctorDto>> GetAllDoctors([FromQuery]DoctorParms parms)
        {
            var doctors = await doctorServises.GetDoctorsAsync(parms);

            var data = mapper.Map<IReadOnlyList<Doctor>, IReadOnlyList<DoctorProfile>>(doctors);

            return Ok(data);
        }

        [ProducesResponseType(typeof(DoctorProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorProfile>> GetDoctorById(int id)
        {
            var doctor = await doctorServises.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();
            var MappedDoctor = mapper.Map<Doctor, DoctorProfile>(doctor);
            return Ok(MappedDoctor);
        }


        [HttpGet("Doctor/{ClinicId}")]
        public async Task<ActionResult<IReadOnlyList<DoctorDto>>> GetDoctorwithClinicId(int ClinicId)
        {
            var Doctor =  await doctorServises.GetDoctorByClinicIdAsync(ClinicId);
            if(Doctor == null) return NotFound();
            var mappedDoctor = mapper.Map<IReadOnlyList<Doctor>,IReadOnlyList<DoctorDto>>(Doctor);
            return Ok(mappedDoctor);

        }
    }
}
