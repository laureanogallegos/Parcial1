using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamento
    {
        private static RepositorioMedicamento instancia;
        private List<Medicamento> medicamentos;
        private List<Monodroga> monodrogas;
        private IConfigurationRoot configuration;
        private RepositorioMedicamento()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            medicamentos = new List<Medicamento>();
            Recuperar();
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
                        medicamento.PrecioVenta = (decimal)reader["PRECIO_VENTA"];
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"].ToString()); 
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        // Tengo que obtener la monodroga y asignarla al medicamento mododroga
                        var monodrogaExist = monodrogas.FirstOrDefault(x => x.Nombre == reader["MONODROGA"].ToString());
                        medicamento.Monodroga = monodrogaExist;
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
        private List<int> RecuperarDrogueriaMedicamento(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.Int, 50).Value = medicamento.NombreComercial;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                      
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
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            var response = true;
            try
                {

                    using var command = new SqlCommand();
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.Int, 50).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                    command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                    command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                    command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                    command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga;

                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    connection.Close();
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;

            }
            return response;
        }
        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            var response = true;
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.Int, 50).Value = medicamento.NombreComercial;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.Int).Value = medicamento.Monodroga;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;

            }
            return response;
        }
        public bool EliminarMedicamento(string nombre)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            var response = true;
            try
            {
                using var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = nombre;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                connection.Close();
                connection.Dispose();
                response = false;
            }
            return response;
        }
        public bool AgregarDrogueriaMedicamento(Medicamento medicamento, Drogueria drogueria)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var response = true;
            try
            {
                using var command = new SqlCommand();
                command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTOS";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.Int, 50).Value = medicamento.NombreComercial;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                   //Debo setear la lista de Droguerias, pero no recuerdo la modificacion
                   //que debo hacer para ir recorriendo la lista de droguerias, debido a que
                   //acepta 2 parametos.
                }
                command.Connection.Close();
            }
            catch (SqlException ex)
            {
                connection.Close();
                connection.Dispose();
                response = false;
            }
            catch (Exception ex)
            {
                connection.Close();
                connection.Dispose();
                response = false;
            }
            return response;
        }
    
    }
}
