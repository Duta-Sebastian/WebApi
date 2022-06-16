using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Server
{
    public class BasicAuthentificationAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(statusCode: System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] numeparolaArray = decoded.Split(':');
                string nume = numeparolaArray[0];
                string parola = numeparolaArray[1];

                if(Securitate.LoginElev(nume,parola))
                {
                    var identity = new GenericIdentity(nume);
                    var principal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = principal;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }    
            }
            base.OnAuthorization(actionContext);
        }
    }
}
