using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class AppointmentPATIENTsPEC : BaseSpecfication<Appointment>
    {
        public AppointmentPATIENTsPEC(int PatientId)
            : base(x => x.PatientId == PatientId) {

            OrderByDescending = x => x.AppointmentDateTime;

            Includes.Add(x => x.Doctor);
            Includes.Add(x => x.Patient);
        
        
        }

    }

}
