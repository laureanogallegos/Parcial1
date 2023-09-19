using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private static ControladoraMedicamento instancia;
        private ControladoraMedicamento() { }
        public static ControladoraMedicamento Instancia
        {
            get
            {
                if (instancia == null) instancia = new ControladoraMedicamento();
                return instancia;
            }
        }
        public string AgregarMedicamento (Medicamento medicamento)
        {
            try
            {// traigo la lista de medicamentos y reviso que no exista
                var listaMediamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos();
                var medicamentoExistente = listaMediamentos.FirstOrDefault(x => x.nombreComercial == medicamento.nombreComercial);
                
               

                if (medicamentoExistente == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    if (ok)
                    {
                        return "Medicamento agregado correctamente";
                    }
                    else return "No se pudo agregar el medicamento";
                }
                else return "El medicamento ya existe";


            }
            catch (Exception) { return "Error"; }
        }

        public string ModificarMedicamento (Medicamento medicamento)
        {
            try
            {// traigo la lista de medicamentos y reviso que no exista
                var listaMediamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos();
                var medicamentoExistente = listaMediamentos.FirstOrDefault(x => x.nombreComercial == medicamento.nombreComercial);



                if (medicamentoExistente != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    if (ok)
                    {
                        return "Medicamento agregado correctamente";
                    }
                    else return "No se pudo agregar el medicamento";
                }
                else return "El medicamento ya existe";


            }
            catch (Exception) { return "Error"; }
        }

        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {// traigo la lista de medicamentos y reviso que no exista
                var listaMediamentos = RepositorioMedicamentos.Instancia.ListarMedicamentos();
                var medicamentoExistente = listaMediamentos.FirstOrDefault(x => x.nombreComercial == medicamento.nombreComercial);



                if (medicamentoExistente != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return "Medicamento agregado correctamente";
                    }
                    else return "No se pudo agregar el medicamento";
                }
                else return "El medicamento ya existe";


            }
            catch (Exception) { return "Error"; }
        }



        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamentos.Instancia.ListarMedicamentos();
        }

    }
}
