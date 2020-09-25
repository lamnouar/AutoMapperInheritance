using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;

namespace AutoMapperInheritance.Profiles
{
    public class SourcePersonneComplementProfile : Profile
    {
        public SourcePersonneComplementProfile()
        {
            CreateMap<SourcePersonComplement, DestinationFamily>()
                    .ForAllMembers(dest => dest.Ignore());
        }
    }
}
