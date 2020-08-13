

using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia.Filtros;
using System;
using System.Collections.Generic;

namespace Semicrol.Cursos.Persistencia
{
    class FacturaRepository : IFacturaRepository
    {
        public void Insertar(Factura factura)
        {

            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "insert into facturas(numero, concepto) values(@numero, @concepto)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", factura.Numero);
                command.Parameters.AddWithValue("@concepto", factura.Concepto);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Factura factura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "delete from facturas where numero = @numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", factura.Numero);
                command.ExecuteNonQuery();
            }
        }

        public void Actualizar(Factura factura)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "update facturas set concepto = @concepto where numero = @numero ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", factura.Numero);
                command.Parameters.AddWithValue("@concepto", factura.Concepto);
                command.ExecuteNonQuery();
            }
        }

        public List<Factura> Listar()
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader lector = command.ExecuteReader();
                List<Factura> facturas = new List<Factura>();
                while (lector.Read())
                {
                    facturas.Add(new Factura((int)lector["numero"], lector["concepto"].ToString()));

                }
                return facturas;
            }
        }

        public List<Factura> Listar(string concepto)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas where concepto = @concepto";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@concepto", concepto);
                SqlDataReader lector = command.ExecuteReader();
                List<Factura> facturas = new List<Factura>();
                while (lector.Read())
                {
                    facturas.Add(new Factura((int)lector["numero"], lector["concepto"].ToString()));

                }
                return facturas;
            }
        }

        public List<Factura> Listar(FiltroFactura filtro)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas";
                SqlCommand command = new SqlCommand();
                if (filtro.Numero != 0)
                {
                    sql += " where numero = @numero";
                    command.Parameters.AddWithValue("@numero", filtro.Numero);
                    if (filtro.Concepto != null)
                    {
                        sql += " and concepto = @concepto";
                        command.Parameters.AddWithValue("@concepto", filtro.Concepto);
                    }
                }
                else
                {
                    if (filtro.Concepto != null)
                    {
                        sql += " where concepto = @concepto";
                        command.Parameters.AddWithValue("@concepto", filtro.Concepto);
                    }
                }


                command.Connection = connection;
                command.CommandText = sql;


                SqlDataReader lector = command.ExecuteReader();
                List<Factura> facturas = new List<Factura>();
                while (lector.Read())
                {
                    facturas.Add(new Factura((int)lector["numero"], lector["concepto"].ToString()));

                }
                return facturas;
            }
        }

        public Factura Buscar(int numero)
        {
            using (SqlConnection connection = new SqlConnection(Conexion()))
            {
                connection.Open();
                String sql = "select * from facturas where numero = @numero";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@numero", numero);
                SqlDataReader lector = command.ExecuteReader();
                Factura factura = null;
                if (lector.Read())
                {
                    factura = new Factura((int)lector["numero"], lector["concepto"].ToString());
                }
                return factura;
            }
        }

        private static String Conexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            return settings.ConnectionString;
        }
    }
}
