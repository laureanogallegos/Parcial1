using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    internal class MedicamentoController
    {
        private MedicamentoController() { }
        private static MedicamentoController instancia;
        public static MedicamentoController Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new MedicamentoController();
                return instancia;

            }
        }

        public object RecuperarMedicamentos()
        {
            try
            {
                return Modelo.RepositorioMedicamento.Instancia.Medicamentos;
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
                var listaMedicamento = RepositorioMedicamento.Instancia.ListarMedicamentos();
                var medicamentoEncontrado = listaMedicamento.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial.ToString());
                if (medicamentoEncontrado == null)
                {
                    var resultMedicamento = RepositorioMedicamento.Instancia.AgregarMedicamento(medicamento);
                    if (resultMedicamento)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se agrego correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido agregar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} ya existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar agregar un medicamento";
            }
        }

        public string ActualizarMedicamento(Medicamento medicamento)
        {
            try
            {
                var listaMedicamento = RepositorioMedicamento.Instancia.ListarMedicamentos();
                var medicamentoEncontrado = listaMedicamento.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial.ToString());
                if (medicamentoEncontrado != null)
                {
                    var resultMedicamento = RepositorioMedicamento.Instancia.ModificarMedicamento(medicamento);
                    if (resultMedicamento)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se modifico correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido modificar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar agregar un medicamento";
            }
        }
        public string EliminarMedicamento(string nombreMedicamento)
        {
            try
            {
                var listaMedicamento = RepositorioMedicamento.Instancia.ListarMedicamentos();
                var medicamentoEncontrado = listaMedicamento.FirstOrDefault(x => x.NombreComercial == nombreMedicamento);
                if (medicamentoEncontrado != null)
                {
                    var resultMedicamento = RepositorioMedicamento.Instancia.EliminarMedicamento(nombreMedicamento);
                    if (resultMedicamento)
                    {
                        return $"El medicamento {nombreMedicamento} se elimino correctamente";
                    }
                    else return $"El medicamento {nombreMedicamento} no se ha podido eliminar";
                }
                else
                {
                    return $"El medicamento {nombreMedicamento} no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar agregar un medicamento";
            }
        }
        public string AsignarDrogueriaMedicamento(Medicamento medicamento, Drogueria drogueria)
        {
            try
            {
                var listaMedicamento = RepositorioMedicamento.Instancia.ListarMedicamentos();
                var medicamentoEncontrado = listaMedicamento.FirstOrDefault(x => (x.NombreComercial == medicamento.NombreComercial));
                if (medicamentoEncontrado != null)
                {
                    var resultMedicamento = RepositorioMedicamento.Instancia.AgregarDrogueriaMedicamento(medicamentoEncontrado.NombreComercial);
                    if (resultMedicamento)
                    {
                        return $"El medicamento {medicamento.NombreComercial} se elimino correctamente";
                    }
                    else return $"El medicamento {medicamento.NombreComercial} no se ha podido eliminar";
                }
                else
                {
                    return $"El medicamento {medicamento.NombreComercial} no existe";
                }
            }
            catch (Exception)
            {
                return "Error desconocido al intentar agregar un medicamento";
            }
        }

    }
}
