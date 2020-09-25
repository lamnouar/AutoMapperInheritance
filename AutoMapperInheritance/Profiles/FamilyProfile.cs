using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;

namespace AutoMapperInheritance.Profiles
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {
            System.Console.WriteLine("nouvelle instance");

            string adresse = string.Empty;
            CreateMap<SourceFamily, DestinationFamily>()
                 .BeforeMap((src, dest) => { Data.Data.Adresses.TryGetValue(src.SourceId, out adresse); })
                    .ForMember(dest => dest.DestinationId, opt => opt.MapFrom(src => src.SourceId))
                    .ForMember(dest => dest.Adresses, opt => opt.MapFrom(_ => adresse))
                    .AfterMap((src, dest) => { adresse = string.Empty; })
                    .IncludeAllDerived();

        }
    }
}
