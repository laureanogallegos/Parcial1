using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Modelo
{
    public class RepositorioMedicamentos
    {
        private static RepositorioMedicamentos instance;
        private IConfigurationRoot configuration;
        private List<Medicamento> medicamentos;
        public static RepositorioMedicamentos Instance
        {
            get
            {
                if (instance == null) instance = new RepositorioMedicamentos();
                return instance;
            }
        }

        private RepositorioMedicamentos()
        {
            medicamentos = new List<Medicamento>();
            ListarMedicamentos();
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return medicamentos.AsReadOnly();
        }

        public bool añadir(Medicamento medicamento)
        {
            if (medicamento == null) return false;
            if (medicamentos.Exists(x => x.Nombre == medicamento.Nombre)) return false;

            bool ret = añadirSql(medicamento);

            if (ret)
            {
                medicamentos.Add(medicamento);
            }
            return ret;

        }
        public bool Modificar(Medicamento medicamento)
        {
            if (medicamento == null) return false;
            if (!medicamentos.Exists(x => x.Nombre == medicamento.Nombre)) return false;

            bool ret = modificarSql(medicamento);

            if (ret)
            {
                var exmedicamento = RepositorioMedicamentos.Instance.medicamentos.FirstOrDefault(x => x.Nombre == medicamento.Nombre);
                exmedicamento = medicamento;
            }
            return ret;

        }
        public bool Eliminar(Medicamento medicamento)
        {
            if (medicamento == null) return false;
            if (!medicamentos.Exists(x => x.Nombre == medicamento.Nombre)) return false;

            bool ret = eliminarSql(medicamento);

            if (ret)
            {
                var exmedicamento = RepositorioMedicamentos.Instance.medicamentos.FirstOrDefault(x => x.Nombre == medicamento.Nombre);
                RepositorioMedicamentos.Instance.medicamentos.Remove(exmedicamento);
            }
            return ret;

        }

        private bool añadirSql(Medicamento medicamento)
        {
            bool ret = false;

            using var coneccion = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            using var comando = new SqlCommand();
            comando.Connection = coneccion;
            var transa = comando.Transaction;

            try
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_AGREGARMEDICAMENTO";

                comando.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                comando.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                comando.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                comando.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                comando.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                comando.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                transa.Commit();
                ret = true;
                comando.Connection.Close();
            }
            catch (SqlException ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            catch (Exception ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            return ret;
        }
        private bool eliminarSql(Medicamento medicamento)
        {
            bool ret = false;

            using var coneccion = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            using var comando = new SqlCommand();
            comando.Connection = coneccion;
            var transa = comando.Transaction;

            try
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_ELIMINARMEDICAMENTO";

                comando.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                transa.Commit();
                ret = true;
                comando.Connection.Close();
            }
            catch (SqlException ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            catch (Exception ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            return ret;
        }
        private bool modificarSql(Medicamento medicamento)
        {
            bool ret = false;

            using var coneccion = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            using var comando = new SqlCommand();
            comando.Connection = coneccion;
            var transa = comando.Transaction;

            try
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_MODIFICARMEDICAMENTO";

                comando.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                comando.Parameters.Add("@ES_VENTA_LIBRE", System.Data.SqlDbType.Bit).Value = medicamento.VentaLibre;
                comando.Parameters.Add("@PRECIO_VENTA", System.Data.SqlDbType.Decimal).Value = medicamento.Precio;
                comando.Parameters.Add("@STOCK", System.Data.SqlDbType.Int).Value = medicamento.Stock;
                comando.Parameters.Add("@STOCK_MINIMO", System.Data.SqlDbType.Int).Value = medicamento.StockMinimo;
                comando.Parameters.Add("@MONODROGA", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Monodroga.Nombre;
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                transa.Commit();
                ret = true;
                comando.Connection.Close();
            }
            catch (SqlException ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            catch (Exception ex)
            {
                transa.Rollback();
                coneccion.Close();
                coneccion.Dispose();
            }
            return ret;
        }

        private void ListarMedicamentos()
        {
            using var coneccion = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            using var comando = new SqlCommand();
            try
            {
                comando.Connection = coneccion;
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "SP_RECUPERARMEDICAMENTOS";
                comando.Connection.Open();
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var medicamento = new Medicamento();
                    medicamento.Nombre = reader["NOMBRE_COMERCIAL"].ToString();
                    medicamento.Stock = int.Parse(reader["STOCK"].ToString());
                    medicamento.VentaLibre = bool.Parse(reader["ES_VENTA_LIBRE"].ToString());
                    medicamento.Precio = decimal.Parse(reader["PRECIO_VENTA"].ToString());
                    var nombredroga = reader["NOMBRE_MONODROGA"];
                    var droga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == nombredroga);
                    medicamento.Monodroga = droga;
                    //////////////////
                    using var comando2 = new SqlCommand();
                    comando2.Connection = coneccion;
                    comando2.CommandText = "SP_RECUPERARDROGUERIASMEDICAMENTOS";
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("@NOMBRE_COMERCIAL", System.Data.SqlDbType.NVarChar, 50).Value = medicamento.Nombre;
                    var readerdrogas = comando2.ExecuteReader();
                    while (readerdrogas.Read())
                    {
                        var drogueria = new Drogueria();
                        drogueria.Direccion = readerdrogas["DIRECCION"].ToString();
                        drogueria.Email = readerdrogas["EMAIL"].ToString();
                        drogueria.Cuit = long.Parse(readerdrogas["CUIT"].ToString());
                        drogueria.RazonSocial = readerdrogas["RAZON_SOCIAL"].ToString();

                        medicamento.DrogueriaList.Add(drogueria);

                        
                    }
                    medicamentos.Add(medicamento);
                }
                comando.Connection.Close();
            }
            catch(SqlException ex)
            {
                coneccion.Close();
                coneccion.Dispose();
            }
            catch (Exception ex)
            {
                coneccion.Close();
                coneccion.Dispose();
            }
        }

    }
}
