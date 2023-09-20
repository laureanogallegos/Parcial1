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
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
        }
        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public bool Agregar(Medicamento medicamento)
        {
            if (AgregarMedicamento(medicamento))
            {
                medicamentos.Add(medicamento);
                return true;
            }
            return false;
        }
        public bool AgregarMedicamento (Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.BigInt, 1).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Decimal).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga;


                command.ExecuteNonQuery();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                using var commandDroguerias = new SqlCommand();

                commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDroguerias.Connection = connection;
                commandDroguerias.Transaction = sqlTransaction;
                commandDroguerias.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;
                commandDroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 25);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    if(drogueria != null)
                    {
                        commandDroguerias.Parameters["@CUIT"].Value = drogueria.Cuit;
                        commandDroguerias.ExecuteNonQuery();
                    }
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
            return ok;
        }

        public bool Eliminar(Medicamento medicamento)
        {
                if (EliminarMedicamento(medicamento))
                {
                    medicamentos.Remove(medicamento);
                    return true;
                }
            return false;
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Connection = connection;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.Nombre;

                command.ExecuteNonQuery();

                ok = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return ok;
        }

        public bool Modificar(Medicamento medicamento)
        {
            var medicamentoEncontrado = medicamentos.FirstOrDefault(x => x.Nombre.ToLower() == medicamento.Nombre.ToLower());

            if (ModificarMedicamento(medicamento))
            {
                return true;
            }
            return false;
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.BigInt, 1).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Decimal).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga;


                command.ExecuteNonQuery();

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                using var commandDroguerias = new SqlCommand();

                commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDroguerias.Connection = connection;
                commandDroguerias.Transaction = sqlTransaction;
                commandDroguerias.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;
                commandDroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 25);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    if (drogueria != null)
                    {
                        commandDroguerias.Parameters["@CUIT"].Value = drogueria.Cuit;
                        commandDroguerias.ExecuteNonQuery();
                    }
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
            return ok;
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return medicamentos.AsReadOnly();
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
                        medicamento.Monodroga.Nombre = reader["MONODROGA"].ToString();
                        medicamento.Nombre = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());

                        // ----------------------------------------------------------------------------------------------------------------------------

                        using var commandDroguerias = new SqlCommand();

                        commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";

                        commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.Nombre;
                        commandDroguerias.Connection = connection;

                        var readerDrogueriasMedicamento = commandDroguerias.ExecuteReader(); 

                        while (readerDrogueriasMedicamento.Read()) 
                        {
                            var CuitDrogueria = readerDrogueriasMedicamento["CUIT"].ToString();
                            if (CuitDrogueria != null)
                            {
                                var drogueria = RepositorioDroguerias.Instancia.ListarDroguerias().FirstOrDefault(x => x.Cuit.ToLower() == CuitDrogueria.ToLower());
                                medicamento.AgregarDrogueria(drogueria);
                            }

                        }


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


    }
}
