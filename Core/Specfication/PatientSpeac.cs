using Core.Models;
using Core.Specfication;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class PatientSpeac : BaseSpecfication<Patient>
    {
        public PatientSpeac(PatientParams patientParams) : base(x =>
                           (string.IsNullOrEmpty(patientParams.Search) || x.UserName.ToLower().Contains(patientParams.Search) || x.UserName.ToLower().Contains(patientParams.Search)))
                          
        {
            
            Includes.Add(x => x.Department);
            Includes.Add(x => x.prescriptions);
            Includes.Add(x => x.Room);

            

            if (!string.IsNullOrEmpty(patientParams.Sort))
            {
                switch (patientParams.Sort)
                {
                    case "firstNameAsc":
                        AddOrderBy(p => p.UserName);
                        break;
                    case "firstNameDesc":
                        AddOrderByDesc(p => p.UserName);
                        break;
                    default:
                        AddOrderBy(p => p.Id);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Id);
            }

        }

        public PatientSpeac(int Id):base(x=>x.Id==Id)
        {
            Includes.Add(x => x.Department);
            Includes.Add(x => x.prescriptions);
            Includes.Add(x => x.Room);
        




        }

  

    }
}
