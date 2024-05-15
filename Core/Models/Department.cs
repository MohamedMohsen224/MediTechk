using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Department:Base
    {

        public string Department_Name { get; set; }
        public string Department_Description { get; set; }
   
        // Navigation properties
        public ICollection<Nurse> Nurses { get; set; } = new HashSet<Nurse>(); 
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();
        public ICollection<Rooms> Rooms { get; set; } = new HashSet<Rooms>();
    }
}
