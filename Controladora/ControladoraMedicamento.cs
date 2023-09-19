using Modelo;

namespace Controladora
{
    public class ControladoraMedicamento
    {
        private static ControladoraMedicamento instancia;
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
        public string EliminarMedicamento (Medicamento medicamentoaeliminar)
        {
            try
            {
                var existe = RepositorioMedicamento.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombrecomercial == medicamentoaeliminar.Nombrecomercial);
                if(existe is not null)
                {
                    var ok = RepositorioMedicamento.Instancia.EliminarMedicamento(medicamentoaeliminar);
                    if (ok)
                    {
                        return "El medicamento se ha eliminado correctamente";
                    }
                    else
                    {
                        return "El medicamento no se ha podido eliminar";
                    }

                }
                else
                {
                    return "Lo sentimo el medicamento no existe!";
                }

            }
            catch (Exception ex)
            {
                return "erorr desconocido!";
            }

        }
        public string modificarmedicamento (Medicamento medicamentoamodi)
        {
            try
            {
                var existe = RepositorioMedicamento.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombrecomercial == medicamentoamodi.Nombrecomercial);
                if(existe is not null)
                {
                    var ok = RepositorioMedicamento.Instancia.ModificarMedicamentos(medicamentoamodi);
                    if(ok)
                    {
                        return "El medicamento se ha modificado correctamente!";
                    }
                    else
                    {
                        return "El medicamento no se ha podido modificar";
                    }
                }
                else
                {
                    return "El medicamento no existe";
                }
            }
            catch (Exception ex)
            {
                return "erorr desconocido!";
            }
        }
        public IReadOnlyCollection<Medicamento> RecuperarMedicamentos()
        {
            return RepositorioMedicamento.Instancia.RecuperarMedicamentos();
        }
        public string agregarMedicamentos(Medicamento medicamento)
        {
            try
            {
                var existe = RepositorioMedicamento.Instancia.RecuperarMedicamentos().FirstOrDefault(x => x.Nombrecomercial == medicamento.Nombrecomercial);
                if (existe is null)
                {
                    var ok = RepositorioMedicamento.Instancia.agregarMedicamentos(medicamento);
                    if (ok)
                    {
                        return "el medicamento se ha agregado correctamente!";
                    }
                    else
                    {
                        return "El Medicamento ha agregado pero sin droguerias!";
                    }
                }
                else
                {
                    return "El medicamento que desea agregar ya existe!";
                }
            }
            catch (Exception ex)
            {
                return "erorr desconocido!";
            }

        }
    }
}
