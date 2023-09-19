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
            var listado = Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
            return listado;
        }
        public string? AgregarMedicamento(Medicamento medicamento)
        {
            var lista = RecuperarMedicamentos();
            var medicamentoEncontrado = lista.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
            if(medicamentoEncontrado == null)
            {
                var ok = Modelo.RepositorioMedicamentos.Instancia.Agregar(medicamento);
                if (ok)
                {
                    return $"el medicamento {medicamento.NombreComercial} se agregó correctamente";
                }
                else return null;
            }
            else
            {
                return "Ya existe el medicamento";
            }
        }
        public string? EliminarMedicamento(Medicamento medicamento) 
        {
            var lista = RecuperarMedicamentos();
            var medicamentoEncontrado = lista.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
            if (medicamentoEncontrado != null)
            {
                var ok = Modelo.RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                if (ok)
                {
                    return $"el medicamento {medicamento.NombreComercial} se elimino correctamente";
                }
                else return null;
            }
            else
            {
                return "No existe el medicamento";
            }
        }
        public string? ModificarMedicamento(Medicamento medicamento)
        {
            var lista = RecuperarMedicamentos();
            var medicamentoEncontrado = lista.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
            if (medicamentoEncontrado != null)
            {
                var ok = Modelo.RepositorioMedicamentos.Instancia.Modificar(medicamento);
                if (ok)
                {
                    return $"el medicamento {medicamento.NombreComercial} se modifico correctamente";
                }
                else return null;
            }
            else
            {
                return "No existe el medicamento";
            }
        }
    }
}
