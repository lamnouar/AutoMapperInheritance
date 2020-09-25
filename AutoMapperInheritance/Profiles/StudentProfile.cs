using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;

namespace AutoMapperInheritance.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<SourceStudent, DestinationFamily>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SourceFirstName));
        }
    }
}
