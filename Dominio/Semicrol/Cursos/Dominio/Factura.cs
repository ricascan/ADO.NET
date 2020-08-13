using System;
using System.Collections.Generic;
using System.Text;

namespace Semicrol.Cursos.Dominio
{
    public class Factura
    {
        public int Numero { get; set; }
        public string Concepto { get; set; }

        public Factura(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public Factura(int numero)
        {
            Numero = numero;
        }
        public override string ToString()
        {
            return "Número de factura: " + Numero + ", Concepto: " + Concepto;
        }
    }
}
