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
    public class DoctorServises : IDoctorServises
    {
        private readonly IUnitOfwork unitOfwork;
        //Ctor
        public DoctorServises(IUnitOfwork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }

        //GetDoctorWithClinic
        public async Task<IReadOnlyList<Doctor>> GetDoctorByClinicIdAsync(int ClinicId)
        {
            var spec = new DoctorClinic(ClinicId);
            var Doctor = await unitOfwork.Repository<Doctor>().GetAllSpecAsync(spec);
            return Doctor;
        }
        //GetDoctorWithId
        public Task<Doctor> GetDoctorByIdAsync(int DoctorId)
        {
            var spec = new DoctorSpesc(DoctorId);
            var Doctor = unitOfwork.Repository<Doctor>().GetByIdSpecAsync(spec);
            return Doctor;
        }
        //GetDoctors
        public async Task<IReadOnlyList<Doctor>> GetDoctorsAsync(DoctorParms parms)
        {
            var DoctorSpec = new DoctorSpesc(parms);

            var doctors = await unitOfwork.Repository<Doctor>().GetAllSpecAsync(DoctorSpec);

            return doctors;
        }
    }
}
