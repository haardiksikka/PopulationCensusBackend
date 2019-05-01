using System.Linq;
using DAL.Model;
using CrossCutting;
using AutoMapper;
using System;

namespace DAL.Repository
{
    public class PopulationDal
    {
        readonly private IMapper mapper;
        private Population memberEntity;
        readonly private ApplicationContext appContext;

        public PopulationDal()
        {

            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HouseListing, HouseListingDto>();
            });

            mapper = config.CreateMapper();
            memberEntity = new Population();
            appContext = new ApplicationContext();
        }

        //Register new Member
        public bool RegisterMember(PopulationDto memberdto )
        {
            appContext.Database.Log = s => { System.Diagnostics.Debug.WriteLine(s); };
            memberEntity = mapper.Map<Population>(memberdto);
            try
            {
                appContext.Population.Add(memberEntity);
                appContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        //Returns Count of employeed in each industry
        public GraphDto GetData()
        {
            appContext.Database.Log = s => { System.Diagnostics.Debug.WriteLine(s); };
            GraphDto graphdata = new GraphDto();
            graphdata.Agriculture = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Agriculture"));
            graphdata.Software = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Software"));
            graphdata.Management = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Management"));
            graphdata.Entertainment = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Entertainment"));
            graphdata.Other = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Other"));
            graphdata.HAndT = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Hospitality and Tourism"));
            graphdata.EducationAndTraining = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Education and Training"));
            graphdata.Manufacturing = appContext.Population.Count(p => string.Equals(p.OccupationIndustry, "Manufacturing"));
            return graphdata;
        }
    }
}
