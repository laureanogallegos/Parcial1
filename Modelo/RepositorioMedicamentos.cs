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
            RecuperarDrogueriasMedicamentos();
        }
        private void RecuperarDrogueriasMedicamentos()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
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
        public bool AgregarDrogueriasMedicamentos(Medicamento medicamento)
        {
            bool ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARDROGUERIASMEDICAMENTO";

                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                Drogueria drogueria = new Drogueria();
                command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt, 50).Value = drogueria.Cuit;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            return ok;
        }
        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = (bool)reader["ES_VENTA_LIBRE"];
                        medicamento.PrecioVenta = Convert.ToInt32(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        medicamento.Monodroga.Nombre = reader["MONODROGA"].ToString();
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
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";

                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            return ok;
        }

        public bool Modificar(Medicamento medicamento)
        {
            bool ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARMEDICAMENTO";

                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
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
                command.CommandText = "SP_ELIMINARPRODUCTO";

                command.Transaction = transaction;
                command.Connection = connection;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();

                transaction.Commit();
                medicamentos.Remove(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            return ok;
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
    }
}