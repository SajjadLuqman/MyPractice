using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using MyProject.BusinessLogic;

namespace MyProject.WebApiServices
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var IsUserExist = new BLUsers().Get().Where(x => x.UserName == context.UserName && x.Password == context.Password).FirstOrDefault();

            if (IsUserExist != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, IsUserExist.Type));
                identity.AddClaim(new Claim("username", IsUserExist.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, IsUserExist.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Email, "sajjad@live.com"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}