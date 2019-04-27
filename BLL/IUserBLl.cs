using System.Collections.Generic;
using CrossCutting;

namespace BLL
{
    public interface IUserBLl
    {
        bool AcceptVolunteerRequest(string email);
        bool AddUser(UserDto user);
        List<UserDto> GetAllVolunteer();
        UserDto GetUserByAdhaar(string adhaar);
        UserDto GetUserByEmail(string email);
        bool RejectVolunteerRequest(string email);
    }
}