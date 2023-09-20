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
        private IConfigurationRoot configuration;
        private static RepositorioMedicamentos instancia;

        private RepositorioMedicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            RecuperarMedicamentos();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia = new RepositorioMedicamentos();
                return instancia;
            }
        }

        public bool AgregarMedicamento(Medicamento medicamento)
        {
            bool ok = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
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

                using var commandDrogeriasMedicamentos = new SqlCommand();

                commandDrogeriasMedicamentos.CommandType = System.Data.CommandType.StoredProcedure;
                commandDrogeriasMedicamentos.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";

                commandDrogeriasMedicamentos.Connection = connection;
                commandDrogeriasMedicamentos.Transaction = transaction;

                commandDrogeriasMedicamentos.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandDrogeriasMedicamentos.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 50);

                foreach(var drogueria in medicamento.ListarDroguerias())
                {
                    commandDrogeriasMedicamentos.Parameters["@CUIT"].Value = drogueria.Cuit;
                    commandDrogeriasMedicamentos.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                listaMedicamentos.Add(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            return ok;
        }

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            bool ok = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
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

                using var commandDrogeriasMedicamentos = new SqlCommand();

                commandDrogeriasMedicamentos.CommandType = System.Data.CommandType.StoredProcedure;
                commandDrogeriasMedicamentos.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";

                commandDrogeriasMedicamentos.Connection = connection;
                commandDrogeriasMedicamentos.Transaction = transaction;

                commandDrogeriasMedicamentos.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                commandDrogeriasMedicamentos.Parameters.Add("@CUIT", System.Data.SqlDbType.NVarChar, 50);

                foreach (var drogueria in medicamento.ListarDroguerias())
                {
                    commandDrogeriasMedicamentos.Parameters["@CUIT"].Value = drogueria.Cuit;
                    commandDrogeriasMedicamentos.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                listaMedicamentos.Add(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            return ok;
        }

        public bool EliminarMedicamento(Medicamento medicamento)
        {
            bool ok = false;
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var transaction = connection.BeginTransaction();

            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";

                command.Connection = connection;
                command.Transaction = transaction;

                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();
                listaMedicamentos.Remove(medicamento);
                ok = true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                ok = false;
            }
            return ok;
        }

        public void RecuperarMedicamentos()
        {
            using var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            try
            {
                connection.Open();
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                command.Connection = connection;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Medicamento medicamento = new Medicamento();

                    medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                    medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                    medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                    medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());

                    var codigoMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                    medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre.ToLower() == codigoMonodroga.ToLower());

                    listaMedicamentos.Add(medicamento);

                    using var commandDroguerias_medicamentos = new SqlCommand();

                    commandDroguerias_medicamentos.CommandType = System.Data.CommandType.StoredProcedure;
                    commandDroguerias_medicamentos.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    commandDroguerias_medicamentos.Connection = connection;

                    commandDroguerias_medicamentos.Parameters.Add("NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                    var reader_Droguerias = commandDroguerias_medicamentos.ExecuteReader();
                    while (reader_Droguerias.Read())
                    {
                        var codigoDrogeria = Convert.ToInt64(reader_Droguerias["CUIT"].ToString());
                        var drogeriaEncontrada = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == codigoDrogeria);
                        medicamento.AgregarDroguerias(drogeriaEncontrada);
                    }
                }
                connection.Close();
            }
            catch(SqlException ex)
            {
                connection.Close();
            }
            catch(Exception ex)
            {
                connection.Close();
            }
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return listaMedicamentos.AsReadOnly();
        }
    }
}
