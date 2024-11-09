using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCsAngular.Data.Models
{
    public class BaseModel
    {
        public bool Active { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

    }
}
