namespace Core.Models
{
    public class Nurse : Base
    {
       
        public string Nurse_Name { get; set; }
        public string Nurse_Address { get; set; }
        public string Nurse_Phone { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        public Department Department { get; set; }
        
    }
}