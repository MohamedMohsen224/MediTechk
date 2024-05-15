using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Identity
{
    public class Email : Base
    {
        public string subject { get; set; }
        public string body { get; set; }
        public string to { get; set; }
    }
}
