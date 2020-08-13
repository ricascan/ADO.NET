

using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Persistencia
{
    interface IFacturaRepository
    {
        void Insertar(Factura factura);
        void Eliminar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> Listar();
        List<Factura> Listar(FiltroFactura filtro);
        Factura Buscar(int numero);
    }
}
