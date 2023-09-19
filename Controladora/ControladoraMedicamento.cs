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
                if (instancia == null)
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
                return RepositorioMedicamento.Instancia.RecuperarMedicamentos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamento.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamento.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"{medicamento.NombreComercial} se agregó correctamente";
                    }
                    else
                    {
                        return $"{medicamento.NombreComercial} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"{medicamento.NombreComercial} ya existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamento.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamento.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"{medicamento.NombreComercial} se modificó correctamente";
                    }
                    else
                    {
                        return $"{medicamento.NombreComercial} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"{medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }

        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamento.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());

                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamento.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"{medicamentoEncontrado.NombreComercial} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"{medicamentoEncontrado.NombreComercial} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"{medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido.";
            }
        }
    }

}
