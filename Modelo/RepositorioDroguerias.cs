using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Modelo
{
    public class RepositorioDroguerias
    {
        private static RepositorioDroguerias instancia;
        private List<Drogueria> droguerias;
        private IConfigurationRoot configuration;
        private RepositorioDroguerias()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            droguerias = new List<Drogueria>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_RECUPERARDROGUERIAS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                        var drogueria = new Drogueria();
                        drogueria.Cuit = Convert.ToInt64(reader["CUIT"].ToString());
                        drogueria.RazonSocial = reader["RAZON_SOCIAL"].ToString();
                        drogueria.Direccion = reader["DIRECCION"].ToString();
                        drogueria.Email = reader["EMAIL"].ToString();
                        droguerias.Add(drogueria);
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

        public static RepositorioDroguerias Instancia
        {
            get
            {
                instancia ??= new RepositorioDroguerias();
                return instancia;
            }
        }
        public bool Agregar(Drogueria drogueria)
        {

            if (AgregarDrogueria(Drogueria drogueria))
            {
                Drogueria.Add(drogueria);
                return true;
            }
            else return false;
        }

        public bool AgregarDrogueria(Drogueria drogueria)
        {
            var ok = false;
            var connection = configuration.GetConnectionString("");
            var sqlConection = new SqlConnection(connection);
            sqlConection.Open();
            var sqlTransaction = sqlConection.BeginTransaction();

            try
            {
                var command = new SqlCommand();
                command.CommandText = drogueria.ToString();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.RazonSocial;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.Email;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.Direccion;
                command.Parameters.Add("@Cuit", System.Data.SqlDbType.Float, 50).Value = drogueria.Cuit;
                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                ok = true;
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
            }
            return ok;
        }
        public bool Modificar(Drogueria drogueria)
        {
            if (ModificarDrogueria(drogueria))
            {
                var drogueriaexistente = drogueria.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
                drogueriaexistente.Modificar(drogueria);
                return true;
            }
            else return false;
        }
        public bool ModificarDrogueria(Drogueria drogueria) {
            var ok = false;
            var connection = configuration.GetConnectionString("");
            var sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            var sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                var command = new SqlCommand();
                command.CommandText = "SP_ModificarDrogueria";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = monodrogas.Nombre;
                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return ok;

        }
        public bool Eliminar (Drogueria drogueria)
        {
            if (EliminarDrogueria(drogueria)) {

                Drogueria.Remove(drogueria);
                return true;
            }
            else return false;
        }
        public bool EliminarDrogueria (Drogueria drogueria)
        {
            var ok = false;
            var connection = configuration.GetConnectionString("");
            var sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            var sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                var command = new SqlCommand();
                command.CommandText = "SP_EliminarDrogueria";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = sqlConnection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@RazonSocial", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.RazonSocial;
                command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.Email;
                command.Parameters.Add("@Direccion", System.Data.SqlDbType.NVarChar, 50).Value = drogueria.Direccion;
                command.Parameters.Add("@Cuit", System.Data.SqlDbType.Float, 50).Value = drogueria.Cuit; command.ExecuteNonQuery();
                sqlTransaction.Commit();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return ok;
        }
    }
        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }
    }
}