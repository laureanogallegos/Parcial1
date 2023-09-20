using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    internal class ControladoraMedicamentos
    {
        private ControladoraMedicamentos() { }
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

        public string AgregarMedicamento (Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x=> x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                    var ok = 
                }
            }
            catch
            {

            }
        }
    }
}
