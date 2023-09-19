using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
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

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return medicamentos.AsReadOnly();
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

        private bool AgregarMedicamento(Medicamento medicamento)
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

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Int).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;

                command.ExecuteNonQuery();
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

        private bool EliminarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.Int).Value = medicamento.NombreComercial;

                command.ExecuteNonQuery();
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

        public bool Modificar(Medicamento medicamento)
        {
            if (ModificarMedicamento(medicamento))
            {
                var MedicamentoModificado = medicamentos.FirstOrDefault(t => t.NombreComercial == medicamento.NombreComercial);
                MedicamentoModificado.EsVentaLibre = medicamento.EsVentaLibre;
                MedicamentoModificado.PrecioVenta = medicamento.PrecioVenta;
                MedicamentoModificado.Stock = medicamento.Stock;
                MedicamentoModificado.StockMinimo = medicamento.StockMinimo;
                return true;
            }
            return false;
        }

        private bool ModificarMedicamento(Medicamento medicamento)
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

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Int).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;

                command.ExecuteNonQuery();
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
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
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
    }
}
