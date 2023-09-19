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

        public void Recuperar()
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
                        medicamento.Stock = Convert.ToInt16(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt16(reader["STOCK_MINIMO"].ToString());
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.Monodroga = reader["NOMBRE_MONODROGAL"].ToString();
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
            var agregado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))            
                try
                {
                    using var command = new SqlCommand();

                    command.CommandText = "SP_AGREGARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var sqlTransaction = connection.BeginTransaction();

                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;

                    using var commandProveedores = new SqlCommand();

                    commandProveedores.CommandType = System.Data.CommandType.StoredProcedure;
                    commandProveedores.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    commandProveedores.Transaction = sqlTransaction;
                    commandProveedores.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    commandProveedores.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                    foreach (var drogeria in medicamento.Drogerias)
                    {
                        commandProveedores.Parameters["@NOMBRE_COMERCIAL"].Value = medicamento.NombreComercial;
                        commandProveedores.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                    medicamentos.Add(medicamento);
                    command.Connection.Close();
                    agregado = true;
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
            return agregado;
        }
        public bool Modificar(Medicamento medicamento)
        {
            bool modificado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();

                    command.CommandText = "SP_MODIFICARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var sqlTransaction = connection.BeginTransaction();

                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga;
                    medicamentos.Remove(medicamento);
                    medicamentos.Add(medicamento);
                    command.Connection.Close();
                    modificado = true;
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
            return modificado;
        }
        public bool Eliminar(Medicamento medicamento)
        {
            bool eliminado = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();

                    command.CommandText = "SP_ELIMINARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    var sqlTransaction = connection.BeginTransaction();

                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;                   
                    medicamentos.Remove(medicamento);
                    command.Connection.Close();
                    eliminado = true;
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
            return eliminado;
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
