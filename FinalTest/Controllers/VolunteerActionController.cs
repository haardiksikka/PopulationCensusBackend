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

namespace FinalTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VolunteerActionController : ApiController
    {
        readonly private IMapper mapper;
        readonly private HouseListingBll houseBll;
        readonly private PopulationBll memberBll;
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

        [HttpPost]
        [Route("house")]
        public bool PostHouseRegistration([FromBody] HouseListing house)
        {
            string[] name = house.NameOfHead.Split(' ');
            string firstName = name[0];
            string lastName = name[1];
            house.CensusHouseNumber = firstName + '_' + lastName + '_' + house.HouseNumber + '_' + house.Street + '_' + house.City + '_' + house.State + '_' + house.Pincode;
            var houseDto = mapper.Map<HouseListingDto>(house);
            return houseBll.RegisterHouse(houseDto);
        }

        // POST /registerhousemember
        [HttpPost]
        [Route("sendmember")]
        public bool HouseMemberRegistration([FromBody]  Population member)
        {
            var populationDto = mapper.Map<PopulationDto>(member);
            return memberBll.RegisterMember(populationDto);


        }
    }
}
