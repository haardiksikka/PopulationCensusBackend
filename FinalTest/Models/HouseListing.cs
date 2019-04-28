using System.ComponentModel.DataAnnotations;


namespace FinalTest.Models
{
    public class HouseListing
    {
        
        public int HouseID { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string NameOfHead { get; set; }
        [Required(ErrorMessage = "House Number is Required")]
        public string HouseNumber { get; set; }
        [Required(ErrorMessage = "Street is Required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Pincode is Required")]
        public int Pincode { get; set; }
        [Required(ErrorMessage = "Ownership Status is Required")]
        public string OwnershipStatus { get; set; }
        [Required(ErrorMessage = "Number of Rooms is Required")]
        public int NumberOfRooms { get; set; }
        [Required(ErrorMessage = "CensusNumber is Required")]
        public string CensusHouseNumber { get; set; } = null;

    }
}