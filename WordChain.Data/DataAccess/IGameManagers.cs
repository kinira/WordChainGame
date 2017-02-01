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
        List<Word> GetAllWords(int id);
        void AddWord(string word, string topic);
        void ReportWord(string word, string topic);
        List<Report> GetAllreportedWords();
        void AddWordToBad(string badWord);
        List<TopicView> GetAllTopics(int skip, int take, string orderBy);
    }
}
