using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using CrossCutting;
using AutoMapper;

namespace DAL.Repository
{
    public class PopulationDal
    {
        readonly private IMapper mapper;
        private Population memberEntity;
        readonly private ApplicationContext appContext;
        private PopulationDto memberdto;

        public PopulationDal()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HouseListing, HouseListingDto>();
            });

            mapper = config.CreateMapper();
            memberEntity = new Population();
            appContext = new ApplicationContext();
        }
        public bool RegisterMember(PopulationDto memberdto )
        {
            memberEntity = mapper.Map<Population>(memberdto);
            appContext.Population.Add(memberEntity);
            appContext.SaveChanges();
            return true;
        }
    }
}
