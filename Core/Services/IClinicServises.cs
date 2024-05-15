using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IClinicServises
    {
        public Task<IReadOnlyList<Clinic>> GetAllClinics(ClinicParms parms);
        public Task<Clinic> GetClinicById(int id);
        

    }
}
