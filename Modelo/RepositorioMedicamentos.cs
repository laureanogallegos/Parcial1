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
            medicamentos = new List<Medicamento>();
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
        }

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
        public bool Agregar(Medicamento medicamento)
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
                command.Parameters.Add("@ES_VENTA:LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();

                using var commandDrogerias = new SqlCommand();
                commandDrogerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDrogerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDrogerias.Connection = connection;
                commandDrogerias.Transaction = transaction;
                commandDrogerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial.ToString();
                commandDrogerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                foreach (var drogeria in medicamento.droguerias)
                {
                    commandDrogerias.Parameters["@CUIT"].Value = drogeria.Cuit;
                    commandDrogerias.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
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

        public bool Modificar(Medicamento medicamento)
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
                command.Parameters.Add("@ES_VENTA:LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();

                using var commandDrogerias = new SqlCommand();
                commandDrogerias.CommandType = System.Data.CommandType.StoredProcedure;
                commandDrogerias.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandDrogerias.Connection = connection;
                commandDrogerias.Transaction = transaction;
                commandDrogerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial.ToString();
                commandDrogerias.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt);

                foreach (var drogeria in medicamento.droguerias)
                {
                    commandDrogerias.Parameters["@CUIT"].Value = drogeria.Cuit;
                    commandDrogerias.ExecuteNonQuery();
                }

                transaction.Commit();
                connection.Close();
                medicamentos.Add(medicamento);
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
        public bool Eliminar(Medicamento medicamento)
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
                transaction.Commit();
                connection.Close();
                medicamentos.Remove(medicamento);
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
        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var cmd = new SqlCommand();
                    cmd.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    cmd.Connection.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        var monodroga = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre.ToLower() == monodroga.ToLower());
                        medicamentos.Add(medicamento);
                        using var cmdDrogueria = new SqlCommand();
                        cmdDrogueria.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdDrogueria.Connection = connection;
                        cmdDrogueria.Connection.Open();
                        var readerDroguerias = cmdDrogueria.ExecuteReader();
                        while(readerDroguerias.Read())
                        {
                            var drogueria = Convert.ToInt64(readerDroguerias["CUIT"].ToString());
                            var drogeriaEncontrada = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == drogueria);
                            medicamento.AgregarDrogueria(drogeriaEncontrada);
                        }

                    }
                    cmd.Connection.Close();
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

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return medicamentos.AsReadOnly();
        }

    }
}
