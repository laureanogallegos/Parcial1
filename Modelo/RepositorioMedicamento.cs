using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMedicamento
    {
        private static RepositorioMedicamento instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;
        private RepositorioMedicamento()
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
                    medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                    medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                    medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                    medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                    var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                    medicamento.MonodrogaMedicamento = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == nombreMonodroga);
                    medicamento.Droguerias = RepositorioDroguerias.Instancia.RecuperarDrogueriasDeMedicamento(medicamento);

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
        public bool Agregar(Medicamento medicamento)
        {
            bool ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    ////////////////////////
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    /////////////////////////
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.MonodrogaMedicamento.Nombre;
                    command.ExecuteNonQuery();

                    using var drogueriaCommand = new SqlCommand();
                    drogueriaCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    drogueriaCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    drogueriaCommand.Connection = connection;
                    drogueriaCommand.Transaction = sqlTransaction;
                    drogueriaCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    drogueriaCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (Drogueria drogueria in medicamento.Droguerias)
                    {
                        drogueriaCommand.Parameters["@CUIT"].Value = drogueria.Cuit;
                        drogueriaCommand.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();
                    connection.Close();
                    medicamentos.Add(medicamento);
                    ok = true;
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
            }
            return ok;
        }
        public bool Eliminar(Medicamento medicamento)
        {
            bool ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    ////////////////////////
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    /////////////////////////
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.ExecuteNonQuery();

                    sqlTransaction.Commit();
                    connection.Close();
                    medicamentos.Remove(medicamento);
                    ok = true;
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
            }
            return ok;
        }
        public bool Modificar(Medicamento medicamento)
        {
            bool ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    ////////////////////////
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    /////////////////////////
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.MonodrogaMedicamento.Nombre;
                    command.ExecuteNonQuery();

                    using var drogueriaCommand = new SqlCommand();
                    drogueriaCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    drogueriaCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    drogueriaCommand.Connection = connection;
                    drogueriaCommand.Transaction = sqlTransaction;
                    drogueriaCommand.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    drogueriaCommand.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (Drogueria drogueria in medicamento.Droguerias)
                    {
                        drogueriaCommand.Parameters["@CUIT"].Value = drogueria.Cuit;
                        drogueriaCommand.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();
                    connection.Close();
                    ok = true;
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
            }
            return ok;
        }

        public static RepositorioMedicamento Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamento();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }
    }
}
