using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instancia; 
        public static ControladoraMedicamentos Instancia
        {
            get 
            {
                if (instancia == null)
                {
                    instancia = new ControladoraMedicamentos();
                }
                return instancia;
            }
        }

        private ControladoraMedicamentos() 
        {

        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos() 
        {
            try
            {
                return RepositorioMedicamentos.Instancia.ListarMedicamentos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Agregar(Medicamento medicamento)
        {
            try
            {
                var medicamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos(); 
                var medicamentoEncontrado = medicamentos.FirstOrDefault(x => x.Nombre.ToLower() == medicamento.Nombre.ToLower()); 
                if (medicamentoEncontrado == null)
                {
                    RepositorioMedicamentos.Instancia.Agregar(medicamento); 
                    return $"El medicamento {medicamento.Nombre} ha sido agragado correctamente";
                }
                else
                {
                    return $"No se pudo agregar el medicamento {medicamento.Nombre}, ya existe.";
                }
            }
            catch (Exception)
            {
                return $"Ocurrio un error desconocido";
            }
        }

        public string Eliminar(Medicamento medicamento)
        {
            try
            {
                var medicamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos();
                var medicamentoEncontrado = medicamentos.FirstOrDefault(x => x.Nombre.ToLower() == medicamento.Nombre.ToLower());
                if (medicamentoEncontrado != null)
                {
                    RepositorioMedicamentos.Instancia.Eliminar(medicamento); 
                    return $"El medicamento {medicamento.Nombre} ha sido eliminado correctamente";
                }
                else
                {
                    return $"No se pudo eliminar el medicamento {medicamento.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return $"Ocurrio un error desconocido";
            }
        }
        public string Modificar(Medicamento medicamento)
        {
            try
            {
                var medicamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos(); 
                var medicamentoEncontrado = medicamentos.FirstOrDefault(x => x.Nombre.ToLower() == medicamento.Nombre.ToLower()); 
                if (medicamentoEncontrado != null)
                {
                    RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento); 
                    return $"El medicamento {medicamento.Nombre} ha sido modificado correctamente";
                }
                else
                {
                    return $"No se pudo modificar el medicamento {medicamento.Nombre} no existe.";
                }
            }
            catch (Exception)
            {
                return $"Ocurrio un error desconocido";
            }
        }

        
    }
}