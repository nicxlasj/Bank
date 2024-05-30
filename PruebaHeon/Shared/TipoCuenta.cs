﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHeon.Shared
{
    public class TipoCuenta
    {
        public int id { get; set; }
        public string? descripcion { get; set; }
        public override bool Equals(object? o)
        {
            var other = o as TipoCuenta;
            return other?.id == id;
        }
        public override int GetHashCode() => id.GetHashCode();
        public override string ToString() => descripcion!;
    }
}
