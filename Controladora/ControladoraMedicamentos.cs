using Modelo;
using System.Collections.ObjectModel;

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

        public ReadOnlyCollection<Modelo.Medicamento> Recuperar()
        {
            try
            {
                return Modelo.RepositorioMedicamentos.Instancia.Medicamentos;
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
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = (Medicamento) listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agregó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
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

        public string AgregarDrogueria(Medicamento medicamento, Drogueria p_drogueria)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = (Medicamento)listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado == null)
                {
                    var drogueria = (Drogueria)medicamentoEncontrado.Droguerias.FirstOrDefault(x => x.Cuit == p_drogueria.Cuit);
                    if(drogueria != null)
                    {
                        var ok = RepositorioMedicamentos.Instancia.AgregarDrogueria(drogueria, medicamentoEncontrado);
                        if (ok)
                        {
                            return $"La drogueria {drogueria.Cuit} se agregó correctamente";
                        }
                        else return $"La drogueria {drogueria.Cuit} no se ha podido agregar";
                    }else
                        return $"La drogueria {drogueria.Cuit} no se ha podido agregar porque ya existe en el medicamento a {medicamento.NombreComercial}";

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
        public string Modificar(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modificó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar";
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
        public string Eliminar(Medicamento medicamento)
        {
            try
            {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                    if (ok)
                    {
                        return $"El medicamnto se ha eliminado correctamente.";
                    }
                    else
                    {
                        return $"El medicamento no se ha podido eliminar.";
                    }
                }
                else
                {
                    return $"No se encontro el medicamento indicado.";
                }
            }
            catch (Exception)
            {
                return $"Error desconocido.";
            }
        }
    }
}