using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;
using AutoMapper;
using DAL.Model;

namespace DAL.Repository
{
    public class HouseListingDal
    {
        readonly private IMapper mapper;
        private HouseListing houseEntity;
        readonly private ApplicationContext appContext;
        private HouseListingDto housedto;
        public HouseListingDal()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HouseListing, HouseListingDto>();
            });

            mapper = config.CreateMapper();
            houseEntity = new HouseListing();
            appContext = new ApplicationContext();

        }

        public HouseListingDto GetHouse(string censusHouseNumber)
        {
            var house = appContext.HouseListing.FirstOrDefault(h => censusHouseNumber.Equals(h.CensusHouseNumber));
            var houseDto = mapper.Map<HouseListingDto>(house);
            if (houseDto == null)
                return null;
            else
                return houseDto;
        }

        public bool RegisterHouse(HouseListingDto house)
        {

            houseEntity = mapper.Map<HouseListing>(house);
            appContext.HouseListing.Add(houseEntity);
            appContext.SaveChanges();
            return true;
        }
    }
}
