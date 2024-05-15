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
    public class ClinicServises : IClinicServises
    {
        private readonly IUnitOfwork unitOfwork;

        public ClinicServises(IUnitOfwork unitOfwork )
        {
            this.unitOfwork = unitOfwork;
        }
        //GetAllClnics
        public async Task<IReadOnlyList<Clinic>> GetAllClinics(ClinicParms parms)
        {
              var ClinicSpec = new ClinicSpec(parms);

            var Clinics = await unitOfwork.Repository<Clinic>().GetAllSpecAsync(ClinicSpec);


            return Clinics;
           
        }

        //GetClinicBYid
        public async Task<Clinic> GetClinicById(int id)
        {
            var spec = new ClinicSpec(id);
            var clinic = await unitOfwork.Repository<Clinic>().GetByIdSpecAsync(spec);
            return clinic;
        }
    }
}
