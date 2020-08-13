using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\formacion\Documents\Facturacion.mdf;Integrated Security=True;Connect Timeout=30");
            connection.Open();
            String sql = "select * from facturas";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader lector = command.ExecuteReader();

            while (lector.Read())
            {
                Console.WriteLine(lector["numero"] + " " + lector["concepto"]);
                
            }

            Console.ReadLine();
        }
    }
}
