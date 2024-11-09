using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.ViewModels
{
    public class PostsViewModel
    {
        public int IdPosts { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEdicion { get; set; }
        public DateTime FechaEliminacion { get; set; }

    }
}
