using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using BLL;
using FinalTest.Models;
using CrossCutting;
using CrossCutting.Constant;

namespace FinalTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VolunteerActionController : ApiController
    {
        readonly private IMapper mapper;
        readonly private HouseListingBll houseBll;
        readonly private PopulationBll memberBll;
        readonly private Interceptor logger = new Interceptor();

        public VolunteerActionController()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HouseListing, HouseListingDto>();
                cfg.CreateMap<Population, PopulationDto>();
            });

            mapper = config.CreateMapper();
            houseBll = new HouseListingBll();
            memberBll = new PopulationBll();
        }

        // Model request to Bll to Register to new House
        [HttpPost]
        [Route(Constant.Route.HouseRegistration)]
        public bool PostHouseRegistration([FromBody] HouseListing house)
        {

            logger.Info(Constant.Messages.NewHouseRequest);
            string[] name = house.NameOfHead.Split(' ');
            string firstName;
            string lastName;
            if (name.Length >= 2)
            {
                 firstName= name[0];
                lastName= name[name.Length-1];
            }
            else
            {
                firstName = name[0];
                lastName = "";
            }
                
            house.CensusHouseNumber = firstName + '_' + lastName + '_' + house.HouseNumber + '_' + house.Street + '_' + house.City + '_' + house.State + '_' + house.Pincode;
            var houseDto = mapper.Map<HouseListingDto>(house);
            return houseBll.RegisterHouse(houseDto);
        }

        // Model to request to Blll register to new Member
        // POST /registerhousemember
        [HttpPost]
        [Route(Constant.Route.HouseMemberRegistration)]
        public bool HouseMemberRegistration([FromBody]  Population member)
        {
            logger.Info(Constant.Messages.NewUserRequest);
            var populationDto = mapper.Map<PopulationDto>(member);
            return memberBll.RegisterMember(populationDto);
        }
    }
}
