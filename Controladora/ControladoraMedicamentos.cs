using Microsoft.Extensions.Configuration;
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
                { instancia = new ControladoraMedicamentos(); }
                return instancia;
            }
        }

        public ReadOnlyCollection <Medicamento> RecuperarMedicamentos()
        {
       //     try
            {
                return RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
      /*      catch (Exception)
            {

                throw;
            }*/
        }

        public string AgregarMedicamento(Medicamento medicamento)
        {
            var medicamentoex = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().FirstOrDefault(x=>x.Nombre_comercial == medicamento.Nombre_comercial);    
            if(medicamentoex== null)
            {
                var ok =RepositorioMedicamentos.Instancia.Agregar(medicamento);
                if(ok)
                { return "Medicamento agregado exitosamente"; }
                else { return"El medicamento no pudo ser agregado"; }
            }
            else { return "El medicamento ya existe"; }
        }


        public string Agregardrogueria(Medicamento medicamento)
        {
            foreach (var item in medicamento.Droguerias)
            {
                if (item.Cuit == medicamento.Droguerias[0].Cuit)
                { return "la drogueria ya esta asociada al medicamento"; }
            }
            var medicamentoex = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombre_comercial == medicamento.Nombre_comercial);
            if (medicamentoex != null)
            {
                var ok = RepositorioMedicamentos.Instancia.Agregardrogueria(medicamento);
                if (ok)
                { return "la drogueria fue agregada exitosamente"; }
                else { return "pudo ser agregada"; }
            }
            else { return "El medicamento no existe"; }
        }


        public string ModificarMedicamento(Medicamento medicamento)
        {
            var medicamentoex = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombre_comercial == medicamento.Nombre_comercial);
            if (medicamentoex != null)
            {
                var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                if (ok)
                { return "Medicamento modificado exitosamente"; }
                else { return "El medicamento no pudo ser modificado"; }
            }
            else { return "El medicamento no existe"; }
        }


        public string EliminarMedicamento(Medicamento medicamento)
        {
            var medicamentoex = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombre_comercial == medicamento.Nombre_comercial);
            if (medicamentoex != null)
            {
                var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                if (ok)
                { return "Medicamento eliminado exitosamente"; }
                else { return "El medicamento no pudo ser eliminado"; }
            }
            else { return "El medicamento no existe"; }
        }
    }
}
