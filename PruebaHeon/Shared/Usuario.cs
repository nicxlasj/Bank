using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHeon.Shared
{
    public class Usuario
    {
        public int id { get; set; }
        public int idRol { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? rol { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaEdicion { get; set; }
    }
}
