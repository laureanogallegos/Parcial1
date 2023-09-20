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
            RecuperarMedicamentos();
        }

        public static RepositorioMedicamentos Instancia
        {
            get
            {
                instancia ??= new RepositorioMedicamentos();
                return instancia;
            }
        }

        private void RecuperarMedicamentos()
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
                    while (reader.Read())
                    {
                        var medicamento = new Medicamento();
                        medicamento.NombreComercial = reader["NOMBRE_COMERCIAL"].ToString();
                        medicamento.VentaLibre = Convert.ToBoolean(reader["ES_VENTA_LIBRE"].ToString());
                        medicamento.Precio = Convert.ToDecimal(reader["PRECIO_VENTA"].ToString());
                        medicamento.StockActual = Convert.ToInt32(reader["STOCK"].ToString());
                        medicamento.StockMinimo = Convert.ToInt32(reader["STOCK_MINIMO"].ToString());
                        var nomMonodroga = reader["NOMBRE_MONODROGA"].ToString();
                        medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == nomMonodroga);

                        using var commandDroguerias = new SqlCommand();

                        commandDroguerias.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                        commandDroguerias.CommandType = System.Data.CommandType.StoredProcedure;
                        commandDroguerias.Connection = connection;

                        commandDroguerias.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.NombreComercial;
                        var readerDrogueriasProducto = commandDroguerias.ExecuteReader();
                        while (readerDrogueriasProducto.Read())
                        {
                            var nombreDrogueria = readerDrogueriasProducto["NOMBRE_COMERCIAL"].ToString();
                            var drogueria = RepositorioDroguerias.Instancia.Droguerias.FirstOrDefault(x=> x.); 
                        }

                    }
                }
                catch(SqlException ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch(Exception ex)
                {
                    connection.Close();
                    connection.Dispose();
                }
        }

        public ReadOnlyCollection<Medicamento> Medicamentos
        {
            get => medicamentos.AsReadOnly();
        }


    }
}
