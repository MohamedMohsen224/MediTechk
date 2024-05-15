using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Digital_x_rays:Base
    {
        public string Name { get; set; }
        public int Price { get; set; }

        //Navigation Properties
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
        public ICollection<PreciptionDigitalxrays> prescriptions { get; set; } = new HashSet<PreciptionDigitalxrays>();
    }
}
