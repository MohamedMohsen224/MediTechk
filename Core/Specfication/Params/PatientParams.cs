using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication.Params
{
    public class PatientParams
    {
        
        public string? Sort { get; set; }
        private string? _search;


        public string? Search
        {
            get => _search;
            set => _search = value?.ToLower();
        }
    }
}

