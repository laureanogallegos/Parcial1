using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Net.Sockets;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
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
                        medicamento.monodroga.Nombre = reader["MONODROGA"].ToString();
                        medicamento.NombreComercial = reader["NOMBRE"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["VENTALIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToInt32(reader["PRECIOVENTA"].ToString());
                        medicamento.StockActual = Convert.ToInt32(reader["STOCKACTUAL"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCKMINIMO"].ToString());
                        medicamentos.Add(medicamento);
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

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }

        public bool Agregar(Medicamento medicamento)
        {
            {
                var ok = false;
                var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "SP_AGREGARMEDICAMENTO";
                        command.Connection = connection;
                        command.Transaction = sqlTransaction;
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga;
                        command.ExecuteNonQuery();
                        sqlTransaction.Commit();
                        connection.Close();
                        medicamentos.Add(medicamento);
                        ok = true;
                    }
                }

                catch (SqlException ex)
                {
                    sqlTransaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
                return ok;
            }
        }

        public bool AgregarDrogueria(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = medicamento.drogueria.Cuit;
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    ok = true;
                }
            }

            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga;
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    ok = true;
                }
            }

            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }

        public bool Eliminar (Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using (var command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamento);
                    ok = true;
                }
            }

            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }
    }
}
