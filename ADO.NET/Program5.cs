using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program5
    {
        static void Main(string[] args)
        {
            
            foreach (FacturaLineaDTO l in FacturaActiveRecord.BuscarTodasFacturasLineas())
            {
                Console.WriteLine(l);
            }

            Console.ReadLine();
        }
    }
}
