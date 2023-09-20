using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instance;
        private static readonly string DBERR_MSG = "Error de base de datos, " +
            "intente reiniciar el programa y realizar la acción nuevamente";
        private ControladoraMedicamentos() {
        }

        public static ControladoraMedicamentos Instance
        {
            get { 
                if(instance== null) { 
                    instance = new ControladoraMedicamentos();
                }
                return instance;
            }
        }


        public IReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamentos.Instance.Recuperar();
        }

        public string? CrearMedicamento(Medicamento medicamento)
        {
            if(!ValidarNombreMedicamentoNuevo(medicamento))
            {
                return "Ya existe un medicamento con ese nombre";
            }
            if(!ValidarDrogueriasMedicamento(medicamento))
            {
                return "El medicamento tiene droguerías duplicadas";
            }
            if(!RepositorioMedicamentos.Instance.Crear(medicamento))
            {
                return DBERR_MSG;
            }
            return null;
        }

        public string? ModificarMedicamento(Medicamento medicamento)
        {
            if (!ValidarDrogueriasMedicamento(medicamento))
            {
                return "El medicamento tiene droguerías duplicadas";
            }
            if (!RepositorioMedicamentos.Instance.Modificar(medicamento)) {
                return DBERR_MSG;
            }
            return null;
        }

        public string? EliminarMedicamento(Medicamento medicamento)
        {
            if(!ValidarMedicamentoNoTieneDroguerias(medicamento))
            {
                return "El medicamento tíene droguerías asignadas, por favor desvincule las droguerías primero";
            }
            if(!RepositorioMedicamentos.Instance.Eliminar(medicamento))
            {
                return DBERR_MSG;
            }
            return null;
        }

        private bool ValidarNombreMedicamentoNuevo(Medicamento medicamentoNuevo)
        {
            return !RecuperarMedicamentos().Any(m => m.NombreComercial == medicamentoNuevo.NombreComercial);
        }

        private bool ValidarDrogueriasMedicamento(Medicamento medicamento)
        {
            List<Int64> drogueriasPresentes = new List<Int64>();
            foreach (Drogueria drogueria in medicamento.Droguerias)
            {
                if (drogueriasPresentes.Contains(drogueria.Cuit)) return false;
                drogueriasPresentes.Add(drogueria.Cuit);
            }
            return true;
        }

        private bool ValidarMedicamentoNoTieneDroguerias(Medicamento medicamento)
        {
            return medicamento.Droguerias.Count() == 0;
        }
    }
}
