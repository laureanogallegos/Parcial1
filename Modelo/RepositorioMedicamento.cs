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
    public class RepositorioMedicamento
    {
        private static RepositorioMedicamento instancia;
        private List<Medicamento> medicamentos;
        private IConfigurationRoot configuration;

        private RepositorioMedicamento()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            ListarMedicamentos();
        }

        public static RepositorioMedicamento Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioMedicamento();
                }

                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return medicamentos.AsReadOnly();
            }
            catch (Exception)
            {
                throw;
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

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();

                using SqlCommand command2 = new SqlCommand();

                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command2.Connection = connection;
                command2.Transaction = sqlTransaction;

                command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command2.Parameters.Add("@CUIT", System.Data.SqlDbType.Int);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    command2.Parameters["@CUIT"].Value = drogueria.Cuit;
                    command2.ExecuteNonQuery();
                }

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

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

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
                var medicamentoModificado = medicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);
                medicamentoModificado.EsVentaLibre = medicamento.EsVentaLibre;
                medicamentoModificado.PrecioVenta = medicamento.PrecioVenta;
                medicamentoModificado.Stock = medicamento.Stock;
                medicamentoModificado.StockMinimo = medicamento.StockMinimo;
                medicamentoModificado.Monodroga = medicamento.Monodroga;
                medicamentoModificado.Droguerias = medicamento.Droguerias;
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
                using SqlCommand command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARMEDICAMENTO"; 
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.EsVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
               
                command.ExecuteNonQuery();

                using SqlCommand command2 = new SqlCommand();

                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command2.Connection = connection;
                command2.Transaction = sqlTransaction;

                command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command2.Parameters.Add("@CUIT", System.Data.SqlDbType.Int);

                foreach (var drogueria in medicamento.Droguerias)
                {
                    command2.Parameters["@CUIT"].Value = drogueria.Cuit;
                    command2.ExecuteNonQuery();
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



        private void ListarMedicamentos()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.Connection = connection;

                    connection.Open();

                    using var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NombreComercial"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(reader["EsVentaLibre"]);
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PrecioVenta"]);
                        medicamento.Stock = Convert.ToInt32(reader["Stock"]);
                        medicamento.StockMinimo = Convert.ToInt32(reader["StockMinimo"]);

                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == (reader["NombreConfiguracion"].ToString()));

                        using var command2 = new SqlCommand();
                        command2.CommandType = System.Data.CommandType.StoredProcedure;
                        command2.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command2.Connection = connection;

                        using var reader2 = command2.ExecuteReader();
                        while (reader2.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria.Cuit = Convert.ToInt32(reader2["CUIT"]);

                            drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);

                            medicamento.Droguerias.Add(drogueria);
                        }
                        medicamentos.Add(medicamento);
                    }
                    connection.Close();
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
}
