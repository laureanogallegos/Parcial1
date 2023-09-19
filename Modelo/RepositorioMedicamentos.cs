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
        private List<Medicamento> listaMedicamentos;
        private static RepositorioMedicamentos instancia;
        private IConfiguration configuration;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appSettings.json");
            listaMedicamentos = new List<Medicamento>();
            ListarMedicamentos();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new RepositorioMedicamentos();
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return listaMedicamentos.AsReadOnly();
        }


        public bool Agregar(Medicamento medicamento)
        {
            if (AgregarMedicamento(medicamento))
            {
                listaMedicamentos.Add(medicamento);
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
                var command = new SqlCommand();
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;

                command.ExecuteNonQuery();

                using var command2 = new SqlCommand();

                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command2.Connection = connection;
                command2.Transaction = sqlTransaction;
                
                foreach(var drogueria in listaMedicamentos)
                {
                    command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NChar, 50).Value = medicamento.NombreComercial;
                    command2.Parameters.Add("@ID_DROGUERIA", System.Data.SqlDbType.BigInt); 
                }

                ok = true;

                command2.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
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
                listaMedicamentos.Remove(medicamento);
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
                var command = new SqlCommand();
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                ok = true;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();

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
                var medicamentoGuardado = listaMedicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);

                medicamentoGuardado.NombreComercial = medicamento.NombreComercial;
                medicamentoGuardado.VentaLibre = medicamento.VentaLibre;
                medicamentoGuardado.PrecioVenta = medicamento.PrecioVenta;
                medicamentoGuardado.Stock = medicamento.Stock;
                medicamentoGuardado.StockMinimo = medicamento.StockMinimo;
                medicamentoGuardado.monodroga = medicamento.monodroga;
                medicamentoGuardado.listaDroguerias = medicamento.listaDroguerias;
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
                var command = new SqlCommand();
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;

                command.ExecuteNonQuery();

                using var command2 = new SqlCommand();

                command2.CommandType = System.Data.CommandType.StoredProcedure;
                command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command2.Connection = connection;
                command2.Transaction = sqlTransaction;

                foreach (var drogueria in listaMedicamentos)
                {
                    command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NChar, 50).Value = medicamento.NombreComercial;
                    command2.Parameters.Add("@ID_DROGUERIA", System.Data.SqlDbType.BigInt);
                }

                ok = true;

                command2.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
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

        public void ListarMedicamentos()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";

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
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString);
                        medicamento.monodroga.Nombre = reader["MONODROGAS.NOMBRE"].ToString();


                        using var command2 = new SqlCommand();
                        command2.CommandType = System.Data.CommandType.StoredProcedure;
                        command2.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";

                        command.Connection = connection;
                        command.Connection.Open();
                        var reader2 = command.ExecuteReader();

                        while (reader2.Read())
                        {
                            var drogueria = new Drogueria();

                            drogueria.Cuit = Convert.ToInt32(reader["ID_MEDICAMENTO"].ToString());
                            
                        }
                        listaMedicamentos.Add(medicamento);
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
