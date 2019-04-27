using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;
using DAL;
namespace BLL
{
   public class UserBLl : IUserBLl
    {
        private UserDto userDTO;
        private DAL.Repository.UserDal usrDAL;
        public UserBLl()
        {
            usrDAL = new DAL.Repository.UserDal();
            userDTO = new UserDto();
        }

        public bool AddUser(UserDto user)
        {
            if (usrDAL.GetUserByEmail(user.Email) == null && usrDAL.GetUserByAdhaar(user.AdhaarNumber) == null)
            {

               return usrDAL.AddUser(user);
                
            }
            else
                return false;
           
        }

        public List<UserDto> GetAllVolunteer()
        {
                              
           return usrDAL.GetAllVolunteers();

        }

        public bool AcceptVolunteerRequest(string email)
        {
            return usrDAL.AcceptVolunteerRequest(email);
        }
        public bool RejectVolunteerRequest(string email)
        {
            return usrDAL.RejectVolunteerRequest(email);
        }

        public UserDto GetUserByEmail(string email)
        {
            return usrDAL.GetUserByEmail(email);
        }

        public UserDto GetUserByAdhaar(string adhaar)
        {
            return usrDAL.GetUserByAdhaar(adhaar);
        }
    }
}
