using Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Tests :Base
    {
        public string TestName { get; set; }
        public int TestPrice { get; set; }
        //Navigation Properties
        public ICollection<Booking> Bookings { get; set; }= new HashSet<Booking>();
        public ICollection<PresciptionTests> Prescriptions { get; set; } = new HashSet<PresciptionTests>();
    }
}