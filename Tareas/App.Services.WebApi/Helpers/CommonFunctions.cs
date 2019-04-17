using System;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.Services.WebApi.Helpers
{
    public class CommonFunctions
    {
        public static int GetUserID()
        {
            var userData = GetClaimByType("usuarioID").FirstOrDefault();
            int id = 0;
            if (userData != null)
            {
                id = Convert.ToInt32(userData.Value);
            }
            return id;
        }      

        public static string GetRolesByUser()
        {
            var roles = GetClaimByType(ClaimTypes.Role);
            string rolesString = "";
            foreach (var role in roles)
            {
                rolesString += role.Value + ";";
            }

            return rolesString;
        }


        public static IEnumerable<Claim> GetClaimByType(string type)
        {
            //ClaimTypes.UserData.ToString()
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            IEnumerable<Claim> claims = identity.Claims
                                        .Where(item => item.Type == type).ToList();

            return claims;
        }

        public static string GetClaimFromAuthResponse(OAuthTokenEndpointResponseContext context, string key)
        {
            IEnumerable<Claim> claims = context.Identity.Claims
                                        .Where(item => item.Type == key).ToList();

            string result = "";
            if (claims != null)
            {
                result = claims.FirstOrDefault().Value;
            }
            return result;
        }
    }
}