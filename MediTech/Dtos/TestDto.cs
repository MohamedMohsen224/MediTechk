using Core.Models;
using Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediTech.Dtos
{
    public class TestDto
    {
        public int TestId { get; set; }
        public string TestName { get; set; }       
        public int TestPrice { get; set; }

     
       
    }
}
