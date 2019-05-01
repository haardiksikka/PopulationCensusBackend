using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using CrossCutting.Constant;
using DAL.Repository;
namespace BLL
{
    public class HouseListingBll : IHouseListingBll
    {
        readonly private HouseListingDal houseDal;
        private Interceptor logger = new Interceptor();
        public HouseListingBll()
        {
           
            houseDal = new HouseListingDal();
        }
        public bool RegisterHouse(HouseListingDto house)
        {
            logger.Info(Constant.Messages.BllHouseRegister);
            return houseDal.RegisterHouse(house);
        }
    }
}
