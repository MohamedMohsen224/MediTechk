using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PresciptionTests : Base
    {
        public int prescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int TestId { get; set; }
        public Tests Test { get; set; }
        public string? TestResult { get; set; }
        public string? Detailsforresult { get; set; }


    }
}
