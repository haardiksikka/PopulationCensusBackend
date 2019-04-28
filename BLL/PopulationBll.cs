using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using CrossCutting;

namespace BLL
{
    public class PopulationBll
    {
        PopulationDal populationdal;
        HouseListingDal house;
        public PopulationBll()
        {
            populationdal = new PopulationDal();
            house = new HouseListingDal();
        }
        public bool RegisterMember(PopulationDto member)
        {
            if (house.GetHouse(member.CensusHouseNumber) != null)
            {
                return populationdal.RegisterMember(member);
            }
            else
            {
                return false;
            }
        }
    }
}
