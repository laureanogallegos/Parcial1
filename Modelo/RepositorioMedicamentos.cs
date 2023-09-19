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
        private IConfigurationRoot configuration;
        public List<Medicamento> Medicamentos;

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new RepositorioMedicamentos();
                }
                return instancia;
            }
        }

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appSettings.json");
        }

        public bool Agregar(Medicamento pMedicamento)
        {
            if (AgregarMedicamento(pMedicamento))
            {
                Medicamentos.Add(pMedicamento);
                return true;
            }
            return false;
        }

        public bool AgregarMedicamento(Medicamento pMedicamento)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE",System.Data.SqlDbType.Bit).Value = pMedicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = pMedicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = pMedicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = pMedicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.Monodroga.Nombre;
                    command.ExecuteNonQuery();

                    var command2 = new SqlCommand();
                    command2.CommandType = System.Data.CommandType.StoredProcedure;
                    command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command2.Connection = connection;
                    command2.Transaction = sqlTransaction;

                    command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.NombreComercial;
                    command2.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    
                    foreach(var drogueria in pMedicamento.Droguerias)
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
            }
            return ok;
        }
        public bool Modificar(Medicamento pMedicamento)
        {
            var medicamentoExistente = Medicamentos.FirstOrDefault(x => x.NombreComercial == pMedicamento.NombreComercial);
            if (ModificarMedicamento(pMedicamento))
            {
                medicamentoExistente.VentaLibre = pMedicamento.VentaLibre;
                medicamentoExistente.StockActual = pMedicamento.StockActual;
                medicamentoExistente.StockMinimo = pMedicamento.StockMinimo;
                medicamentoExistente.Droguerias = pMedicamento.Droguerias;
                medicamentoExistente.Monodroga = pMedicamento.Monodroga;
                medicamentoExistente.PrecioVenta = pMedicamento.PrecioVenta;
                return true;
            }
            else return false;
        }

        public bool ModificarMedicamento(Medicamento pMedicamento)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_MODIFICARMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = pMedicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = pMedicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = pMedicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = pMedicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.Monodroga.Nombre;
                    command.ExecuteNonQuery();

                    var command2 = new SqlCommand();
                    command2.CommandType = System.Data.CommandType.StoredProcedure;
                    command2.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command2.Connection = connection;
                    command2.Transaction = sqlTransaction;

                    command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.NombreComercial;
                    command2.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                    foreach (var drogueria in pMedicamento.Droguerias)
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
            }
            return ok;
        }
        public bool Eliminar(Medicamento pMedicamento)
        {
            var medicamentoExistente = Medicamentos.FirstOrDefault(x => x.NombreComercial == pMedicamento.NombreComercial);
            if (EliminarMedicamento(pMedicamento))
            {
                Medicamentos.Remove(medicamentoExistente);
                return true;
            }
            else return false;
        }

        public bool EliminarMedicamento(Medicamento pMedicamento)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var sqlTransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_ELIMINARMEDICAMENTO";
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;

                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = pMedicamento.NombreComercial;
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
            }
            return ok;
        }
        public ReadOnlyCollection<Medicamento> Recuperar()
        {
            if(Medicamentos == null)
            {
                Medicamentos = new List<Medicamento>();
                ListarMedicamentos();
            }
            return Medicamentos.AsReadOnly();
        }

        public void ListarMedicamentos()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.Connection = connection;

                    var reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = decimal.Parse(reader["PRECIO_VENTA"].ToString());
                        medicamento.StockActual = int.Parse(reader["STOCK"].ToString());
                        medicamento.StockMinimo = int.Parse(reader["STOCK_MINIMO"].ToString());
                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        var monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == nombreMonodroga);
                        medicamento.Monodroga = monodroga;

                        using var command2 = new SqlCommand();
                        command2.CommandType = System.Data.CommandType.StoredProcedure;
                        command2.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command2.Connection = connection;

                        command2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                        var reader2 = command2.ExecuteReader();
                        while(reader2.Read())
                        {
                            var cuitDrogueria = long.Parse(reader["CUIT"].ToString());
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == cuitDrogueria);
                            medicamento.Droguerias.Add(drogueria);
                        }
                        Medicamentos.Add(medicamento);
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
