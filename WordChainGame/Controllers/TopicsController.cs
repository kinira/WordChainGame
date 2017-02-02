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
        IGameManagers gameManager = new GameManager();

        [HttpPost]
       public IHttpActionResult Create([FromBody] string topicName)
        {
            try
            {
                var id = gameManager.Create(topicName);
                return Created("Topic",id);
            }
            catch (Exception)
            {

               return BadRequest();
            }
         
        }

        [HttpGet]
        public IHttpActionResult GetAllTopics(int skip, int take, string orderBy)
        {
            try
            {
                var res = gameManager.GetAllTopics(skip, take, orderBy);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllWords(int name, int skip, int take)
        {
            try
            {
                var res = gameManager.GetAllWordsInTopic(name, skip, take);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IHttpActionResult AddWordToTopic(int topic, string word)
        {
            try
            {
                var id = gameManager.AddWord(word, topic);
                return Created("Word",id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
           
        }

        [HttpDelete]
        public IHttpActionResult DeleteWord(int name, int word)
        {
            try
            {
                gameManager.DeleteWord(name, word);
                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
