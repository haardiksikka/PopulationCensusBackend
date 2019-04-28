using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class HouseListing
    {
        [Key]
        public int HouseID { get; set; }
        [Required]
        public string NameOfHead { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public string Pincode { get; set; }
          
        [Required]
        public string OwnershipStatus { get; set; }
       
        [Required]
        public string NumberOfRooms { get; set; }

        [Required]
        public string CensusHouseNumber { get; set; }

    }
}
