using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.PersistenciaADO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program6
    {
        static void Main(string[] args)
        {

            FacturaRepository facturaRepository = new FacturaRepository();

            foreach (Factura f in facturaRepository.Listar())
            {
                Console.WriteLine(f);
            }
            Console.WriteLine(facturaRepository.Buscar(1));

            Console.ReadLine();
        }
    }
}
