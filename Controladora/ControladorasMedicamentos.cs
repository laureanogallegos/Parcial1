using System.Collections.ObjectModel;

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
                return Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarMedicamento(Modelo.Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var ok = Modelo.RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} ya existe.";
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
                var listaMedicamentos = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    Modelo.RepositorioMedicamentos.Instancia.Eliminar(medicamentoEncontrado);
                    return "El medicamento {medicamento.NombreComercial} se eliminó correctamente";
                }
                else
                {
                    return "No se pudo eliminar el medicamento {medicamento.NombreComercial}, no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}