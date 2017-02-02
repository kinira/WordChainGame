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
        public int AddWord(string word, int topic)
        {
            if (!db.BadWords.Any(x => x.Name == word))
            {
                var getId = db.Topics.FirstOrDefault(x => x.Id == topic);
                if (getId != null)
                {
                    if (!db.Words.Any(x=>x.Name == word && x.TopicId == topic))
                    {
                        var w = new Word();
                        w.Name = word;
                        w.TopicId = getId.Id;
                        //authorIdwillbeTakedAfterAuth
                        db.Words.Add(w);
                        db.SaveChanges();
                        return w.Id;
                    }
                    else
                        throw new Exception("The same word already doesn't exists!");

                }
                else
                throw new Exception("The topic doesn't exists!");
            }
            else
            throw new Exception("The word is already marked as bad!");
        }



        public void AddWordToBad(string badWord)
        {
            db.BadWords.Add(new BadWord() { Name = badWord });
            db.SaveChanges();
        }

        public int Create(string topicName)
        {
            var topic = new Topic();
            topic.Name = topicName;

            if (!db.Topics.Contains(topic))
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return topic.Id;
            }
            else
            {
                throw new ArgumentException();
            }
          
        }

        public void DeleteWord(int TopicId, int wordId)
        {
            var badWord = db.Words.First(x => x.Id == wordId && x.TopicId == TopicId);
            AddWordToBad(badWord.Name);
            db.Words.Remove(badWord);
            db.SaveChanges();
        }

        public List<Report> GetAllreportedWords()
        {
            return db.Reports.ToList();
        }

        public IEnumerable<TopicView> GetAllTopics(int skip, int take, string orderBy)
        {
            var topics = db.Topics.ToList();
            var result = topics.Select(x =>
             new TopicView()
             {
                 Name = x.Name,
                 Author = x.Author.Username,
                 WordsCount = db.Words.Count(y => y.TopicId == x.Id)
             });

            result = result.Skip(skip).Take(take);

            switch (orderBy)
            {
                case "name": return result.OrderBy(x => x.Name);
                case "count": return result.OrderBy(x => x.WordsCount);
                default:
                    return result;
            }
        }        

        public IEnumerable<Word> GetAllWordsInTopic(int topic, int skip, int take)
        {
            var words = db.Words.Where(x => x.TopicId == topic);
            return words.Skip(skip).Take(take);
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
