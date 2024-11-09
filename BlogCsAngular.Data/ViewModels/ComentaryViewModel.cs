using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.ViewModels
{
    public class ComentaryViewModel
    {
        public int ComentaryId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEdicion { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
