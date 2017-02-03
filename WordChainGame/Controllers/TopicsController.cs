using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;
using WordChainGame.Attributes;

namespace WordChainGame.Controllers
{
    public class TopicsController : ApiController
    {
        IGameManagers gameManager = new GameManager();

        [HttpPost]
        [TokenValidation]
        public IHttpActionResult Create(Topic name)
        {
            try
            {
                var id = gameManager.Create(name.Name);
                return Created("Topic",id);
            }
            catch (Exception ex)
            {

               return BadRequest();
            }
         
        }

        [HttpGet]
        [TokenValidation]
        public IHttpActionResult GetAllTopics(int skip, int take, string orderBy)
        {
            try
            {
                var res = gameManager.GetAllTopics(skip, take, orderBy);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [TokenValidation]
        public IHttpActionResult GetAllWords(int name, int skip, int take)
        {
            try
            {
                var res = gameManager.GetAllWordsInTopic(name, skip, take);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [TokenValidation]
        public IHttpActionResult AddWordToTopic(int name, [FromBody] string word)
        {
            try
            {
                var id = gameManager.AddWord(word, name);
                return Created("Word",id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
        }

        [HttpDelete]
        [TokenValidation]
        public IHttpActionResult DeleteWord(int name, int word)
        {
            try
            {
                gameManager.DeleteWord(name, word);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
