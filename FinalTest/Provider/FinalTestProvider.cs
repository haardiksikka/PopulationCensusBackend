using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using FinalTest.Models;
using System;
using BLL;
using CrossCutting;

namespace FinalTest.Provider
{
   [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FinalTestAuthServerProvider : OAuthAuthorizationServerProvider
    {
        private UserDto userdto = new UserDto();
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
              context.Validated();
         }
         public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
            {
              var identity = new ClaimsIdentity(context.Options.AuthenticationType);
               //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                UserBLl userbll = new UserBLl();
                userdto = userbll.GetUserByEmail(context.UserName);

                if (userdto != null)
                {
                    if(string.Equals(userdto.Password, context.Password))
                   {

                        string role;
                            if (userdto.IsApprover)
                            {
                                role = "Approver";
                            }
                            else
                             {
                                role = "Volunteer";
                             }
                    string status;
                        if (userdto.VolunteerStatus == "Accepted")
                        {
                            status = "Accepted";
                         }
                        else if (userdto.VolunteerStatus.Equals("Pending"))
                        {
                         status = "Pending";
                        }
                        else
                        {
                         status = "Declined";
                        }
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "DisplayName", userdto.FirstName
                                },
                            {
                                "Role", role
                            },
                            {
                                "Status", status
                            }
                            });

                    identity.AddClaim(new Claim("Role", role));
                    identity.AddClaim(new Claim("Id", Convert.ToString(userdto.UserID)));
                    identity.AddClaim(new Claim("Status", status));
                    var ticket = new AuthenticationTicket(identity, props);
                    context.Validated(ticket);
                    }
                    else
                    {
                        context.SetError("invalid_grant, Provided username and password is not matching, Please retry.");
                        context.Rejected();
                    }

            }           
            else
            {
                context.SetError("invalid_grant Provided username and password is not matching, Please retry.");
                context.Rejected();
            }
           
        }
       
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)

        {

            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)

            {

                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            }



            return Task.FromResult<object>(null);

        }


    }
}