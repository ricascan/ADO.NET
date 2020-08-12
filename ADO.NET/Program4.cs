using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program4
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\Documents\Facturacion.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            String sql = "update facturas set concepto = 'conceptoActualizado' where numero = 2";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            

            Console.ReadLine();
        }
    }
}
