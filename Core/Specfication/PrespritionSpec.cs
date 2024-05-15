using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class PrespritionSpec : BaseSpecfication<Prescription>
    {
        public PrespritionSpec(int PatientId) : base(x => x.PatientId == PatientId)
        {
            Includes.Add(x => x.Patient);
            Includes.Add(x => x.Doctor);
            Includes.Add(p => p.Medications);
            Includes.Add(p => p.Tests);
            Includes.Add(p => p.X_Rays);





        }



    }
    }
