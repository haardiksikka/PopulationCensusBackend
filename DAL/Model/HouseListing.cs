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
        public string HouseNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string NameOfHead { get; set; }     
        [Required]
        public string OwnerShipStatus { get; set; }
       
        public string NumberOfRooms { get; set; }

    }
}
