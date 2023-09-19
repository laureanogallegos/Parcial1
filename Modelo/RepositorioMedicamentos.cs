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
            ListarMedicamentos();
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
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_Comercial;
                command.Parameters.Add("Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_Venta_Libre;
                command.Parameters.Add("Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                command.Parameters.Add("Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("Stock_Minimo", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                command.Parameters.Add("Nombre_Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                AgregarDroguerias_Medicamento(medicamento);
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
            finally
            {
                connection.Close();
            }
            return ok;
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
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_Comercial;
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
            finally
            {
                connection.Close();
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
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre_Comercial;
                command.Parameters.Add("Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_Venta_Libre;
                command.Parameters.Add("Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                command.Parameters.Add("Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("Stock_Minimo", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_Venta;
                command.Parameters.Add("Nombre_Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                AgregarDroguerias_Medicamento(medicamento);
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
            finally
            {
                connection.Close();
            }
            return ok;
        }

        public bool Modificar(Medicamento medicamento)
        {
            if (ModificarMedicamento(medicamento))
            {
                var NuevoMedicamento = medicamentos.FirstOrDefault(med => med.Nombre_Comercial == medicamento.Nombre_Comercial);
                NuevoMedicamento.Nombre_Comercial = medicamento.Nombre_Comercial;
                NuevoMedicamento.Es_Venta_Libre = medicamento.Es_Venta_Libre;
                NuevoMedicamento.Precio_Venta = medicamento.Precio_Venta;
                NuevoMedicamento.Stock = medicamento.Stock;
                NuevoMedicamento.Stock_Minimo = medicamento.Stock_Minimo;
                NuevoMedicamento.Monodroga = medicamento.Monodroga;
                return true;
            }
            return false;
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return medicamentos.AsReadOnly();
        }

        private void ListarMedicamentos()
        {

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.Nombre_Comercial = reader["Nombre_Comercial"].ToString();
                        medicamento.Es_Venta_Libre = Convert.ToBoolean(reader["Es_Venta_Libre"].ToString());
                        medicamento.Precio_Venta = Convert.ToDecimal(reader["Precio_Venta"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader["Stock"].ToString());
                        medicamento.Stock_Minimo = Convert.ToInt32(reader["Stock_Minimo"].ToString());
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Recuperar(reader["Monodroga_Nombre"].ToString());
                        medicamento.Droguerias = TraerDroguerias_Medicamentos(medicamento.Nombre_Comercial);
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


        private List<Drogueria> TraerDroguerias_Medicamentos(string nom_drogueria)
        {
            List<Drogueria> droguerias = new List<Drogueria>();

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 25).Value = nom_drogueria;
                    command.Connection = connection;

                    command.Connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var drogueria = new Drogueria();
                        drogueria.Cuit = Convert.ToInt64(reader["Cuit"]);
                        drogueria.RazonSocial = reader["Razon_Social"].ToString();
                        drogueria.Direccion = reader["Direccion"].ToString();
                        drogueria.Email = reader["Email"].ToString();
                        droguerias.Add(drogueria);
                    }
                    command.Connection.Close();
                    return droguerias;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return droguerias;

                }
                catch (Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                    return droguerias;
                }
        }

        private void AgregarDroguerias_Medicamento(Medicamento medicamento)
        {
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;

                for (int i = 0; i < medicamento.Droguerias.Count; i++)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("@Nombre_Comercial_Medicamento", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.Nombre_Comercial;
                    command.Parameters.Add("@Cuit_Drogueria", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Droguerias[i].Cuit;
                    command.ExecuteNonQuery();
                }
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
        }
    }
}
