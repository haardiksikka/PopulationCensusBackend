using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Constant
{
    public static class Constant
    {
        public struct Route
        {
            public const string HouseMemberRegistration = "sendmember";
            public const string HouseRegistration = "house";
            public const string GetVolunteers = "getvolunteers";
            public const string Register = "register";
            public const string AcceptRequest = "acceptrequest";
            public const string DeclineRequest = "declinerequest";
            public const string GetDataForGraph = "getdata";
        }

        public struct Messages
        {
            public const string NewUserRequest = "Controller request to bll register new User";
            public const string NewHouseRequest = "Controller request to bll to register new house";
            public const string RequestGraphData = "Requesting Data for Graph";
            public const string DeclineRequest = "Controller Requesting bll to decline volunteer request";
            public const string AcceptRequest = "accepting volunteer request";
            public const string NewUser = "Registering new User";
            public const string FetchingVolunteer = "Fetching all Volunteers";
            public const string BllHouseRegister = "Bll requesting Dal to register house";
            public const string BllRegisterMember = "Bll requesting dal to register new Member";
            public const string BllNewUser = "Bll requesting dal to register new user";
            public const string BllGetAllVolunteer = "Bll Request to Dal to return all volunteer";
        }

    }
}
