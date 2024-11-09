using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.Models
{
    [Table("Comentario")]
    public class comentario:BaseModel
    {
        [Key]
        public int ComentaryId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}
