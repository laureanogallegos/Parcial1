using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {

        public bool Verificacion(Medicamento pMedicamento)
        {
            var medicamentos = RepositorioMedicamentos.Instancia.Recuperar();
            var medicamentoExistente = medicamentos.FirstOrDefault(x => x.NombreComercial == pMedicamento.NombreComercial);
            if (medicamentoExistente == null)
            {
                return true;
            }
            else return false;
        }

        public string Agregar(Medicamento pMedicamento)
        {
            if (Verificacion(pMedicamento))
            {
                if (RepositorioMedicamentos.Instancia.Agregar(pMedicamento))
                {
                    return $"El medicamento {pMedicamento.NombreComercial} fue agregado exitosamente";
                }
                else return $"No se ha podido agregar el medicamento";
            }
            else return "El medicamento ya existe";
        }

        public string Modificar(Medicamento pMedicamento)
        {
            if (RepositorioMedicamentos.Instancia.Modificar(pMedicamento))
            {
                return $"El medicamento {pMedicamento.NombreComercial} se ha modificado correctamente.";
            }
            else return "No se ha podido modificar el medicamento.";
        }

        public string Eliminar(Medicamento pMedicamento)
        {
            if (RepositorioMedicamentos.Instancia.Modificar(pMedicamento))
            {
                return $"El medicamento {pMedicamento.NombreComercial} se ha eliminado correctamente";
            }
            else return "No se ha podido eliminar el medicamento.";
        }

        public ReadOnlyCollection<Drogueria> RecuperarDroguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias;
        }

        public ReadOnlyCollection<Monodroga> RecuperarMonodrogas()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }
    }
}