

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public int Numero { get; set; }
        public string Concepto { get; set; }

        public FacturaActiveRecord(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public void Insertar()
        {

            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "insert into facturas(numero, concepto) values(@numero, @concepto)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", Numero);
                command.Parameters.AddWithValue("@concepto", Concepto);
                command.ExecuteNonQuery();
            }



        }

        public void Eliminar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "delete from facturas where numero = @numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", Numero);
                command.ExecuteNonQuery();
            }
        }

        public static List<FacturaActiveRecord> Listar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader lector = command.ExecuteReader();
                List<FacturaActiveRecord> facturaActiveRecords = new List<FacturaActiveRecord>();
                while (lector.Read())
                {
                    facturaActiveRecords.Add(new FacturaActiveRecord((int)lector["numero"], lector["concepto"].ToString()));

                }
                return facturaActiveRecords;
            }
        }

        public static List<FacturaActiveRecord> ListarPorConcepto(string concepto)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas where concepto = @concepto";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@concepto", concepto);
                SqlDataReader lector = command.ExecuteReader();
                List<FacturaActiveRecord> facturaActiveRecords = new List<FacturaActiveRecord>();
                while (lector.Read())
                {
                    facturaActiveRecords.Add(new FacturaActiveRecord((int)lector["numero"], lector["concepto"].ToString()));

                }
                return facturaActiveRecords;
            }
        }

        

        public static FacturaActiveRecord BuscarFactura(int numero)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas where numero = @numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", numero);
                SqlDataReader lector = command.ExecuteReader();
                FacturaActiveRecord factura = null;
                if (lector.Read())
                {
                    factura = new FacturaActiveRecord((int)lector["numero"], lector["concepto"].ToString());
                }
                return factura;
            }
        }
        public static FacturaActiveRecord BuscarFacturaConcepto(string concepto)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas where concepto = @concepto";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@concepto", concepto);
                SqlDataReader lector = command.ExecuteReader();
                FacturaActiveRecord factura = null;
                if (lector.Read())
                {
                    factura = new FacturaActiveRecord((int)lector["numero"], lector["concepto"].ToString());
                }
                return factura;
            }
        }

        public void Actualizar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "update facturas set concepto = @concepto where numero = @numero ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", Numero);
                command.Parameters.AddWithValue("@concepto", Concepto);
                command.ExecuteNonQuery();
            }
        }

        public List<LineasFacturaActiveRecord> ListarLineas()
        {
            return LineasFacturaActiveRecord.Listar(Numero);
        }

        public static List<FacturaLineaDTO> BuscarTodasFacturasLineas()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select f.numero, f.concepto, l.producto_id, l.unidades from facturas f inner join lineas_factura l on l.factura_numero = f.numero order by f.numero";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader lector = command.ExecuteReader();
                List<FacturaLineaDTO> facturaActiveRecords = new List<FacturaLineaDTO>();
                while (lector.Read())
                {
                    facturaActiveRecords.Add(new FacturaLineaDTO((int)lector["numero"], lector["concepto"].ToString(), (int)lector["unidades"], lector["producto_id"].ToString()));

                }
                return facturaActiveRecords;
            }
        }

        public static int SumaUnidades()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select sum(unidades) from lineas_factura";

                SqlCommand command = new SqlCommand(sql, connection);

                int total = 0;
                total = (int)command.ExecuteScalar();

                return total;
            }
        }

        private static String Conexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            return settings.ConnectionString;
        }

        public override string ToString()
        {
            return "Número de factura: " + Numero + ", Concepto: " + Concepto;
        }

    }


}
