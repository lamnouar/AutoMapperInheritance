using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMapperInheritance.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            SourcePersonComplement personne = null;
            CreateMap<SourcePerson, DestinationFamily>()
                .BeforeMap((src, dest) => {personne = (SourcePersonComplement)Data.Data.SourceFamilies.FirstOrDefault(x=> x.SourceId == src.SourceId && typeof(SourcePersonComplement).FullName == x.GetType().FullName);
                    
                })
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SourceLastName + (personne!= null? personne.SecondName:string.Empty)));
        }
    }
}
