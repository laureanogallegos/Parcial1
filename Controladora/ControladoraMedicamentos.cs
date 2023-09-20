using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    if (instancia == null)
                    {
                        instancia = new ControladoraMedicamentos();
                    }
                    return instancia;
                }
            }


            public string Agregar(Medicamento medicamento)
            {
                try
                {
                    var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                    var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                    if (medicamentoEncontrado == null)
                    {
                        RepositorioMedicamentos.Instancia.Agregar(medicamento);
                        return $"Medicamento agregado.";
                    }
                    else
                    {
                        return $"No se pudo agregar el medicamento.";
                    }
                }
                catch (Exception)
                {
                    return $"Error.";
                }
            }

            public string Eliminar(Medicamento medicamento)
            {
                try
                {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                        RepositorioMedicamentos.Instancia.Eliminar(medicamento);
                        return $"Se elimino el medicamento.";
                    }
                    else
                    {
                        return $"El medicamento no existe.";
                    }
                }
                catch (Exception)
                {
                    return $"Error.";
                }
            }
            public string Modificar(Medicamento medicamento)
            {
                try
                {
                var listaMedicamentos = RepositorioMedicamentos.Instancia.Medicamentos;
                var medicamentoEncontrado = listaMedicamentos.FirstOrDefault(x => x.NombreComercial == medicamento.NombreComercial);
                if (medicamentoEncontrado == null)
                {
                        RepositorioMedicamentos.Instancia.Modificar(medicamento);
                        return $"Se modifico el medicamento.";
                    }
                    else
                    {
                        return $"No se pudo modificar el medicamento.";
                    }
                }
                catch (Exception)
                {
                    return $"Error.";
                }
            }
        }
    }
