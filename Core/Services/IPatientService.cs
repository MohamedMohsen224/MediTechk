using Core.Models;
using Core.Specfication;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IPatientService
    {
        Task<IReadOnlyList<Patient>> GetallPatientSpecAsync(PatientParams patientParams);

        Task<Patient> GetPatientByIdAsync(int Patientid);




    }
}
