using System;
using System.Collections.Generic;
using System.Text;

namespace Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {
        public int Numero { get; set; }
        public int FacturaId { get; set; }
        public string ProductoId { get; set; }
        public int Unidades { get; set; }

        public LineaFactura(int numero, int facturaId, string productoId, int unidades)
        {
            Numero = numero;
            FacturaId = facturaId;
            ProductoId = productoId;
            Unidades = unidades;
        }

        public override string ToString()
        {
            return "Número de línea: " + Numero + ", Factura ID: " + FacturaId + ", Producto ID: " + ProductoId + ", Unidades: " + Unidades;
        }
    }
}
