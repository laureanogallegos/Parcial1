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
            Recuperar();
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
        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return Medicamentos.AsReadOnly();
        }

        private void Recuperar()
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
                        var Medicamento = new Medicamento();
                        Medicamento.NOMBRE_COMERCIAL = reader["NOMBRE_COMERCIAL"].ToString();
                        Medicamento.ES_VENTA_LIBRE = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        Medicamento.STOCK = Convert.ToInt32(reader["STOCK"].ToString());
                        Medicamento.STOCK_MINIMO =Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        Medicamento.PRECIO_VENTA = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        Medicamentos.Add(Medicamento);
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
            if (AgregarMedicamento(medicamento))
            {
                Medicamentos.Add(medicamento);
                return true;
            }
            else { return false; }
        }

        public bool Eliminar(Medicamento medicamento)
        {
            if (EliminarMedicamento(medicamento))
            {
                Medicamentos.Remove(medicamento);
                return true;
            }
            else { return false; }

        }
        public bool Modificar(Medicamento medicamento)
        {
            if (ModificarMedicamento(medicamento))
            {
                return true;
            }
            return false;
        }
        public bool AgregarMedicamento(Medicamento medicamento)
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
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.BigInt).Value = medicamento.NOMBRE_COMERCIAL;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.NVarChar, 100).Value = medicamento.ES_VENTA_LIBRE;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.PRECIO_VENTA;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.DateTime).Value = medicamento.STOCK;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.DateTime).Value = medicamento.STOCK_MINIMO;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.DateTime).Value = medicamento.monodroga.Nombre;
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
            return ok;
        }
        public bool EliminarMedicamento(Medicamento medicamento)
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
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.BigInt).Value = medicamento.NOMBRE_COMERCIAL;
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
            return ok;
        }
        public bool ModificarMedicamento(Medicamento medicamento)
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
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.BigInt).Value = medicamento.NOMBRE_COMERCIAL;
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.ES_VENTA_LIBRE;
                command.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.PRECIO_VENTA;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.BigInt).Value = medicamento.STOCK;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.BigInt).Value = medicamento.STOCK_MINIMO;
                command.Parameters.Add("@MONODROGA", System.Data.SqlDbType.DateTime).Value = medicamento.monodroga.Nombre;
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
            return ok;
        }



    }
}
