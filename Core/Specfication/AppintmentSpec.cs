using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class AppintmentSpec: BaseSpecfication<Appointment>
    {
        public AppintmentSpec(int DoctorId)
            : base(x => x.DoctorId == DoctorId)
        {
            OrderBy = x => x.Id;
            Includes.Add(x => x.Doctor);
            Includes.Add(x => x.Patient);
            
        }

    }
}
