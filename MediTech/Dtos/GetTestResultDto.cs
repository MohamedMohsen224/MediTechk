using Core.Models;

namespace MediTech.Dtos
{
    public class GetTestResultDto
    {
        public int Id { get; set; }
        public int PresiptionId { get; set; }
        public int TestId { get; set; }
        public string TestName { get; set; } 
        public string Result { get; set; }
        public string DetailsForResult { get; set; }


    }
}
