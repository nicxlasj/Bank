using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHeon.Shared
{
    public class Cuenta
    {
        public int id { get; set; }
        public int idCliente { get; set; }
        public int idTipoCuenta { get; set; }
        public int numeroCuenta { get; set; }
        public decimal saldo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaEdicion { get; set; }
        public string? nombresCliente { get; set; }
        public string? tipoCuentaDescripcion { get; set; }
        public TipoCuenta? tipoCuenta { get; set; }
    }
}
