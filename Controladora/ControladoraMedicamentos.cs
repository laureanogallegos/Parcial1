using Modelo;
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

        ControladoraMedicamentos()
        {

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

        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower()); 
                if (medicamentoEncontrado == null)
                {
                    RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    return $"El medicamento {medicamento.NombreComercial} ha sido agregado correctamente";
                }
                else
                {
                    return $"No se pudo agregar el medicamento {medicamento.NombreComercial}. ya existe.";
                }
            }
            catch (Exception)
            {
                return "Ocurrio un error desconocido";
            }
        }

        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    RepositorioMedicamentos.Instancia.EliminarMedicamento(medicamento);
                    return $"El medicamento {medicamento.NombreComercial} ha sido eliminado correctamente";
                }
                else
                {
                    return $"No se pudo eliminar el medicamento {medicamento.NombreComercial}, no existe.";
                }
            }
            catch (Exception)
            {
                return "Ocurrio un error desconocido";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentoEncontrado = RepositorioMedicamentos.Instancia.ListarMedicamentos().FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    return $"El medicamento {medicamento.NombreComercial} ha sido modificado correctamente";
                }
                else
                {
                    return $"No se pudo modificar el medicamento {medicamento.NombreComercial}. no existe.";
                }
            }
            catch (Exception)
            {
                return "Ocurrio un error desconocido";
            }
        }
    }
}
