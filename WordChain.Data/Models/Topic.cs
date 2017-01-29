using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public User Author { get; set; }
        public string AuthorId { get; set; } 

        public virtual ICollection<Word> TopicWords { get; set; }
    }
}
