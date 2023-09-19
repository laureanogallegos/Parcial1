using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraMonodrogas
    {
        private ControladoraMonodrogas() { }
        private static ControladoraMonodrogas instancia;
        public static ControladoraMonodrogas Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraMonodrogas();
                return instancia;
            }
        }
        public ReadOnlyCollection<Modelo.Monodroga> RecuperarMonodroga()
        {
            try
            {
                return Modelo.RepositorioMonodrogas.Instancia.Monodrogas;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
