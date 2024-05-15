using Core;
using Core.Models;
using Core.Services;
using Core.Specfication;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Srevices
{
    public class PatientServices : IPatientService
    {
        private readonly IUnitOfwork unitOfwork;

        public PatientServices(IUnitOfwork unitOfwork )
        {
            this.unitOfwork = unitOfwork;
        }
        //GetAllPatients
        public async Task<IReadOnlyList<Patient>> GetallPatientSpecAsync(PatientParams patientParams)
        {
            var PatientSpec = new PatientSpeac(patientParams);

            var Patients = await unitOfwork.Repository<Patient>().GetAllSpecAsync(PatientSpec);

            return Patients;
        }
        //GetPaTIENTbyId
        public Task<Patient> GetPatientByIdAsync(int id)
        {
            var Spec = new PatientSpeac(id);
            var Patient = unitOfwork.Repository<Patient>().GetByIdSpecAsync(Spec);
            return Patient;
        }

       

        

       
    }
}
