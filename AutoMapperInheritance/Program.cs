using AutoMapper;
using AutoMapperInheritance.Dtos.Destination;
using AutoMapperInheritance.Dtos.Sources;
using AutoMapperInheritance.Profiles;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

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
            });

            Data.Data.Adresses = new ConcurrentDictionary<int, string>();
            Data.Data.Adresses.TryAdd<int, string>(1, "new york");
            Data.Data.Adresses.TryAdd<int, string>(2, "chicago");


            var mapper = config.CreateMapper();

            IList<SourceFamily> sourceFamilies = new List<SourceFamily>();
            var sourcePerson = new SourcePerson { SourceId = 1, SourceLastName = "homer" };
            sourceFamilies.Add(sourcePerson);
            var sourceStudent = new SourceStudent { SourceId = 2, SourceFirstName = "marge" };
            sourceFamilies.Add(sourceStudent);

            var destinationFamilies = mapper.Map<IList<SourceFamily>, IList<DestinationFamily>>(sourceFamilies);

            foreach (var family in destinationFamilies)
            {
                System.Console.WriteLine($"id : {family.DestinationId}");
                System.Console.WriteLine($"Name : {family.Name}");
                System.Console.WriteLine($"adresse : {family.Adresses}");
            }

            Console.ReadLine();
        }
    }
}
