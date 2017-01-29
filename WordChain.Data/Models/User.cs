using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [MaxLength(20)]
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Topic> UserTopics { get; set; }

        public virtual ICollection<Word> UserWords { get; set; }
        public virtual ICollection<Report> UserReportedWords { get; set; }
    }
}
