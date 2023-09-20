using Modelo;
using System.Collections.ObjectModel;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instance;
        public static ControladoraMedicamentos Instance
        {
            get
            {
                if (instance == null) instance = new ControladoraMedicamentos();
                return instance;
            }
        }
        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamentos.Instance.RecuperarMedicamentos();
        }
        public string AgregarMedicamentos(Medicamento medicamento)
        {
            if (medicamento == null) return "EL MEDICAMENTO ES NULO";

            return (RepositorioMedicamentos.Instance.añadir(medicamento)) ?
                "El medicamento se añadio Correctamente " :
                "FALLO EL INGRESO DEL MEDICAMENTO";
        }
        public string ModificarMedicamentos(Medicamento medicamento)
        {
            if (medicamento == null) return "EL MEDICAMENTO ES NULO";

            return (RepositorioMedicamentos.Instance.Modificar(medicamento)) ?
                "El medicamento se modificó Correctamente" :
                "FALLO LA MODIFICACION DEL MEDICAMENTO";
        }
        public string EliminarMedicamentos(Medicamento medicamento)
        {
            if (medicamento == null) return "EL MEDICAMENTO ES NULO";

            return (RepositorioMedicamentos.Instance.Modificar(medicamento)) ?
                "El medicamento se elimino Correctamente" :
                "FALLO LA ELIMINACION DEL MEDICAMENTO";
        }
    }
}