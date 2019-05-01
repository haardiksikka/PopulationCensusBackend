using CrossCutting;

namespace BLL
{
    public interface IHouseListingBll
    {
        bool RegisterHouse(HouseListingDto house);
    }
}