using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;
using AutoMapperInheritance.Profiles;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FamilyProfile>();
                cfg.AddProfile<PersonProfile>();
                cfg.AddProfile<StudentProfile>();
               cfg.AddProfile<SourcePersonneComplementProfile>();     
            });

            Data.Data.Adresses = new ConcurrentDictionary<int, string>();
            Data.Data.Adresses.TryAdd<int, string>(1, "new york");
            Data.Data.Adresses.TryAdd<int, string>(2, "chicago");

            Data.Data.SourceFamilies = new List<SourceFamily>();

           

            var sourcePerson = new SourcePerson { SourceId = 1, SourceLastName = "homer" };
            Data.Data.SourceFamilies.Add(sourcePerson);
            var sourcePersonComplement = new SourcePersonComplement { SourceId = 1, SecondName = "simpson" };
            Data.Data.SourceFamilies.Add(sourcePersonComplement);
            var sourceStudent = new SourceStudent { SourceId = 2, SourceFirstName = "marge" };
            Data.Data.SourceFamilies.Add(sourceStudent);

            var mapper = config.CreateMapper();

            var destinationFamilies = mapper.Map<IList<SourceFamily>, IList<DestinationFamily>>(Data.Data.SourceFamilies);
            destinationFamilies = destinationFamilies.Where(x => x.DestinationId > 0).ToList();

            foreach (var family in destinationFamilies)
            {
                Console.WriteLine(family.GetType());
                System.Console.WriteLine($"id : {family.DestinationId}");
                System.Console.WriteLine($"Name : {family.Name}");
                System.Console.WriteLine($"adresse : {family.Adresses}");
            }

            Console.ReadLine();
        }
    }
}
