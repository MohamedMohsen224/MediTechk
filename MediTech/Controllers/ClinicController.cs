using AutoMapper;
using Core.Models;
using Core.Services;
using Core.Specfication.Params;
using MediTech.Dtos;
using MediTech.Errors;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IClinicServises clinicServises;

        public ClinicController(IMapper mapper , IClinicServises clinicServises)
        {
            this.mapper = mapper;
            this.clinicServises = clinicServises;
        }

        [HttpGet("AllClinics")]
        public async Task<ActionResult<IReadOnlyList<ClinicDto>>> GetClinics([FromQuery] ClinicParms parms)
        {
            var Clinics = await clinicServises.GetAllClinics(parms);
            var ClinicDto = mapper.Map<IReadOnlyList<Clinic>, IReadOnlyList<ClinicDto>>(Clinics);
            if (Clinics == null) return NotFound(new ApiErrorResponse(404));
            return Ok(ClinicDto);
        }

        [HttpGet("Clinic/{id}")]
        public async Task<ActionResult<ClinicDto>> GetClinicWIthid(int Id)
        {
            var cilnic = await clinicServises.GetClinicById(Id);
            var clinicdto = mapper.Map<Clinic, ClinicDto>(cilnic);
            if (clinicdto == null) return NotFound(new ApiErrorResponse(404, "The clinic is not exsisit"));
            return Ok(clinicdto);

        }
    }
}
