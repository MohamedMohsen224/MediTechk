using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class warehouse : Base
    {
        public string Item { get; set; }
        public int AvailableQuantity { get; set; }
        public int Quantity { get { return AvailableQuantity; } set { AvailableQuantity = (value >= 0) ? value : 0; } }
        public bool IsAvailable { get; set; }
        public ICollection<Medication> Medications { get; set; } = new HashSet<Medication>();
        public DateTime ExpirationDate { get; set; }
    }
}
