using Modelo;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        public List<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamento.Instancia.Medicamentos.ToList();
        }

        public string Agregar(Medicamento medicamento)
        {
            var medicamentos = RepositorioMedicamento.Instancia.Medicamentos;
            foreach (Medicamento med in medicamentos)
            {
                if (med.NombreComercial == medicamento.NombreComercial)
                {
                    return "Medicamento ya existente";
                }
            }
            if (medicamento.NombreComercial.Length > 50)
            {
                return "Nombre muy largo";
            }
            if (medicamento.NombreComercial == "")
            {
                return "Nombre vacio";
            }
            if (medicamento.MonodrogaMedicamento == null)
            {
                return "Sin Monodroga";
            }
            var droguerias = medicamento.Droguerias;
            foreach(var drogueria in droguerias)
            {
                if(droguerias.FindAll(x=> x.Cuit == drogueria.Cuit).Count != 1)
                {
                    return "Medicamento agregado varias veces en la misma drogueria";
                }
            }
            if (RepositorioMedicamento.Instancia.Agregar(medicamento))
            {
                return "";
            }
            else
            {
                return "Error al agregar en el repositorio";
            }
        }

        public string Modificar(Medicamento medicamento)
        {
            var medicamentos = RepositorioMedicamento.Instancia.Medicamentos;
            if (!medicamentos.Contains(medicamento))
            {
                return "Medicamento inexistente";
            }
            var droguerias = medicamento.Droguerias;
            foreach (var drogueria in droguerias)
            {
                if (droguerias.FindAll(x => x.Cuit == drogueria.Cuit).Count != 1)
                {
                    return "Medicamento agregado varias veces en la misma drogueria";
                }
            }
            if (medicamento.NombreComercial == "")
            {
                return "Nombre vacio";
            }
            if (medicamento.MonodrogaMedicamento == null)
            {
                return "Sin Monodroga";
            }
            if (RepositorioMedicamento.Instancia.Modificar(medicamento))
            {
                return "";
            }
            else
            {
                return "Error al modificar en el repositorio";
            }
        }
        public string Eliminar(Medicamento medicamentoAEliminar)
        {
            var medicamentos = RepositorioMedicamento.Instancia.Medicamentos;
            if (!medicamentos.Contains(medicamentoAEliminar))
            {
                return "Medicamento inexistente";
            }
            var droguerias = medicamentoAEliminar.Droguerias;
            if (RepositorioMedicamento.Instancia.Eliminar(medicamentoAEliminar))
            {
                return "";
            }
            else
            {
                return "Error al eliminar en el repositorio";
            }
        }

        public List<Drogueria> RecuperarDroguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias.ToList();
        }

        public List<Monodroga> RecuperarMonodrogas()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas.ToList();
        }
    }
}