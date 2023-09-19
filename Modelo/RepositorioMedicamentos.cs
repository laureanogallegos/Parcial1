using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
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

        /////////////////////////////////////////////// Agregar ///////////////////////////////////////////////
        public bool Agregar(Medicamento medicamento)
        {
            if (AgregarMedicamento(medicamento)) 
            {
                medicamentos.Add(medicamento);
                return true;
            }
            return false;
        }

        // Separo el codigo de la base de datos.
        private bool AgregarMedicamento(Medicamento medicamento)
        {
            var todoOk = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                // Parte medicamento.
                using var medicamentoCommand = new SqlCommand();
                medicamentoCommand.CommandType = System.Data.CommandType.StoredProcedure;
                medicamentoCommand.CommandText = "SP_AGREGARMEDICAMENTO";
                medicamentoCommand.Connection = connection;
                medicamentoCommand.Transaction = sqlTransaction;

                // Asigno los parametros para el medicamento.
                medicamentoCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                medicamentoCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                medicamentoCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                medicamentoCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                medicamentoCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                medicamentoCommand.Parameters.Add("@Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.MonodrogaMedicamento.Nombre;
                medicamentoCommand.ExecuteNonQuery(); // Ejecuto en la base de datos.

                // Parte drogueria.
                using var drogueriaCommand = new SqlCommand();
                drogueriaCommand.CommandType = System.Data.CommandType.StoredProcedure;
                drogueriaCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                drogueriaCommand.Connection = connection;
                drogueriaCommand.Transaction = sqlTransaction;

                // Asigno los parametros.
                drogueriaCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                drogueriaCommand.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.ListaDroguerias)
                {
                    drogueriaCommand.Parameters["@Cuit"].Value = drogueria.Cuit;
                    drogueriaCommand.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
                connection.Close();
                todoOk = true;
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
            return todoOk;
        }

        /////////////////////////////////////////////// Eliminar ///////////////////////////////////////////////
        public bool Eliminar(Medicamento medicamento)
        {
            if (EliminarMedicamento(medicamento))
            {
                medicamentos.Remove(medicamento);
                return true;
            }
            return false;
        }

        // Separo el codigo de la base de datos.
        private bool EliminarMedicamento(Medicamento medicamento)
        {
            var todoOk = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                using var medicamentoCommand = new SqlCommand();

                medicamentoCommand.CommandType = System.Data.CommandType.StoredProcedure;
                medicamentoCommand.CommandText = "SP_ELIMINARMEDICAMENTO";
                medicamentoCommand.Connection = connection;
                medicamentoCommand.Transaction = sqlTransaction;

                // Asigno el parametro.
                medicamentoCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;

                // Ejecuto en la base de datos.
                medicamentoCommand.ExecuteNonQuery();
                sqlTransaction.Commit();
                connection.Close();
                todoOk = true;
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
            return todoOk;
        }

        /////////////////////////////////////////////// Modificar ///////////////////////////////////////////////
        public bool Modificar(Medicamento medicamento)
        {
            if (ModificarMedicamento(medicamento))
            {
                var medicamentoList = medicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoList != null)
                {
                    medicamentoList.VentaLibre = medicamento.VentaLibre;
                    medicamentoList.PrecioVenta = medicamento.PrecioVenta;
                    medicamentoList.Stock = medicamento.Stock; 
                    medicamentoList.StockMinimo = medicamento.StockMinimo;
                    medicamentoList.MonodrogaMedicamento = medicamento.MonodrogaMedicamento;
                }
                return true;
            }
            return false;
        }

        // Separo el codigo de la base de datos.
        private bool ModificarMedicamento(Medicamento medicamento)
        {
            var todoOk = false;
            var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var sqlTransaction = connection.BeginTransaction();
            try
            {
                // Parte medicamento.
                using var medicamentoCommand = new SqlCommand();
                medicamentoCommand.CommandType = System.Data.CommandType.StoredProcedure;
                medicamentoCommand.CommandText = "SP_MODIFICARMEDICAMENTO";
                medicamentoCommand.Connection = connection;
                medicamentoCommand.Transaction = sqlTransaction;

                // Asigno los parametros.
                medicamentoCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                medicamentoCommand.Parameters.Add("@Es_Venta_Libre", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                medicamentoCommand.Parameters.Add("@Precio_Venta", System.Data.SqlDbType.Decimal).Value = medicamento.PrecioVenta;
                medicamentoCommand.Parameters.Add("@Stock", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                medicamentoCommand.Parameters.Add("@Stock_Minimo", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                medicamentoCommand.Parameters.Add("@Monodroga", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.MonodrogaMedicamento.Nombre;
                medicamentoCommand.ExecuteNonQuery(); // Ejecuto en la base de datos.

                // Parte drogueria.
                using var drogueriaCommand = new SqlCommand();
                drogueriaCommand.CommandType = System.Data.CommandType.StoredProcedure;
                drogueriaCommand.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                drogueriaCommand.Connection = connection;
                drogueriaCommand.Transaction = sqlTransaction;

                // Asigno los parametros.
                drogueriaCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                drogueriaCommand.Parameters.Add("@Cuit", System.Data.SqlDbType.BigInt);
                foreach (var drogueria in medicamento.ListaDroguerias)
                {
                    drogueriaCommand.Parameters["@Cuit"].Value = drogueria.Cuit;
                    drogueriaCommand.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
                connection.Close();
                todoOk = true;
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
            return todoOk;
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return medicamentos.AsReadOnly();
        }

        /////////////////////////////////////////////// Listar ///////////////////////////////////////////////
        private void ListarMedicamentos()
        {

            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))

                try
                {
                    using var medicamentoCommand = new SqlCommand();
                    medicamentoCommand.CommandType = System.Data.CommandType.Text;
                    medicamentoCommand.CommandText = "SP_RECUPERARMEDICAMENTOS";

                    medicamentoCommand.Connection = connection;
                    medicamentoCommand.Connection.Open(); // Abro la conexion.

                    // Hago reader.
                    var reader01 = medicamentoCommand.ExecuteReader();
                    while (reader01.Read()) 
                    {
                        // Parte medicamento.
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader01["Nombre_Comercial"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader01["Es_Venta_Libre"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(reader01["Precio_Venta"].ToString());
                        medicamento.Stock = Convert.ToInt32(reader01["Stock"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader01["Stock_Minimo"].ToString());
                        var monodrogaNombre = reader01["Monodroga_Nombre"].ToString();
                        medicamento.MonodrogaMedicamento = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(m => m.Nombre == monodrogaNombre);

                        // Parte drogueria.
                        using var drogueriaCommand = new SqlCommand();
                        drogueriaCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        drogueriaCommand.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";

                        drogueriaCommand.Parameters.Add("@Nombre_Comercial", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        drogueriaCommand.Connection = connection;

                        var reader02 = drogueriaCommand.ExecuteReader();
                        while (reader02.Read())
                        {
                            var cuitDrogueria = Convert.ToInt64(reader02["CUIT"].ToString());
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x => x.Cuit == cuitDrogueria);

                            // Agrego a la lista de droguerias que tiene medicamento.
                            medicamento.AgregarDrogueria(drogueria);
                        }

                        medicamentos.Add(medicamento);
                    }
                    medicamentoCommand.Connection.Close();
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
    }
}