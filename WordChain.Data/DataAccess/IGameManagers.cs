using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChain.Data.Models;

namespace WordChain.Data.DataAccess
{
    public interface IGameManagers
    {
        int Create(Topic tp);
        void AddWord(string word, int topic);
        void ReportWord(string word, string topic);
        List<Report> GetAllreportedWords();
        void AddWordToBad(string badWord);
        IEnumerable<TopicView> GetAllTopics(int skip, int take, string orderBy);
        IEnumerable<Word> GetAllWordsInTopic(int topic, int skip, int take);
        void DeleteWord(int TopicId, int wordId);
    }
}
