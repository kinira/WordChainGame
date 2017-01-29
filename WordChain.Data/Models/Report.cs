using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public User Reporter { get; set; }
        public int ReportedId { get; set; }
        public Topic Topic { get; set; }
        public int TopicId { get; set; }
        public Word Word { get; set; }
        public int WordId { get; set; }
        public string WordAuthor { get; set; }
    }
}
