namespace MediTech.Dtos
{
    public class GetDigitalXrayResult
    {
        public int Id { get; set; }
        public int DigitalXrayid { get; set; }
        public int Presiptionid { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Image { get; set; } 
        public string DigitalXrayName { get; internal set; }
    }

}

