using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChainGame.Attributes;
using WordChainGame.Models;

namespace WordChainGame.Controllers
{
    public class SessionController : ApiController
    {
        public ILoginManager loginManager = new LoginManager();

        [HttpPost]
        public IHttpActionResult Session(LoginModel login)
        {
            var guid = loginManager.Login(login.Username, login.Password);
            if (guid != null)
            {
                return Ok(guid.Value);
            }
            return BadRequest();
        }

        [HttpDelete]
        [TokenValidation]
        public IHttpActionResult Logout([FromBody] string token)
        {
            if (loginManager.Logout(new Guid(token)))
            {
                return Ok("Succsesful");
            }
            else
            {
                return BadRequest();
            }
            
        }

    }
}
