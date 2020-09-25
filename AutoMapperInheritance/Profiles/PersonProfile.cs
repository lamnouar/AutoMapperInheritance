using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperInheritance.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<SourcePerson, DestinationFamily>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SourceLastName));
        }
    }
}
