using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FiltroFactura
    {
        public FiltroFactura(int numero, string concepto )
        {
            Concepto = concepto;
            Numero = numero;
        }

        public string Concepto { get; set; }
        public int Numero { get; set; }
    }
}
