using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMonodrogas
    {
        private static RepositorioMonodrogas instancia;
        private List<Monodroga> monodrogas;
        private IConfigurationRoot configuration;
        private RepositorioMonodrogas()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            monodrogas = new List<Monodroga>();
            Recuperar();
        }

        private void Recuperar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_RECUPERARMONODROGAS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var monodroga = new Monodroga();
                        monodroga.Nombre = reader["NOMBRE"].ToString();
                        monodrogas.Add(monodroga);
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
        public bool Agregar(Monodroga monodrogas) {

            if (AgregarDroga(monodrogas))
            {
                Monodroga.Add(monodrogas);
                return true;
            }
            else return false; }

        public bool AgregarDroga(Monodroga monodrogas)
        {
            var ok = false;
            var connection = configuration.GetConnectionString("");
            var sqlConection = new SqlConnection(connection);
            sqlConection.Open();
            var sqlTransaction = sqlConection.BeginTransaction();

            try {
                var command = new SqlCommand();
                command.CommandText = monodrogas.ToString();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = monodrogas.Nombre;
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
        public bool Modificar(Monodroga monodroga)
        {
            if (Modificardroga(monodroga))
            {
                var drogaexistente = monodrogas.FirstOrDefault(x => x.Nombre == monodrogas.Nombre);
                drogaexistente.Modificar(monodrogas);
                return true;
            }
            else return false;

            public bool Modificardroga(Monodroga monodroga) {
                var ok = false;
                var connection = configuration.GetConnectionString("");
                var sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                var sqlTransaction = sqlConnection.BeginTransaction();

                try
                {
                    var command = new SqlCommand();
                    command.CommandText = "SP_ModificarMonodroga";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = sqlConnection;
                    command.Transaction = sqlTransaction;
                    command.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar, 50).Value = monodrogas.Nombre;
                    command.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    ok = true;
                }
            

            }
        }


public bool Eliminar (Monodroga monodroga){
            if (Eliminardroga(monodroga)
            {
                Monodroga.Remove(monodroga);
                return true;
            }
            else return false;
        }
        public bool Eliminardroga(Monodroga monodroga)
        {
            var ok = false;
            var connection = configuration.GetConnectionString("");
            var sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            var sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                var command = new SqlCommand();
                command.CommandText = "SP_EliminarMonodroga";
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
            return ok; }

        public static RepositorioMonodrogas Instancia
        {
            get
            {
                instancia ??= new RepositorioMonodrogas();
                return instancia;
            }
        }

        public ReadOnlyCollection<Monodroga> Monodrogas
        {
            get => monodrogas.AsReadOnly();
        }

    }
    }
