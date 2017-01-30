using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChain.Data.Models;

namespace WordChain.Data
{
    public class WordChainContext : DbContext
    {
        public WordChainContext() : 
                base("WordChain")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<BadWord> BadWords { get; set; }
    }
}
