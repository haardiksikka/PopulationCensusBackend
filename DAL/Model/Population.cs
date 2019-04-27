using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Population
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FullNameOfThePerson { get; set; }
        [Required]
        public string RelationshipToHead { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        public int HouseID { get; set; }
        public int? AgeAtMarriage { get; set; }
        [Required]
        public string OccupationStatus { get; set; }
        [Required]
        public string NatureOfOccupation {get; set;}

        [ForeignKey("HouseID")]
        public HouseListing HouseListing { get; set; }
    }
}
