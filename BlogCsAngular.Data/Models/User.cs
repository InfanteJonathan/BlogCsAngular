using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.Models
{
    public class User:BaseModel
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Posts> Post { get; set; }
        public ICollection<comentario> Commentary { get; set; }

    }
}
