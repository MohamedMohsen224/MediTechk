namespace MediTech.Dtos
{
    public class MedicationDto
    {
        public int Id { get; set; }
        public string Medication_Name { get; set; }
        public int Doses { get; set; }
        public string Medication_Type { get; set; }
        public decimal medication_Price { get; set; }
        public DateTime Expiration_Date { get; set; }
        public bool IsAvailable { get; set; }
    }
}
