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
    public class PatientController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPatientService patientService;

      

        public PatientController(IMapper mapper, IPatientService patientService )
        {
            this.mapper = mapper;
            this.patientService = patientService;
       
         
        }


        [HttpGet]
        public async Task<ActionResult<PatientDto>> GetAllPaitents([FromQuery] PatientParams patientParams)
        {
            var Patients = await patientService.GetallPatientSpecAsync(patientParams);

            var data = mapper.Map<IReadOnlyList<Patient>, IReadOnlyList<PatientDto>>(Patients);

            return Ok(data);

        }
        [ProducesResponseType(typeof(PatientDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var Patient = await patientService.GetPatientByIdAsync(id);
            if (Patient == null) return NotFound(new ApiErrorResponse(404));
            var MappedPatient = mapper.Map<Patient, PatientDto>(Patient);
            return Ok(MappedPatient);


        }

       
       











    } 
}
