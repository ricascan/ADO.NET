using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaLineaDTO
    {
        public FacturaLineaDTO(int numeroFactura, string concepto, int unidades, string productoID)
        {
            NumeroFactura = numeroFactura;
            Concepto = concepto;
            Unidades = unidades;
            ProductoID = productoID;
        }

        public int NumeroFactura { get; set; }
        public String Concepto { get; set; }
        public int Unidades { get; set; }
        public String ProductoID { get; set; }

        public override string ToString()
        {
            return NumeroFactura + " " + Concepto + " " + Unidades + " " + ProductoID;
        }

    }
}
