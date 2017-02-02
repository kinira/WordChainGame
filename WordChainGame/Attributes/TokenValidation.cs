using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Collections.Concurrent;

namespace WordChainGame.Attributes
{
    public class TokenValidation : ActionFilterAttribute
    {
        public static ConcurrentDictionary<Guid, int> activeUsers = new ConcurrentDictionary<Guid, int>();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string token;

            try
            {
                token = actionContext.Request.Headers.GetValues("Auth-Token").First();
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing Authorization-Token")
                };
                return;
            }

            try
            {
                var key = new Guid(token);
                var userID = activeUsers[key];
                base.OnActionExecuting(actionContext);
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized User")
                };
                return;
            }
        }
    }
}