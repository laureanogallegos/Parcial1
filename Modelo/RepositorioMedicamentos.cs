using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instancia;
        private List <Medicamento> listaMedicamentos;
        private IConfigurationRoot configuration;

        private RepositorioMedicamentos()
        {
            configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
            listaMedicamentos = new List<Medicamento>();
            Recuperar();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                if (instancia == null) instancia = new RepositorioMedicamentos();
                return instancia;
            }
        }
        public bool AgregarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            ///////////////////////////
            try
            {
                using var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;
                command.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.esVentaLibre;
                command.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.previoVenta;
                command.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.stock;
                command.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.stockMinimo;
                command.Parameters.Add("@Nombre_Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                command.ExecuteNonQuery();

                using SqlCommand commandos = new SqlCommand();
                commandos.CommandType = System.Data.CommandType.StoredProcedure;
                commandos.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandos.Connection = connection;
                commandos.Transaction = sqlTransaction;

                commandos.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;
                commandos.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.drogueria)
                {
                    commandos.Parameters["@Cuit"].Value = drogueria.Cuit;
                    commandos.ExecuteNonQuery();
                }
                listaMedicamentos.Add(medicamento);

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
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

        public bool ModificarMedicamento(Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            ///////////////////////////
            try
            {
                using var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_MODIFICARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;
                command.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.esVentaLibre;
                command.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.previoVenta;
                command.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.stock;
                command.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.stockMinimo;
                command.Parameters.Add("@Nombre_Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.monodroga.Nombre;
                command.ExecuteNonQuery();

                using SqlCommand commandos = new SqlCommand();
                commandos.CommandType = System.Data.CommandType.StoredProcedure;
                commandos.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                commandos.Connection = connection;
                commandos.Transaction = sqlTransaction;

                commandos.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;
                commandos.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.drogueria)
                {
                    commandos.Parameters["@Cuit"].Value = drogueria.Cuit;
                    commandos.ExecuteNonQuery();
                }
                listaMedicamentos.Remove(medicamento);
                listaMedicamentos.Add(medicamento);
                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
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
        public bool Eliminar (Medicamento medicamento)
        {
            var ok = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            ///////////////////////////
            try
            {
                using var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "SP_AGREGARMEDICAMENTO";
                command.Connection = connection;
                command.Transaction = sqlTransaction;
                command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;

                listaMedicamentos.Remove(medicamento);

                command.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
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

        private void Recuperar() 
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                try
                {
                    using var command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    command.Connection = connection;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        
                        medicamento.nombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.esVentaLibre = Convert.ToByte(reader["ES_VENTA_LIBRE"]);
                        medicamento.previoVenta = Convert.ToDecimal(reader["PRECIO_VENTA"]);
                        medicamento.stock = Convert.ToInt32(reader["STOCK"]);
                        medicamento.stockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"]);
                        var nombremonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == nombremonodroga);

                        using var commandos = new SqlCommand();
                        commandos.CommandType = System.Data.CommandType.StoredProcedure;
                        commandos.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        command.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.nombreComercial;
                        commandos.Connection = connection;
   
                            var readerdroguerias = commandos.ExecuteReader();
                            while (readerdroguerias.Read())
                        {
                                var drogueria = new Drogueria();                        
                                drogueria.Cuit = Convert.ToInt64(readerdroguerias["CUIT"]);
                                drogueria.RazonSocial = readerdroguerias["RAZON_SOCIAL"].ToString();
                                drogueria.Direccion = readerdroguerias["DIRECCION"].ToString();
                                drogueria.Email = readerdroguerias["EMAIL"].ToString();
                                medicamento.drogueria.Add(drogueria);
                            }
                        listaMedicamentos.Add(medicamento);
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
        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
        {
            return listaMedicamentos.AsReadOnly();
        }

        }
    }

