using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.Models
{
    public class Posts:BaseModel
    {
        [Key]
        public int IdPosts { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }        
        public string Content { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User Usuario { get; set; }
    }
}
