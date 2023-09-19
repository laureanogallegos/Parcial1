using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamento
    {
        private static RepositorioMedicamento instancia;
        private IConfigurationRoot configuration;
        private List<Medicamento> listamedicamentos;
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
        private RepositorioMedicamento()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            listamedicamentos = new List<Medicamento>();
            ListarMedicamentos();
        }
        public bool EliminarMedicamento (Medicamento medicamento)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SP_ELIMINARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Transaction = transaction;
                        command.Connection = connection;
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombrecomercial;
                        command.ExecuteNonQuery();
                        listamedicamentos.Remove(medicamento);
                         ok = true;
                    }
                    transaction.Commit();
                    connection.Close();
                }
                catch (SqlException)
                {
                    connection.Dispose();
                    connection.Close();
                }
                return ok;
            }
        }
        public bool ModificarMedicamentos(Medicamento medica)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SP_MODIFICARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Transaction = transaction;
                        command.Connection = connection;

                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medica.Nombrecomercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medica.Esventalibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medica.Precioventa;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medica.Stockactual;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medica.Stockminimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medica.Monodrogaasociada.Nombre;
                        command.ExecuteNonQuery();
                        using (var commanddroguerias = new SqlCommand())
                        {
                            commanddroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                            commanddroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                            commanddroguerias.Transaction = transaction;
                            commanddroguerias.Connection = connection;
                            commanddroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medica.Nombrecomercial;
                            commanddroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                            foreach (var item in medica.Listadroguerias)
                            {
                                commanddroguerias.Parameters["@CUIT"].Value = item.Cuit;
                                commanddroguerias.ExecuteNonQuery();
                                ok = true;
                            }
                        }
                    }
                    transaction.Commit();
                    connection.Close();

                }
                catch (SqlException)
                {
                    connection.Dispose();
                    connection.Close();
                }
            return ok;
        }
        public bool agregarMedicamentos(Medicamento medica)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SP_AGREGARMEDICAMENTO";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Transaction = transaction;
                        command.Connection = connection;
                        
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medica.Nombrecomercial;
                        command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medica.Esventalibre;
                        command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medica.Precioventa;
                        command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medica.Stockactual;
                        command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medica.Stockminimo;
                        command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medica.Monodrogaasociada.Nombre;
                        command.ExecuteNonQuery();
                        listamedicamentos.Add(medica);
                        using (var commanddroguerias = new SqlCommand())
                        {
                            commanddroguerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                            commanddroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                            commanddroguerias.Transaction = transaction;
                            commanddroguerias.Connection = connection;
                            commanddroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medica.Nombrecomercial;
                            commanddroguerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);
                            foreach (var item in medica.Listadroguerias)
                            {
                                commanddroguerias.Parameters["@CUIT"].Value = item.Cuit;
                                commanddroguerias.ExecuteNonQuery();
                                ok = true;
                            }
                        }
                    }
                    transaction.Commit();
                    connection.Close();

                }
                catch(SqlException)
                {
                    connection.Dispose();
                    connection.Close();
                }
            return ok;
        }
        public void ListarMedicamentos()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using (var command = new SqlCommand())
                    {
                        command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Connection = connection;
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var medicamento = new Medicamento();
                            medicamento.Nombrecomercial = reader["NOMBRE_COMERCIAL"].ToString();
                            medicamento.Esventalibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                            medicamento.Stockminimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                            medicamento.Stockactual = Convert.ToInt32(reader["STOCK"].ToString());
                            medicamento.Monodrogaasociada = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == reader["NOMBRE_MONODROGA"].ToString());
                            medicamento.Precioventa = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                            listamedicamentos.Add(medicamento);
                            Listardrogueriaspormedicamento(medicamento);
                        }
                        connection.Close();


                    }
                }
                catch (SqlException)
                {
                    connection.Dispose();
                    connection.Close();
                }
        }
        private void Listardrogueriaspormedicamento (Medicamento medica)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using(var commanddroguerias = new SqlCommand())
                    {
                        commanddroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commanddroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commanddroguerias.Connection = connection;
                        connection.Open();
                   
                        commanddroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medica.Nombrecomercial;
                        var reader = commanddroguerias.ExecuteReader();
                        while (reader.Read())
                        {
                            var drogueria = new Drogueria();
                            drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == Convert.ToInt64(reader["CUIT"].ToString()));
                            medica.Listadroguerias.Add(drogueria);

                        }
                    }
                }
                catch (SqlException)
                {
                    connection.Dispose();
                    connection.Close();
                }
        }
        public IReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return listamedicamentos.AsReadOnly();
        }
    }
}
