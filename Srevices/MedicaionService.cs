using Core;
using Core.Models;
using Core.Reposatries;
using Core.Services;
using Core.Specfication;
using Microsoft.EntityFrameworkCore;
using Reposatry;
using Reposatry.DAta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class MedicaionService : IMedicationService
    {
        private readonly IUnitOfwork unitOfwork;
        private readonly HospitalContext context;

        public MedicaionService(IUnitOfwork unitOfwork ,HospitalContext context)
        {
            this.unitOfwork = unitOfwork;
            this.context = context;
        }
        public async Task<IEnumerable<Medication>> GetAllMedications(string searchTerm)
        {
            {
                IEnumerable<Medication> medications;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    var spec = new MedictionSpec();
                    medications = await unitOfwork.Repository<Medication>().GetAllSpecAsync(spec);
                }
                else
                {
                    medications = await context.Set<Medication>().Where(m => m.Medication_Name.ToLower().Contains(searchTerm.ToLower())).ToListAsync();
                }

                return medications.Select(m=> new Medication
                {
                    Medication_Name = m.Medication_Name,
                    medication_Price = m.medication_Price,
                    Id = m.Id,
                    IsAvailable = m.IsAvailable,
                    Medication_Type = m.Medication_Type,
                    Expiration_Date = m.Expiration_Date


                });
               
            }
        }
        
    }
}
