using AutoMapper;
using Core.Models;
using MediTech.Dtos;

namespace MediTech.Helper
{
    public class X_RayResolver : IValueResolver<PreciptionDigitalxrays, GetDigitalXrayResult, string>
    {
        
        
            private readonly IConfiguration configuration;

            public X_RayResolver(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public string Resolve(PreciptionDigitalxrays source, GetDigitalXrayResult destination, string destMember, ResolutionContext context)
            {
                if (string.IsNullOrEmpty(source.ImagePath))
                    return $"{configuration["ApiBaseUrel"]}{source.ImagePath}";
                return string.Empty;
            }
        
    }
}

