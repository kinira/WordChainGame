using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public Topic TopicName { get; set; }
        public int TopicId { get; set; }

    }
}
