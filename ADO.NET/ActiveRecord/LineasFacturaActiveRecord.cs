using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class LineasFacturaActiveRecord
    {
        

        public int Numero { get; set; }
        public FacturaActiveRecord Factura { get; set; }
        public string ProductoId { get; set; } 
        public int Unidades { get; set; }

        public LineasFacturaActiveRecord(int numero, FacturaActiveRecord factura, string productoId, int unidades)
        {
            Numero = numero;
            Factura = factura;
            ProductoId = productoId;
            Unidades = unidades;
        }

        

        public void Insertar()
        {

            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "insert into lineas_factura(numero, factura_numero, producto_id, unidades) values (@numero, @factura_numero, @producto_id, @unidades)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", Numero);
                command.Parameters.AddWithValue("@factura_numero", Factura.Numero);
                command.Parameters.AddWithValue("@producto_id", ProductoId);
                command.Parameters.AddWithValue("@unidades", Unidades);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "delete from lineas_factura where numero = @numero and factura_numero = @factura_numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", Numero);
                command.Parameters.AddWithValue("@factura_numero", Factura.Numero);
                command.ExecuteNonQuery();
            }
        }

        public static List<LineasFacturaActiveRecord> Listar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader lector = command.ExecuteReader();
                List<LineasFacturaActiveRecord> lineasFacturaActiveRecords = new List<LineasFacturaActiveRecord>();
                while (lector.Read())
                {
                    lineasFacturaActiveRecords.Add(new LineasFacturaActiveRecord((int)lector["numero"], new FacturaActiveRecord((int)lector["factura_numero"], null),lector["producto_id"].ToString(), (int)lector["unidades"] ));

                }
                return lineasFacturaActiveRecords;
            }
        }

        public static List<LineasFacturaActiveRecord> Listar(int numeroFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura, facturas where factura_numero = @factura_numero and lineas_factura.factura_numero = facturas.numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@factura_numero", numeroFactura);
                SqlDataReader lector = command.ExecuteReader();
                List<LineasFacturaActiveRecord> lineasFacturaActiveRecords = new List<LineasFacturaActiveRecord>();
                while (lector.Read())
                {
                    lineasFacturaActiveRecords.Add(new LineasFacturaActiveRecord((int)lector["numero"], new FacturaActiveRecord((int)lector["factura_numero"], lector["concepto"].ToString()), lector["producto_id"].ToString(), (int)lector["unidades"]));

                }
                return lineasFacturaActiveRecords;
            }
        }

        public static LineasFacturaActiveRecord BuscarLineaFactura(int numero, int numeroFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura, facturas where numero = @numero and factura_numero = @factura_numero and lineas_factura.factura_numero = facturas.numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", numero);
                command.Parameters.AddWithValue("@factura_nmumero", numeroFactura);
                SqlDataReader lector = command.ExecuteReader();
                LineasFacturaActiveRecord lineaFactura = null;
                if (lector.Read())
                {
                    lineaFactura = new LineasFacturaActiveRecord((int)lector["numero"], new FacturaActiveRecord((int)lector["factura_numero"], lector["concepto"].ToString()), lector["producto_id"].ToString(), (int)lector["unidades"]);
                }
                return lineaFactura;
            }
        }

        public void Actualizar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "update lineas_factura set producto_id = @producto_id, unidades = @unidades ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@producto_id", ProductoId);
                command.Parameters.AddWithValue("@unidades", Unidades);
                command.ExecuteNonQuery();
            }
        }

        private static String Conexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            return settings.ConnectionString;
        }

        public override string ToString()
        {
            return "Número de línea: " + Numero + ", Factura: " + Factura + ", Producto ID: " + ProductoId + ", Unidades: " + Unidades;
        }

    }
}
