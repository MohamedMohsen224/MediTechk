using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDoctorServises
    {
        public Task<IReadOnlyList<Doctor>> GetDoctorsAsync(DoctorParms parms);
        public Task<Doctor> GetDoctorByIdAsync(int DoctorId);
        public Task<IReadOnlyList<Doctor>> GetDoctorByClinicIdAsync(int ClinicId);

    }
}
