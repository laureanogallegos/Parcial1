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
        public ReadOnlyCollection<Modelo.Medicamento> RecuperarMedicamentos()
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
        public string AgregarMedicamentos(Modelo.Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var MedicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NOMBRE_COMERCIAL == medicamento.NOMBRE_COMERCIAL);
                if (MedicamentoEncontrado == null)
                {
                    var ok = Modelo.RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El Medicamento: {medicamento.NOMBRE_COMERCIAL} se agregó correctamente";
                    }
                    else return $"El Medicamento: {medicamento.NOMBRE_COMERCIAL} no se ha podido agregar";
                }
                else
                {
                    return $"El Medicamento con Nombre {medicamento.NOMBRE_COMERCIAL} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarMedicamento(Modelo.Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NOMBRE_COMERCIAL == medicamento.NOMBRE_COMERCIAL);
                if (medicamentoEncontrado != null)
                {
                    var ok = Modelo.RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento: {medicamento.NOMBRE_COMERCIAL} se eliminó correctamente";
                    }
                    else return $"El medicamento: {medicamento.NOMBRE_COMERCIAL} no se ha podido eliminar";
                }
                else
                {
                    return $"El medicamento {medicamento.NOMBRE_COMERCIAL} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
        public string ModificarMedicamento(Modelo.Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var MedicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NOMBRE_COMERCIAL == medicamento.NOMBRE_COMERCIAL);
                if (MedicamentoEncontrado != null)
                {
                    var ok = Modelo.RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NOMBRE_COMERCIAL} se modifico correctamentee";
                    }
                    else return $"El medicamento {medicamento.NOMBRE_COMERCIAL} no se ha podido modificar";
                }
                else
                {
                    return $"El medicamento {medicamento.NOMBRE_COMERCIAL} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }

        }

    }
}
