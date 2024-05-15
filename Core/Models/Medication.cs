using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Medication : Base
    {
        public string Medication_Name { get; set; }
        public string medication_Description { get; set; }
        public string Medication_Type { get; set; }
        public int Available_Quantity { get; set; }
        public int Medication_Quantity { get { return Available_Quantity; } set { Available_Quantity = (value >= 0) ? value : 0; } }
        public decimal medication_Price { get; set; }
        public DateTime Expiration_Date { get; set; }
        public bool IsAvailable { get; set; }


        public ICollection<PresiptionMedication> Prescriptions { get; set; } = new HashSet<PresiptionMedication>();

      

    }
}

