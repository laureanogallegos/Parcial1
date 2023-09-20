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
                if(instancia == null)
                {
                    instancia = new ControladoraMedicamentos();
                }
                return instancia;
            }
        }
        public ControladoraMedicamentos()
        {
            var medicamento = new Medicamento();
        }
        public ControladoraMedicamentos(Medicamento medicamento)
        {

        }
        public string Agregar(Medicamento medicamento)
        {
            var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            if(medicamentoEncontrado == null)
            {
                RepositorioMedicamentos.Instancia.Agregar(medicamento);
                return $"El medicamento: {medicamento.NombreComercial} ha sido agregado";
            }
            return $"El medicamento: {medicamento.NombreComercial} ya existe";
        }
        public string Modificar(Medicamento medicamento)
        {
            var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            if (medicamentoEncontrado != null)
            {
                RepositorioMedicamentos.Instancia.Modificar(medicamento);
                return $"El medicamento: {medicamento.NombreComercial} ha sido modificado";
            }
            return $"El medicamento: {medicamento.NombreComercial} no existe";
        }
        public string Eliminar(Medicamento medicamento)
        {
            var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            if (medicamentoEncontrado != null)
            {
                RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                return $"El medicamento: {medicamento.NombreComercial} ha sido eliminado";
            }
            return $"El medicamento: {medicamento.NombreComercial} no existe";
        }

        public ReadOnlyCollection<Medicamento> ListarMedicamentos()
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
    }
}