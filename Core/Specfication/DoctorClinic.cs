using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class DoctorClinic : BaseSpecfication<Doctor>
    {
        public DoctorClinic(int ClinicId):base(x=>x.ClinicId==ClinicId)
        {
            Includes.Add(x => x.Clinic);
           
            
        }
    }
}
