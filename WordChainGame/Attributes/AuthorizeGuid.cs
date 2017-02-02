using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WordChainGame.Attributes
{
    public class AuthorizeGuid : AuthorizeAttribute
    {
        public static ConcurrentDictionary<Guid, int> activeUsers = new ConcurrentDictionary<Guid, int>();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Task<string> content = actionContext.Request.Content.ReadAsStringAsync();
            string body = content.Result;

            var username = content.Result.Split('&')[0].Split('=')[1];
            var password = content.Result.Split('&')[1].Split('=')[1];
        }
    }
}