using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHeon.Shared
{
    public class Cliente
    {
        public int id { get; set; }
        public int idTipoIdentificacion { get; set; }
        public int idTipoPersona { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public string? identificacion { get; set; }
        public string? telefono { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaEdicion { get; set; }
        public string? tipoIdentificacion { get; set; }
        public string? abreviatura { get; set; }
        public string? tipoPersona { get; set; }

    }
}
