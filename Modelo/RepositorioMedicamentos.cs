using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class RepositorioMedicamentos : IRepositorio<Medicamento>
    {

        private static RepositorioMedicamentos instance;
        private IConfigurationRoot configuration;


        private RepositorioMedicamentos()
        {
            this.configuration = ConfigurationHelper.GetConfiguration("appsettings.json");
        }

        public static RepositorioMedicamentos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepositorioMedicamentos();
                }
                return instance;
            }
        }

        private string ConnectionString
        {
            get => configuration.GetConnectionString("DefaultConnection");
        }

        public IReadOnlyList<Medicamento> Recuperar()
        {
            List<Medicamento> medicamentos = new List<Medicamento>();
            // No necesitamos cerrar la conexión manualmente porque SqlConnection implementa IDisposable
            using (var connection = new SqlConnection(ConnectionString))

                try
                {
                    using var cmdMedicamentos = new SqlCommand();
                    cmdMedicamentos.CommandType = System.Data.CommandType.StoredProcedure;
                    cmdMedicamentos.CommandText = "SP_RECUPERARMEDICAMENTOS";
                    cmdMedicamentos.Connection = connection;

                    connection.Open();

                    var rdMedicamentos = cmdMedicamentos.ExecuteReader();
                    
                    // Recuperar las  monodrogas y droguerías ya registradas desde los otros repositorio
                    IReadOnlyCollection<Monodroga> monodrogas = RepositorioMonodrogas.Instancia.Monodrogas;
                    IReadOnlyCollection<Drogueria> droguerias = RepositorioDroguerias.Instancia.Droguerias;

                    while (rdMedicamentos.Read())
                    {
                        Medicamento medicamento = new Medicamento();
                        medicamento.NombreComercial = rdMedicamentos["NOMBRE_COMERCIAL"].ToString();
                        medicamento.EsVentaLibre = Convert.ToBoolean(rdMedicamentos["ES_VENTA_LIBRE"].ToString());
                        medicamento.PrecioVenta = Convert.ToDecimal(rdMedicamentos["PRECIO_VENTA"].ToString());
                        medicamento.Stock = Convert.ToInt32(rdMedicamentos["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(rdMedicamentos["STOCK_MINIMO"].ToString());

                        // Buscar la monodroga del medicamento, no puede ser null
                        string nombreMonodroga = rdMedicamentos["NOMBRE_MONODROGA"].ToString();
                        Monodroga monodroga = monodrogas.Where(m=>m.Nombre==nombreMonodroga).First();

                        // Buscamos todas las droguerías asociadas al medicamento
                        List<Int64> cuitDroguerias = new List<Int64>();

                        var cmdDrogueriasAsoc = new SqlCommand();
                        cmdDrogueriasAsoc.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdDrogueriasAsoc.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        cmdDrogueriasAsoc.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        cmdDrogueriasAsoc.Connection = connection;
                        var rdDrogueriasAsoc = cmdDrogueriasAsoc.ExecuteReader();


                        while(rdDrogueriasAsoc.Read())
                        {
                            cuitDroguerias.Add(Convert.ToInt64(rdDrogueriasAsoc["CUIT"].ToString()));
                        }

                        medicamento.Droguerias = droguerias.Where(d => cuitDroguerias.Contains(d.Cuit)).ToList();
                        medicamentos.Add(medicamento);
                        
                    }

                }
                catch (Exception) { }
            
            // La conexión se cierra porque salimos del scope del using
            return medicamentos;    
        }

        public bool Crear(Medicamento item)
        {
            return CrearOModificarMedicamento(item, true);
        }
        public bool Modificar(Medicamento item)
        {
            return CrearOModificarMedicamento(item, false);
        }

        public bool Eliminar(Medicamento item)
        {
            SqlTransaction transaction = null;
            using (var connection = new SqlConnection(ConnectionString))

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using var cmdMedicamentos = new SqlCommand();
                    cmdMedicamentos.CommandType = System.Data.CommandType.StoredProcedure;

                    // Este SP NO se va a ejecutar si hay droguerías asociadas al medicamento!!
                    cmdMedicamentos.CommandText = "SP_ELIMINARMEDICAMENTO";
                    
                    cmdMedicamentos.Connection = connection;
                    cmdMedicamentos.Transaction = transaction;

                    cmdMedicamentos.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = item.NombreComercial;
                    
                    int affectedRows = cmdMedicamentos.ExecuteNonQuery();
                    transaction.Commit();
                    return affectedRows > 0;
                }
                catch (SqlException ex)
                {
                    transaction?.Rollback();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                }
            return false;
        }




        private bool CrearOModificarMedicamento(Medicamento item, bool crear)
        {
            SqlTransaction transaction = null;
            using (var connection = new SqlConnection(ConnectionString))

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using var cmdMedicamentos = new SqlCommand();
                    cmdMedicamentos.CommandType = System.Data.CommandType.StoredProcedure;
                    if(crear)
                    {
                        cmdMedicamentos.CommandText = "SP_AGREGARMEDICAMENTO";
                    } else
                    {
                        // Este SP quita todas las droguerías asociadas con el medicamento al ejecutarse
                        cmdMedicamentos.CommandText = "SP_MODIFICARMEDICAMENTO";

                    }
                    cmdMedicamentos.Connection = connection;
                    cmdMedicamentos.Transaction = transaction;

                    cmdMedicamentos.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = item.NombreComercial;
                    cmdMedicamentos.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = item.EsVentaLibre;
                    cmdMedicamentos.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = item.PrecioVenta;
                    cmdMedicamentos.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = item.Stock;
                    cmdMedicamentos.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = item.StockMinimo;
                    cmdMedicamentos.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = item.Monodroga.Nombre;

                    int affectedRows = cmdMedicamentos.ExecuteNonQuery();


                    foreach (Drogueria drogueria in item.Droguerias)
                    {
                        using var cmdDrogueria = new SqlCommand();
                        cmdDrogueria.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdDrogueria.CommandText = "SP_AGREGAR_DROGUERIASMEDICAMENTO";
                        cmdDrogueria.Connection = connection;
                        cmdDrogueria.Transaction = transaction;
                        cmdDrogueria.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = item.NombreComercial;
                        cmdDrogueria.Parameters.Add("@CUIT", System.Data.SqlDbType.BigInt).Value = drogueria.Cuit;
                        cmdDrogueria.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return affectedRows > 0;
                }
                catch (SqlException ex)
                {
                    transaction?.Rollback();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();

                }
            return false;


        }
    }
}
