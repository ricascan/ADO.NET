
using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Persistencia
{
    class LineaFacturaRepository 
    {
        public void Insertar(LineaFactura lineaFactura)
        {

            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "insert into lineas_factura(numero, factura_numero, producto_id, unidades) values (@numero, @factura_numero, @producto_id, @unidades)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", lineaFactura.Numero);
                command.Parameters.AddWithValue("@factura_numero", lineaFactura.FacturaId);
                command.Parameters.AddWithValue("@producto_id", lineaFactura.ProductoId);
                command.Parameters.AddWithValue("@unidades", lineaFactura.Unidades);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(LineaFactura lineaFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "delete from lineas_factura where numero = @numero and factura_numero = @factura_numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", lineaFactura.Numero);
                command.Parameters.AddWithValue("@factura_numero", lineaFactura.Numero);
                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(LineaFactura lineaFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "update lineas_factura set producto_id = @producto_id, unidades = @unidades ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@producto_id", lineaFactura.ProductoId);
                command.Parameters.AddWithValue("@unidades", lineaFactura.Unidades);
                command.ExecuteNonQuery();
            }
        }

        public List<LineaFactura> Listar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader lector = command.ExecuteReader();
                List<LineaFactura> lineasFacturas = new List<LineaFactura>();
                while (lector.Read())
                {
                    lineasFacturas.Add(new LineaFactura((int)lector["numero"], (int)lector["factura_numero"], lector["producto_id"].ToString(), (int)lector["unidades"]));

                }
                return lineasFacturas;
            }
        }

        public List<LineaFactura> Listar(int numeroFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura where factura_numero = @facturaNumero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@facturaNumero", numeroFactura);
                SqlDataReader lector = command.ExecuteReader();
                List<LineaFactura> lineasFacturas = new List<LineaFactura>();
                while (lector.Read())
                {
                    lineasFacturas.Add(new LineaFactura((int)lector["numero"], (int)lector["factura_numero"], lector["producto_id"].ToString(), (int)lector["unidades"]));

                }
                return lineasFacturas;
            }
        }

        public LineaFactura BuscarLineaFactura(int numero, int numeroFactura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from lineas_factura, facturas where numero = @numero and factura_numero = @factura_numero and lineas_factura.factura_numero = facturas.numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", numero);
                command.Parameters.AddWithValue("@factura_nmumero", numeroFactura);
                SqlDataReader lector = command.ExecuteReader();
                LineaFactura lineaFactura = null;
                if (lector.Read())
                {
                    lineaFactura = new LineaFactura((int)lector["numero"], (int)lector["factura_numero"], lector["producto_id"].ToString(), (int)lector["unidades"]);
                }
                return lineaFactura;
            }
        }

        private static String Conexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            return settings.ConnectionString;
        }
    }
}
