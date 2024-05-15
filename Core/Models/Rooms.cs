using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Rooms : Base
    {
    
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string RoomStatus { get; set; }
        public decimal RoomPrice { get; set; }
        public string Room_Location{ get; set; }
        public string RoomCapacity { get; set; }


        // Navigation property
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Patient> Patients { get; set; } = new HashSet<Patient>();


    }
}
