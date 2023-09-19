using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> lista;

        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            lista = new List<Medicamento>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            
                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                        var medicamento = new Medicamento();

                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());

                        Monodroga monodroga = new Monodroga();
                        monodroga.Nombre = reader["MONODROGA"].ToString();
                        medicamento.Monodroga = monodroga;


                        lista.Add(medicamento);
                    }
                    command.Connection.Close();
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }

        }

        private void AgregarMedicamento(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad

                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());

                        Monodroga monodroga = new Monodroga();
                        monodroga.Nombre = reader["MONODROGA"].ToString();
                        medicamento.Monodroga = monodroga;


                        lista.Add(medicamento);
                    }
                    command.Connection.Close();
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }

        }



        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return lista.AsReadOnly();
        }




        private void ModificarMedicamento(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad

                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());

                        Monodroga monodroga = new Monodroga();
                        monodroga.Nombre = reader["MONODROGA"].ToString();
                        medicamento.Monodroga = monodroga;


                        lista.Add(medicamento);
                    }
                    command.Connection.Close();
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }

        }




    }
}
