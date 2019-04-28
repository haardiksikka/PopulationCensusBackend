using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using DAL.Migrations;
using AutoMapper;
using DAL.Model;
using CrossCutting;
using System.Data.Entity;

namespace DAL.Repository

{
    
   public class UserDal
    {
        private User userEntity;
        readonly private ApplicationContext appContext;
        readonly private IMapper mapper;
        private UserDto userdto;
        public UserDal()
        {
            appContext = new ApplicationContext();         
            MapperConfiguration config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<User, UserDto>();
                });

             mapper = config.CreateMapper();
             userEntity = new User();
            userdto = new UserDto(); 
        }

        public bool AddUser(UserDto user)
        {
            userEntity = mapper.Map<User>(user);
            appContext.User.Add(userEntity);
            appContext.SaveChanges();
            return true;
        }

        public UserDto GetUserByEmail(string email)
        {
            userEntity = appContext.User.FirstOrDefault(user => string.Equals(user.Email, email));

            if (userEntity == null)
            {
                return null;
            }

            userdto = mapper.Map<UserDto>(userEntity);
            return userdto;
        }

        public UserDto GetUserByAdhaar(string adhaar)
        {
            userEntity = appContext.User.SingleOrDefault(user => string.Equals(user.AdhaarNumber, adhaar));

            if (userEntity == null)
            {
                return null;
            }

            userdto = mapper.Map<UserDto>(userEntity);
            return userdto;
        }

        public List<UserDto> GetAllVolunteers()
       {
            var userEntities = appContext.User.Where(user => (user.IsApprover == false));

            List<UserDto> volunteers = new List<UserDto>();
            foreach (var volunteerEntity in userEntities)
            {
                var volunteerList = new UserDto()
                {
                    UserID = volunteerEntity.UserID,
                    FirstName = volunteerEntity.FirstName,
                    LastName = volunteerEntity.LastName,
                    Password = volunteerEntity.Password,
                    Email = volunteerEntity.Email,
                    IsApprover = volunteerEntity.IsApprover,
                    VolunteerStatus = volunteerEntity.VolunteerStatus,
                    AdhaarNumber = volunteerEntity.AdhaarNumber,
                    ImageName = volunteerEntity.ImageName,
                };
                volunteers.Add(volunteerList);
            }
            return volunteers;

        }

        public List<UserDto> GetVolunteer(string email)
        {
            var userEntities = appContext.User.Where(user => string.Equals(user.Email, email));

            List<UserDto> volunteers = new List<UserDto>();
            foreach (var volunteerEntity in userEntities)
            {
                var volunteerList = new UserDto()
                {
                    UserID = volunteerEntity.UserID,
                    FirstName = volunteerEntity.FirstName,
                    LastName = volunteerEntity.LastName,
                    Password = volunteerEntity.Password,
                    Email = volunteerEntity.Email,
                    IsApprover = volunteerEntity.IsApprover,
                    VolunteerStatus = volunteerEntity.VolunteerStatus,
                    AdhaarNumber = volunteerEntity.AdhaarNumber,
                    ImageName = volunteerEntity.ImageName,
                };
                volunteers.Add(volunteerList);
            }
            return volunteers;

        }

        public bool AcceptVolunteerRequest(string email)
        {
            userEntity = appContext.User.FirstOrDefault(user => string.Equals(user.Email, email));
            userEntity.VolunteerStatus = "Accepted";
            appContext.Entry(userEntity).State = EntityState.Modified;

            appContext.SaveChanges();
            return true;
        }
        public bool RejectVolunteerRequest(string email)
        {
            userEntity = appContext.User.FirstOrDefault(user => string.Equals(user.Email, email));
            userEntity.VolunteerStatus = "Declined";
            appContext.Entry(userEntity).State = EntityState.Modified;

            appContext.SaveChanges();
            return true;
        }
    }
}
