using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting
{
   public class PopulationDto
    {
        public int ID { get; set; }
        public string CensusHouseNumber { get; set; }
       
        public string NameOfPerson { get; set; }
       
        public string RelationshipToHead { get; set; }
        
        public string Gender { get; set; }
       
        public DateTime DateOfBirth { get; set; }
    
        public int Age { get; set; }
      
        public string MaritalStatus { get; set; }
        public int? AgeAtMarriage { get; set; } = 0;

        public string OccupationStatus { get; set; }

        public string OccupationIndustry { get; set; }

        public int Income { get; set; } = 0;
    }
}
