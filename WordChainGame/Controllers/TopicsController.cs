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
        public IEnumerable<TopicView> GetAllTopics(int skip, int take, string orderBy)
        {
           return gameManager.GetAllTopics(skip, take, orderBy);
        }

        [HttpGet]
        public IEnumerable<Word> GetAllWords(int name, int skip, int take)
        {
            return gameManager.GetAllWordsInTopic(name,skip,take);
        }

        [HttpPost]
        public void AddWordToTopic(int topic, string word)
        {
            gameManager.AddWord(word, topic);
        }

        [HttpDelete]
        public void DeleteWord(int name, int word)
        {
            gameManager.DeleteWord(name, word);
        }

    }
}
