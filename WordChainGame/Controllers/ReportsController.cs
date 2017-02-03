using System;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChainGame.Attributes;

namespace WordChainGame.Controllers
{
    public class ReportsController : ApiController
    {
        IUserDataManager userData = new UserDataManager();
        IGameManagers gameManager = new GameManager();
        [HttpGet]
        [TokenValidation]
        public IHttpActionResult GetAllReports()
        {
            try
            {
                var res = gameManager.GetAllreportedWords();
                return Ok(res);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

    }
}
