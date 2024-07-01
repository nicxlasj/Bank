using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHeon.Shared
{
    public class Transaccion
    {
        public int id { get; set; }
        public int idTipoTransaccion { get; set; }
        public int idCuenta { get; set; }
        public int? idFormaPago { get; set; }
        public int? idBanco { get; set; }
        public string? numeroCheque { get; set; }
        public decimal monto { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime? fechaEdicion { get; set; }
        public string? tipoTransaccion { get; set; }
        public int numeroCuenta { get; set; }
        public string? nombresCliente { get; set; }
        public string? formaPago { get; set; }
    }
}
