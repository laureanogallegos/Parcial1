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
        private List<Medicamento> Medicamentos;
        private IConfigurationRoot configuration;
        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            Medicamentos = new List<Medicamento>();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            { 
                if(instancia == null)
                { instancia= new RepositorioMedicamentos();}
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            Medicamentos.Clear();
            Listar();
            return Medicamentos.AsReadOnly();

        }

        private void Listar()
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {
                        //por cada fila que creo tengo que asignar manualmente cada columna con cada propiedad
                        var medicamento =new Medicamento();
                        medicamento.Nombre_comercial = (reader["Nombre_comercial"].ToString());
                        medicamento.Es_venta_libre = Convert.ToBoolean(reader["Es_venta_libre"]);
                        medicamento.Precio_venta =Convert.ToDecimal(reader["Precio_venta"]);
                        medicamento.Stock = Convert.ToInt32(reader["stock"]);
                        medicamento.Stock_Minimo = Convert.ToInt32(reader["stock_minimo"]);
                        var monodroga = reader["Nombre_monodroga"].ToString();
                        var mimonodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == monodroga);
                        medicamento.Monodroga = mimonodroga;
                        ListarDrogueria(medicamento);
                        Medicamentos.Add(medicamento);
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

        private void ListarDrogueria(Medicamento medicamento)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("Nombre_comercial", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Nombre_comercial;

                    /////////////////////////
                    command.Connection = connection;
                    command.Connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())//lee a traves de todas las filas que existen en la tabla
                    {                    
                        var drog =Convert.ToInt64(reader["cuit"]);
                        var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == drog);
                        medicamento.Droguerias.Add(drogueria);
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
            var ok=false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqltransaction = connection.BeginTransaction();
                try
                {
                    using var command = new SqlCommand();
                    //otra forma de hacerlo es usando Store Procedures
                    command.CommandText = "SP_AGREGARMEDICAMENTO";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Transaction = sqltransaction;

                    command.Parameters.Add("@Nombre_comercial", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Nombre_comercial;
                    command.Parameters.Add("@Es_venta_libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_venta_libre;
                    command.Parameters.Add("@Precio_venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                    command.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                    command.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.Stock_Minimo;
                    command.Parameters.Add("@Monodroga", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Monodroga.Nombre;

                    command.ExecuteNonQuery();
                    sqltransaction.Commit();
                    connection.Close();
                    ok = true;
               
                }
                catch (SqlException ex)
                {
                    sqltransaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    sqltransaction.Rollback();
                    connection.Close();
                    connection.Dispose();
                }
            return ok;
        }


        public bool Modificar(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqltransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                //otra forma de hacerlo es usando Store Procedures
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqltransaction;

                command.Parameters.Add("@Nombre_comercial", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Nombre_comercial;
                command.Parameters.Add("@Es_venta_libre", System.Data.SqlDbType.Bit).Value = medicamento.Es_venta_libre;
                command.Parameters.Add("@Precio_venta", System.Data.SqlDbType.Decimal).Value = medicamento.Precio_venta;
                command.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                command.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.Stock_Minimo;
                command.Parameters.Add("@Monodroga", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Monodroga.Nombre;

                command.ExecuteNonQuery();
                sqltransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }



        public bool Eliminar(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqltransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                //otra forma de hacerlo es usando Store Procedures
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqltransaction;

                command.Parameters.Add("@Nombre_comercial", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Nombre_comercial;
               
                command.ExecuteNonQuery();
                sqltransaction.Commit();
                connection.Close();
                ok = true;
            }
            catch (SqlException ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;
        }


        public bool Agregardrogueria(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqltransaction = connection.BeginTransaction();
            try
            {
                using var command = new SqlCommand();
                //otra forma de hacerlo es usando Store Procedures
                command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Transaction = sqltransaction;

                command.Parameters.Add("@Nombre_comercial", System.Data.SqlDbType.VarChar, 50).Value = medicamento.Nombre_comercial;
                command.Parameters.Add("@cuit", System.Data.SqlDbType.Bit).Value = medicamento.Droguerias[0].Cuit; //porque voy a agregar de a una 


                command.ExecuteNonQuery();
                sqltransaction.Commit();
                connection.Close();
                ok = true;

            }
            catch (SqlException ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception ex)
            {
                sqltransaction.Rollback();
                connection.Close();
                connection.Dispose();
            }
            return ok;

         }

    }
}
