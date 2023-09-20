using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private List<Medicamento> listaMedicamentos;
        private static RepositorioMedicamentos instancia;
        private IConfigurationRoot configuration;
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
        public RepositorioMedicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
            configuration = ConfigurationHelper.GetConfiguration("appSettings.json");
        }
        public ReadOnlyCollection<Medicamento> Listar()
        {
            return listaMedicamentos.AsReadOnly();
        }
        public List<Medicamento> Recuperar()
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
                        medicamento.VentaLibre = bool.Parse(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.Precio = decimal.Parse(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = int.Parse(reader["STOCK"].ToString());
                        medicamento.StockMin = int.Parse(reader["STOCK_MINIMO"].ToString());
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.BuscarMonodroga(reader["NOMBRE_MONODROGA"].ToString());

                        using var commandDrogueria = new SqlCommand(); // Comando para recuperar droguerias que proveen un medicamento
                        commandDrogueria.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        command.Connection = connection;
                        var readerD = commandDrogueria.ExecuteReader();
                        // Bucle utilizado para asignar la lista de droguerias que corresponden a un medicamento
                        while (readerD.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria.Cuit = long.Parse(readerD["CUIT"].ToString());
                            drogueria.Email = readerD["EMAIL"].ToString();
                            drogueria.Direccion = readerD["DIRECCION"].ToString();
                            drogueria.RazonSocial = readerD["RAZON_SOCIAL"].ToString();

                            medicamento.AgregarDrogueria(drogueria);
                        }
                        listaMedicamentos.Add(medicamento);
                        command.Connection.Close();  
                    }
                }
                catch(SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch(Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
            
            return listaMedicamentos;
        }
        public bool Agregar(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMin;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre; 
                
                command.ExecuteNonQuery();
                command.Connection.Close();

                listaMedicamentos.Add(medicamento);
                ok = true;

            }
            catch(SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                connection.Dispose();
                ok = false;
            }
            catch(Exception ex)
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
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMin;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;

                command.ExecuteNonQuery();
                command.Connection.Close();
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
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                command.ExecuteNonQuery();
                command.Connection.Close();

                listaMedicamentos.Remove(medicamento);

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
        public bool AsignarDrogueria(Medicamento medicamento, Drogueria drogueria)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var transaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                command.ExecuteNonQuery();
                command.Connection.Close();
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
    }
}
