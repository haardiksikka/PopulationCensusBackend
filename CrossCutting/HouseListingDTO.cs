using System.ComponentModel.DataAnnotations;


namespace CrossCutting
{
    public class HouseListingDTO
    {
        public int HouseID { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "House Number is Required")]
        public int HouseNumber { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "Pincode is Required")]
        public int Pincode { get; set; }
        [Required(ErrorMessage = "CensusNumber is Required")]
        public string CensusHouseNumber { get; set; }
    }
}
