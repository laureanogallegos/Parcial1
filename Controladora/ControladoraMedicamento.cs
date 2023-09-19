using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(instancia == null)
                {
                    instancia = new ControladoraMedicamento();                 
                }
                return instancia;
            }
        }

        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public string Agregar(Medicamento medicamento)
        {
            var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().ToList();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);

            try
            {
                if(medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);

                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar.";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} ya existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error desconocido";
            }
        }


        public string Modificar(Medicamento medicamento)
        {
            var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().ToList();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);

            try
            {
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);

                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido modicar.";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error desconocido";
            }
        }


        public string Eliminar(Medicamento medicamento)
        {
            var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos().ToList();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(m => m.NombreComercial == medicamento.NombreComercial);

            try
            {
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);

                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error desconocido";
            }
        }
    }
}
