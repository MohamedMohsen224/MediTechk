using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class DigitalXraySpec : BaseSpecfication<Digital_x_rays>
    {
        public DigitalXraySpec()
        {
            
        }

        public DigitalXraySpec(int PatientId) : base(x => x.Id == PatientId)
        {
          
        }

    }
}
