using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalTest.Models;
using BLL;
using AutoMapper;
using CrossCutting;
using System.Web.Http.Cors;
using System.Web;
using System.Diagnostics;
using System.Web.Http;
using System.IO;

namespace FinalTest.Controllers
{
    //[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IMapper mapper;
        
        private UserBLl userBll;
        public UserController()
        {
            userBll = new UserBLl();
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDto>();
            });

            mapper = config.CreateMapper();
        }
        
        
        // GET: /getvolunteers      
        // [AllowAnonymous]
        [Route("getvolunteers")]
        public List<User> GetVolunteers()
        {
            List<User> userList = new List<User>();
            var users= userBll.GetAllVolunteer();
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

        

        // POST: /register
        [HttpPost]
        [Route("register")]
        public bool PostNewUser()
        {
            //var file = value.ImageName;

            //  var userDTO = mapper.Map<UserDto>(value);
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
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
            userBll.AddUser(userDTO);
            return true;
            

        }

        //PATCH: /acceptrequest
        [Route("acceptrequest")]
        public bool AcceptVolunteerRequest([FromBody] User user)
        {
            string email = user.Email;
            return userBll.AcceptVolunteerRequest(email);
        }

       
        //PATCH: /declinerequest
        [Route("declinerequest")]
        public bool RejectVolunteerRequest([FromBody] User user)
        {
            string email = user.Email;
            return userBll.RejectVolunteerRequest(email);
        }

        


    }
}
