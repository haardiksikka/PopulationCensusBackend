using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FinalTest.Models;
using BLL;
using AutoMapper;
using CrossCutting;
using System.Web.Http.Cors;
using System.Web;
using System.IO;
using CrossCutting.Constant;

namespace FinalTest.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        readonly private IMapper mapper;
        private Interceptor logger = new Interceptor();
        readonly private UserBLl userBll;
        readonly private HouseListingBll houseBll;
        readonly private PopulationBll memberBll;
        public UserController()
        {
            userBll = new UserBLl();
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<HouseListing, HouseListingDto>();
                cfg.CreateMap<Population, PopulationDto>();
            });
            houseBll = new HouseListingBll();
            memberBll = new PopulationBll();
            mapper = config.CreateMapper();
        }
        
        //Get method to get all volunteer

        // GET: /getvolunteers      
        // [AllowAnonymous]
        [Route(Constant.Route.GetVolunteers)]
        public List<User> GetVolunteers()
        {
            
                logger.Info(Constant.Messages.FetchingVolunteer);
                List<User> userList = new List<User>();
                var users = userBll.GetAllVolunteer();
                foreach (var user in users)
                {
                    var userInUsers = new User()
                    {
                        UserID = 0,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = null,
                        Email = user.Email,
                        IsApprover = user.IsApprover,
                        VolunteerStatus = user.VolunteerStatus,
                        AdhaarNumber = user.AdhaarNumber,
                        ImageName = user.ImageName,
                    };
                    userList.Add(userInUsers);
                }
                return userList;
            }

            

        

        /* image name is s custom filename, name with which we store the file in our folder */
        //postedfile is contains file object which we got from our frontend
        //file.SaveAs(filepath) save the file at the given path.

        // POST: /register
        [HttpPost]
        [Route(Constant.Route.Register)]
        public bool PostNewUser()
        {


            logger.Info(Constant.Messages.NewUser);
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
           
            var postedFile = httpRequest.Files["Image"];
           
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            User user = new User()
            {
                FirstName = httpRequest["FirstName"],
                LastName = httpRequest["LastName"],
                Password = httpRequest["Password"],
                Email = httpRequest["Email"],
                ImageName = imageName,
                AdhaarNumber = httpRequest["AdhaarNumber"]
            };
            var userDTO = mapper.Map<UserDto>(user);
            return userBll.AddUser(userDTO);
            
            

        }

        //PATCH method to update volunteer status to accepted from pending

        //PATCH: /acceptrequest
        [Route(Constant.Route.AcceptRequest)]
        public bool AcceptVolunteerRequest([FromBody] User user)
        {
            logger.Info(Constant.Messages.AcceptRequest);
            string email = user.Email;
            return userBll.AcceptVolunteerRequest(email);
        }

       //Patch method to decline the volunteer request 

        //PATCH: /declinerequest
        [Route(Constant.Route.DeclineRequest)]
        public bool RejectVolunteerRequest([FromBody] User user)
        {
            logger.Info(Constant.Messages.DeclineRequest);
            string email = user.Email;
            return userBll.RejectVolunteerRequest(email);
        }
        
         
        // Returns Json object contains count of employee working in each industry
        [Route(Constant.Route.GetDataForGraph)]
        public GraphDto GetData()
        {
            logger.Info(Constant.Messages.RequestGraphData);
            return userBll.GetData();
        }


    }
}
