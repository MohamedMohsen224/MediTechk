namespace Core.Models
{
  public class PreciptionDigitalxrays:Base
   {
       public int PrescriptionId { get; set; }
       public Prescription Prescription { get; set; }
       public int DigitalXRayId { get; set; } 
       public Digital_x_rays DigitalXRay { get; set; }

        public string? Status { get; set; }
        public string? ImagePath { get; set; } 
  }

}
