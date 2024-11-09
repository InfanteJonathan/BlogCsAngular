using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.ViewModels
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEdicion { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
