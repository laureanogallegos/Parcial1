using System.Collections.ObjectModel;
using System;
using Modelo;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instancia;

        private ControladoraMedicamentos() { }

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


        public ReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
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
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} ya existe.";
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
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());

                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamentoEncontrado.NombreComercial} se eliminó correctamente.";
                    }
                    else
                    {
                        return $"El medicamento {medicamentoEncontrado.NombreComercial} no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"El medicamento con el nombre {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar eliminar el medicamento.";
            }
        }

        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.Matricula);
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente";
                    }
                    else
                    {
                        return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar";
                    }
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe.";
                }
            }
            catch (Exception)
            {
                return "Error desconocido";
            }
        }
    }
}