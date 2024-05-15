using AutoMapper;
using Core.Models;
using Core.Services;
using MediTech.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationService _medicationService;
        private readonly IMapper mapper;

        public MedicationController(IMedicationService medicationService ,IMapper mapper)
        {
            _medicationService = medicationService;
            this.mapper = mapper;
        }

            [HttpGet]
            public async Task<ActionResult<MedicationDto>> GetMedications([FromQuery] string searchTerm = null)
            {
                var medications = await _medicationService.GetAllMedications(searchTerm);
                var medicationsDto = mapper.Map<IEnumerable<Medication>,IEnumerable<MedicationDto>>(medications);
                return Ok(medicationsDto);
            }
    }
}
