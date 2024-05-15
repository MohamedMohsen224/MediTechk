using AutoMapper;
using Core.Models;
using MediTech.Dtos;

namespace MediTech.Helper
{
    public class ProfilePictureUrlResolverForPatient : IValueResolver<Patient, PatientDto, string>
    {
        private readonly IConfiguration conf;

        public ProfilePictureUrlResolverForPatient(IConfiguration conf)
        {
            this.conf = conf;
        }
        public string Resolve(Patient source, PatientDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Profile_Picture))
                return $"{"https://meditech20240428213036.azurewebsites.net"}{source.Profile_Picture}";
            return string.Empty;
        }
    }
}
