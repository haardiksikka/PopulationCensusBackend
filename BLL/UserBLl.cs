using System.Collections.Generic;
using CrossCutting;
using CrossCutting.Constant;
namespace BLL
{
   public class UserBLl : IUserBLl
    {
        readonly private UserDto userDTO;
        readonly private DAL.Repository.UserDal usrDAL;
        readonly private DAL.Repository.PopulationDal populationDal;
        readonly private Interceptor logger = new Interceptor();
        public UserBLl()
        {
            usrDAL = new DAL.Repository.UserDal();
            userDTO = new UserDto();
            populationDal = new DAL.Repository.PopulationDal();
        }


        // Bll Request to Dal to Add new User checking uniqueness 
        public bool AddUser(UserDto user)
        {
            logger.Info(Constant.Messages.BllNewUser);
            if (usrDAL.GetUserByEmail(user.Email) == null && usrDAL.GetUserByAdhaar(user.AdhaarNumber) == null)
            {

               return usrDAL.AddUser(user);
                
            }
            else
                return false;
           
        }

        // Bll request to Dal to return all volunteers 
        public List<UserDto> GetAllVolunteer()
        {
            logger.Info(Constant.Messages.BllGetAllVolunteer);                  
           return usrDAL.GetAllVolunteers();

        }

        // Bll request to Dal to update volunteer status
        public bool AcceptVolunteerRequest(string email)
        {
            return usrDAL.AcceptVolunteerRequest(email);
        }

        // Bll request to Dal to update volunteer status
        public bool RejectVolunteerRequest(string email)
        {
            return usrDAL.RejectVolunteerRequest(email);
        }
        //Bll request to Dal to return user by email accepting email
        public UserDto GetUserByEmail(string email)
        {
            return usrDAL.GetUserByEmail(email);
        }

        //Bll request to Dal to return user accepting adhaar
        public UserDto GetUserByAdhaar(string adhaar)
        {
            return usrDAL.GetUserByAdhaar(adhaar);
        }

        public GraphDto GetData()
        {
            return populationDal.GetData();
        }
    }
}
