using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using CrossCutting;
using CrossCutting.Constant;

namespace BLL
{
    public class PopulationBll : IPopulationBll
    {
        readonly Interceptor logger = new Interceptor();
       readonly  PopulationDal populationdal;
       readonly HouseListingDal house;
        public PopulationBll()
        {
            populationdal = new PopulationDal();
            house = new HouseListingDal();
        }
        public bool RegisterMember(PopulationDto member)
        {
            logger.Info(Constant.Messages.BllRegisterMember);
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
