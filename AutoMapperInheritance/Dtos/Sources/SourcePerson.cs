using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperInheritance.Dtos.Sources
{
   public  class SourcePerson : SourceFamily
    {
        public string SourceLastName { get; set; }
    }
}
