using AutoMapper;
using Core.Models;
using MediTech.Dtos;

namespace MediTech.Helper
{
    public class ProfilePictureUrlResolverForDoctor : IValueResolver<Doctor, DoctorDto, string>
    {
        private readonly IConfiguration configuration;

        public ProfilePictureUrlResolverForDoctor(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Doctor source, DoctorDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Profile_Picture))
                return $"{"ApiBaseUrl"}{source.Profile_Picture}";
            return string.Empty;
        }
    }
}
