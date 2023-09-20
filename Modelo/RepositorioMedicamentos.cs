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
            Recuperar();
        }

        public void Recuperar()
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
                    ReadOnlyCollection<Monodroga> monodrogas = RepositorioMonodrogas.Instancia.Monodrogas;
                    ReadOnlyCollection<Drogueria> droguerias = RepositorioDroguerias.Instancia.Droguerias;
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK_ACTUAL"]);
                        medicamento.PrecioVenta = Convert.ToDecimal(reader["STOCK_ACTUAL"]);

                        var esVentaLibre = Convert.ToInt32(reader["ES_VENTA_LIBRE"]);
                        if (esVentaLibre == 1)
                        {
                            medicamento.EsVentaLibre = true;
                        }else
                        {
                            medicamento.EsVentaLibre = false;
                        }
             
                        var nombreMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        Monodroga monodroga = monodrogas.FirstOrDefault(x => x.Nombre.ToLower() == nombreMonodroga.ToLower());
                        medicamento.Monodroga = monodroga;

                        command.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.VarChar, 50).Value = medicamento.NombreComercial;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Connection.Open();
                        var reader1 = command.ExecuteReader();
                        while (reader1.Read())
                        {
                            var cuit = (long) Convert.ToDouble(reader1["CUIT"].ToString());
                            var drogueriaEncontrada = droguerias.FirstOrDefault(x => x.Cuit == cuit);
                            medicamento.Droguerias.Add(drogueriaEncontrada);
                        }
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

        public bool Agregar(Medicamento medicamento)
        {
           var ok = false;
           using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

           try
            {
                using var command = new SqlCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                int esVentaLibre;
                if(medicamento.EsVentaLibre)
                {
                    esVentaLibre = 1;
                }else
                {
                    esVentaLibre = 0;
                }
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Int).Value = esVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA_DECIMAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.DateTime).Value = medicamento.StockActual;
                command.Parameters.Add("@MONODROGRA", System.Data.SqlDbType.DateTime).Value = medicamento.Monodroga.Nombre;
                command.ExecuteNonQuery();
                connection.Close();
                medicamentos.Add(medicamento);
                ok = true;
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
            return ok;
        }

        public bool Eliminar(Medicamento medicamento)
        {
            var ok = false; 
           using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            try
            {
                using var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_ELIMINARMEDICAMENTO";
                command.Connection = connection;
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                command.ExecuteNonQuery();
                connection.Close();
                medicamentos.Remove(medicamento);
                ok = true;
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
            return ok;
        }

        public bool Modificar(Medicamento medicamento)
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
                command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                int esVentaLibre;
                if (medicamento.EsVentaLibre)
                {
                    esVentaLibre = 1;
                }
                else
                {
                    esVentaLibre = 0;
                }
                command.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Int).Value = esVentaLibre;
                command.Parameters.Add("@PRECIO_VENTA_DECIMAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.PrecioVenta;
                command.Parameters.Add("@STOCK", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.StockActual;
                command.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.DateTime).Value = medicamento.StockActual;
                command.Parameters.Add("@MONODROGRA", System.Data.SqlDbType.DateTime).Value = medicamento.Monodroga.Nombre;

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                medicamentos.Clear(); 
                Recuperar();
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

        public bool AgregarDrogueria(Drogueria drogueria, Medicamento medicamento)
        {
            var ok = false;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var command = new SqlCommand();

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();
                    command.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 25).Value = medicamento.NombreComercial;
                    command.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt, 25).Value = Convert.ToInt32(drogueria.Cuit);
                    command.ExecuteNonQuery();
                    connection.Close();
                    medicamento.Droguerias.Add(drogueria);
                    ok = true;
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
            return ok;
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }
    }
}
