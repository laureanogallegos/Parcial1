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
                instancia ??= new ControladoraMedicamentos();
                return instancia;
            }
        }
        public ReadOnlyCollection<Modelo.Medicamento> RecuperarMedicamentos()
        {
            try
            {
                return Modelo.RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
            } catch (Exception ex)
            {
                throw;
            }
        }
        public ReadOnlyCollection<Modelo.Drogueria> RecuperarDroguerias()
        {
            try
            {
                return Modelo.RepositorioDroguerias.Instancia.Droguerias;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ReadOnlyCollection<Modelo.Monodroga> RecuperarMonodrogas()
        {
            try
            {
                return Modelo.RepositorioMonodrogas.Instancia.Monodrogas;
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
                var medicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos(); // lista medicamentos
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower()); // busco medicamento en lista de medicamentos por el nombre, ya q es unique
                if (medicamentoEncontrado == null) // requerimiento validar que no se registre medicamento ya registrado: solo si el medicamento es nulo (no existe) en la lista de medicamentos se podrá agregar 
                {
                    if (RepositorioMedicamentos.Instancia.Agregar(medicamento)== true)
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
        public string EliminarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    if (RepositorioMedicamentos.Instancia.Eliminar(medicamento) == true)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se eliminó correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar";
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
        public string ModificarMedicamento(Medicamento medicamento)
        {
            try
            {
                var medicamentos = RepositorioMedicamentos.Instancia.RecuperarMedicamentos();
                var medicamentoEncontrado = medicamentos.FirstOrDefault(m => m.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
                if (medicamentoEncontrado != null)
                {
                    if (RepositorioMedicamentos.Instancia.Modificar(medicamento))
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

    }
}