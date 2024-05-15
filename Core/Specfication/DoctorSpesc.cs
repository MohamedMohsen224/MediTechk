using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class DoctorSpesc : BaseSpecfication<Doctor>
    {
        public DoctorSpesc(DoctorParms parms)/*:base(x=>(string.IsNullOrEmpty(parms.Search)||x.Doctor_Name.ToLower().Contains(parms.Search)))*/
        { 
           
            Includes.Add(x => x.Clinic);
            AddOrderBy(x => x.Id);
            ApplyPagination(parms.PageSize * (parms.PageIndex - 1), parms.PageSize);
            if (!string.IsNullOrEmpty(parms.Sort))
            {
                switch (parms.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.DisplayName);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(x => x.DisplayName);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        

           
        
        
        
        
        }

        public DoctorSpesc(int DoctorId):base(x=>x.Id==DoctorId)
        {
           
            Includes.Add(x => x.Clinic);
        }

        
    }
}
