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
        public IUserDataManager userData = new UserDataManager();

        [HttpPost]
        [AuthorizeGuid]
        public IHttpActionResult Session(LoginModel login)
        {
            var guid = userData.Login(login.Username, login.Password);
            if (guid != null)
            {
                return Ok(guid.Value);
            }
            return BadRequest();
        }

        //logout delete from the dict

    }
}
