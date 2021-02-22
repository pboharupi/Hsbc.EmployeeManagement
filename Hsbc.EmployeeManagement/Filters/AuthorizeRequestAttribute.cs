using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.ServiceModel.Security.Tokens;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Hsbc.EmployeeManagement.BusinessEntities;
using Microsoft.IdentityModel.Tokens;

namespace Hsbc.EmployeeManagement.Filters
{
    public class AuthorizeRequestAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext?.Request?.Headers==null || !AuthorizeRequest(actionContext.Request))
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized) 
                { RequestMessage = actionContext.ControllerContext.Request };
            }
        }
        private bool AuthorizeRequest(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Headers.Contains(Constant.Authorization))
            {
                var token = requestMessage.Headers.GetValues(Constant.Authorization).FirstOrDefault();
                var key = System.Text.Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz");
                var jwtHandler = new JwtSecurityTokenHandler();
                var principal = jwtHandler.ReadJwtToken(token);
                var role = principal.Claims.Where(a => a.Type == "role").FirstOrDefault().Value;
                if (Roles.Split(',').Any(a => a.Equals(role)))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}