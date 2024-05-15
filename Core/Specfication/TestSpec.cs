using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class TestSpec : BaseSpecfication<Tests>
    {
        public TestSpec()
        { }



        public TestSpec(int PatientId) : base(x => x.Id == PatientId)
        {





        }
    }
}
       

