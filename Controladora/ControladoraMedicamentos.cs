using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private ControladoraMedicamentos() { }
        private static ControladoraMedicamentos instancia;

        public static ControladoraMedicamentos Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraMedicamentos();
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ReadOnlyCollection<Monodroga> RecuperarMonodrogas()
        {
            try
            {
                return Modelo.RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            try
            {
                return Modelo.RepositorioDroguerias.Instancia.Droguerias;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Metodo de solo lectura para obtener solo las droguerias que estan relacionadas con este medicamento.
        public ReadOnlyCollection<Drogueria> RecuperarDrogueriasAsignadas(Medicamento medicamento)
        {
            var listaDroguerias = Modelo.RepositorioDroguerias.Instancia.Droguerias;

            // Lista de cuits de las droguerias asignadas al medicamento.
            var cuitsDroguerias = medicamento.ListaDroguerias.Select(d => d.Cuit);

            var drogueriasAsignadas = listaDroguerias.Where(d => cuitsDroguerias.Contains(d.Cuit));

            return drogueriasAsignadas.ToList().AsReadOnly();
        }

        // Metodo de solo lectura para obtener solo las droguerias que no estan relacionadas con este medicamento.
        public ReadOnlyCollection<Drogueria> RecuperarDrogueriasNoAsignadas(Medicamento medicamento)
        {
            var listaDroguerias = Modelo.RepositorioDroguerias.Instancia.Droguerias;

            // Lista de cuits de las droguerias asignadas al medicamento.
            var cuitsDroguerias = medicamento.ListaDroguerias.Select(d => d.Cuit);

            var drogueriasAsignadas = listaDroguerias.Where(d => !cuitsDroguerias.Contains(d.Cuit));

            return drogueriasAsignadas.ToList().AsReadOnly();
        }

        //////////////////////////////////////////// Agregar ///////////////////////////////////////////////////
        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var buscoMedicamento = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (buscoMedicamento == null)
                {
                    var totoOk = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (totoOk)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente.";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar.";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar agregar un medicamento.";
            }
        }

        //////////////////////////////////////////// Eliminar ///////////////////////////////////////////////////
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var buscoMedicamento = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (buscoMedicamento != null)
                {
                    var todoOk = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (todoOk)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se elimino correctamente.";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar.";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar eliminar medicamento.";
            }
        }

        //////////////////////////////////////////// Modificar ///////////////////////////////////////////////////
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var todoOk = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                if (todoOk)
                {
                    return $"El medicamento {medicamento.NombreComercial} se modifico correctamente.";
                }
                else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar.";
            }
            catch (Exception)
            {
                return "Error desconocido al intentar modificar el medicamento.";
            }
        }
    }
}