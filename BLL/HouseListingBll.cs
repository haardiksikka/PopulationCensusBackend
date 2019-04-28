using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using DAL.Repository;
namespace BLL
{
    public class HouseListingBll
    {
        readonly private HouseListingDal houseDal;
        public HouseListingBll()
        {
            houseDal = new HouseListingDal();
        }
        public bool RegisterHouse(HouseListingDto house)
        {
            return houseDal.RegisterHouse(house);
        }
    }
}
