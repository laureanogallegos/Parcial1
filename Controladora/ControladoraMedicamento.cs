using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Modelo.RepositorioDroguerias;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private static ControladoraMedicamento instancia;
        private ControladoraMedicamento()
        {

        }
        public static ControladoraMedicamento Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraMedicamento();
                }
                return instancia;
            }
        }
        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string AgregarMedicamento (Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre == medicamento.Nombre);
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.Nombre} se agregó correctamente";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.Nombre} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre == medicamento.Nombre);
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.Nombre} se modificó correctamente";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.Nombre} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre.ToLower() == medicamento.Nombre.ToLower());

                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamentoEncontrado.Nombre} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamentoEncontrado.Nombre} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar eliminar el medicamento.";
            }
        }
    }
   
}
