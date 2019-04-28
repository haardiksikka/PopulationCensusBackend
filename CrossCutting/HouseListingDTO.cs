using System.ComponentModel.DataAnnotations;


namespace CrossCutting
{
    public class HouseListingDto
    {
        public int HouseID { get; set; }

        public string NameOfHead { get; set; }

        public string HouseNumber { get; set; }
        
        public string City { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public int Pincode { get; set; }

        public string OwnershipStatus { get; set; }

        public string NumberOfRooms { get; set; }

        public string CensusHouseNumber { get; set; }
    }
}
