using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private ControladoraMedicamento() { }
        private static ControladoraMedicamento instancia;
        public static ControladoraMedicamento Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraMedicamento();
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

        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoencontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre_Comercial.ToLower() == medicamento.Nombre_Comercial.ToLower());
                if (medicamentoencontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.Nombre_Comercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.Nombre_Comercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre_Comercial} ya existe.";
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
                var medicamentoencontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre_Comercial.ToLower() == medicamento.Nombre_Comercial.ToLower());
                if (medicamentoencontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.Nombre_Comercial} se eliminó correctamente";
                    }
                    else return $"El medicamento {medicamento.Nombre_Comercial} no se ha podido eliminar";
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre_Comercial} no existe.";
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
                var medicamentoencontrado = listaMedicamentos.FirstOrDefault(x => x.Nombre_Comercial.ToLower() == medicamento.Nombre_Comercial.ToLower());
                if (medicamentoencontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.Nombre_Comercial} se modificó correctamente";
                    }
                    else return $"El medicamento {medicamento.Nombre_Comercial} no se ha podido modificar";
                }
                else
                {
                    return $"El medicamento {medicamento.Nombre_Comercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}