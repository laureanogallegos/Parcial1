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

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
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
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());

                        // Mapeo monodroga
                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        var monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(c => c.Nombre == nombreMonodroga);
                        medicamento.Monodroga = monodroga;

                        // Mapeo droguerias
                        using var commandDroguerias = new SqlCommand();
                        commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDroguerias.Parameters.Add("@@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                        /////////////////////////
                        commandDroguerias.Connection = connection;
                        var readerDrogueriasMedicamento = commandDroguerias.ExecuteReader();
                        while (readerDrogueriasMedicamento.Read())
                        {
                            long cuitDrogueria = (long)readerDrogueriasMedicamento["CUIT"];
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == cuitDrogueria);
                            medicamento.AgregarDrogueria(drogueria);
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

        public bool Agregar(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            using (var command = new SqlCommand())
            try
            {
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                /////////////////////////
                command.Connection = connection;
                command.Connection.Open();
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal, 10).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;


                using var commandDroguerias = new SqlCommand();

                commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDroguerias.Connection = connection;
                commandDroguerias.Transaction = sqlTransaction;
                commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                foreach (var drogueria in medicamento.Droguerias)
                {
                        commandDroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                        commandDroguerias.ExecuteNonQuery();
                }
                sqlTransaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                ok = true;
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
            return ok;
        }
    
        public bool Eliminar(Medicamento medicamento)
        {
            bool ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";

                command.Transaction = transaction;
                command.Connection = connection;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();

                transaction.Commit();
                medicamentos.Remove(medicamento);
                ok = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                ok = false;
            }
            finally
            {
                connection.Close();
                ok = false;
            }
            return ok;
        }
    }
}
