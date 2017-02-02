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
    public class ReportsController : ApiController
    {
        IUserDataManager userData = new UserDataManager();
        IGameManagers gameManager = new GameManager();
        [HttpGet]
        public IEnumerable<Report> GetAllReports()
        {
            return gameManager.GetAllreportedWords();
        }

    }
}
