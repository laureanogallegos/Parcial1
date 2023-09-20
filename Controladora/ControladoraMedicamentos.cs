using System.Collections.ObjectModel;
using Modelo;

namespace Controladora
{
    public class ControladoraMedicamentos
    {
        private static ControladoraMedicamentos instancia;
        public static ControladoraMedicamentos Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraMedicamentos();
                }
                return instancia;
            }
        }
        public ReadOnlyCollection<Medicamento> Listar()
        {
            return RepositorioMedicamentos.Instancia.Listar(); 
        }
        public string Agregar(Medicamento medicamento)
        {
            List<Medicamento> listaMedicamentos = RepositorioMedicamentos.Instancia.Recuperar();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            try
            {
                if(medicamentoEncontrado == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return "Medicamento agregado";
                    }
                    else
                    {
                        return "Error interno";
                    }
                }
                else
                {
                    return "El medicamento ya se encuentra en existencia";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Modificar(Medicamento medicamento)
        {
            List<Medicamento> listaMedicamentos = RepositorioMedicamentos.Instancia.Recuperar();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            try
            {
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Modificar(medicamento);
                    if (ok)
                    {
                        return "Medicamento modificado";
                    }
                    else
                    {
                        return "Error interno";
                    }
                }
                else
                {
                    return "El medicamento no se encuentra en existencia para ser modificado";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string Eliminar(Medicamento medicamento)
        {
            List<Medicamento> listaMedicamentos = RepositorioMedicamentos.Instancia.Recuperar();
            var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial.ToLower() == medicamento.NombreComercial.ToLower());
            try
            {
                if (medicamentoEncontrado != null)
                {
                    var ok = RepositorioMedicamentos.Instancia.Agregar(medicamento);
                    if (ok)
                    {
                        return "Medicamento eliminado";
                    }
                    else
                    {
                        return "Error interno";
                    }
                }
                else
                {
                    return "El medicamento no se encuentra en existencia para ser borrado";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string AsignarDrogueria(Medicamento medicamento, Drogueria drogueria)
        {
            List<Drogueria> listaDroguerias = medicamento.ListaDroguerias;
            var drogueriaEncontrada = listaDroguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            try
            {
                if (drogueriaEncontrada == null)
                {
                    var ok = RepositorioMedicamentos.Instancia.AsignarDrogueria(medicamento, drogueria);
                    if (ok)
                    {
                        return "Drogueria asociada al medicamento";
                    }
                    else
                    {
                        return "Error interno";
                    }
                }
                else
                {
                    return "La dorgueria ya se asignó al medicamento seleccionado";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return RepositorioDroguerias.Instancia.Droguerias;
        }
        public ReadOnlyCollection<Monodroga> ListarMonodrogas()
        {
            return RepositorioMonodrogas.Instancia.Monodrogas;
        }
    }
}