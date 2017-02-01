using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChain.Data.Models;

namespace WordChain.Data.DataAccess
{
    public class GameManager : IGameManagers
    {
        public static WordChainContext db = new WordChainContext();
        public void AddWord(string word, string topic)
        {
            if (!db.BadWords.Any(x=>x.Name == word))
            {
                var getId = db.Topics.FirstOrDefault(x => x.Name == topic);
                if (getId != null)
                {
                    var w = new Word();
                    w.Name = word;
                    w.TopicId = getId.Id;
                    //authorIdwillbeTakedAfterAuth
                }
                throw new Exception("The topic doesn't exists!");
            }
            throw new Exception("The word is already marked as bad!");
        }

        public void AddWordToBad(string badWord)
        {
            db.BadWords.Add(new BadWord() { Name = badWord });
            db.SaveChanges();
        }

        public int Create(Topic tp)
        {
            db.Topics.Add(tp);
            db.SaveChanges();
            var id = db.Topics.FirstOrDefault(x => x.Name == tp.Name);
            return id.Id;
        }

        public List<Report> GetAllreportedWords()
        {
            return db.Reports.ToList();
        }

        public List<TopicView> GetAllTopics(int skip, int take, string orderBy)
        {
            var topic = db.Topics.ToList();
            var result = new List<TopicView>();
            result.AddRange(topic.Select(x=>x.))

        }

        public List<Word> GetAllWords(int id)
        {
            var all = db.Words.Where(x => x.TopicId == id).ToList();
            return all;
        }

        public void ReportWord(string word, string topic)
        {
            var report = new Report();
            report.TopicId = int.Parse(topic);
            report.WordId = int.Parse(word);
            //get reporter from auth
            db.Reports.Add(report);
            
        }
    }
}
