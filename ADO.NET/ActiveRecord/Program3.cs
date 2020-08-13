using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program3
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\Documents\Facturacion.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            String sql = "delete from facturas where numero = 3";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            

            Console.ReadLine();
        }
    }
}
