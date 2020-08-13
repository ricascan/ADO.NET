using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Persistencia.Filtros
{
    public class FiltroFactura
    {
        private int _numero;
        private string _concepto;


        public int Numero
        {
            get
            {
                return _numero;
            }
        }

        public string Concepto
        {
            get
            {
                return _concepto;
            }
        }



        public FiltroFactura AddNumero(int numero)
        {
            _numero = numero;
            return this;
        }
        public FiltroFactura AddConcepto(string concepto)
        {
            _concepto = concepto;
            return this;
        }
    }
}

