using Core;
using Core.Models;
using Core.Specfication;
using Reposatry;
using Reposatry.DAta;
using System.Numerics;

namespace AdminPanel.services
{
    public class DoctorServices : IDoctorServices
    {
        private readonly IUnitOfwork unitOfwork;

        public DoctorServices(IUnitOfwork unitOfwork)
        {
            this.unitOfwork = unitOfwork;
        }
       
      

      

       
    }
}
