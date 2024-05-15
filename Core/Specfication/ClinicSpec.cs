using Core.Models;
using Core.Specfication.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specfication
{
    public class ClinicSpec : BaseSpecfication<Clinic>
    {
        public ClinicSpec(ClinicParms parms) 
        {
           
            Includes.Add(x => x.Doctors);
            AddOrderBy(x => x.Id);
            ApplyPagination(parms.PageSize * (parms.PageIndex - 1), parms.PageSize);
            if (!string.IsNullOrEmpty(parms.Sort))
            {
                switch (parms.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(x => x.Clinic_Name);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(x => x.Clinic_Name);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }
        public ClinicSpec(int Id):base(P=>P.Id == Id)
        {
            Includes.Add(x => x.Doctors); 
        }


    }
}
