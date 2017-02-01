using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;

namespace WordChainGame.Controllers
{
    public class TopicsController : ApiController
    {
        IUserDataManager userData = new UserDataManager();
        IGameManagers gameManager = new GameManager();

        [HttpPost]
       public int Create(Topic tp)
        {
          var id =  gameManager.Create(tp);
            return id;
        }

        [HttpGet]
        public List<Topic> GetAllTopics()
        {
            return null;
        }

    }
}
