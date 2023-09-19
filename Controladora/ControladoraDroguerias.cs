using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraDroguerias
    {
        private ControladoraDroguerias() { }
        private static ControladoraDroguerias instancia;
        public static ControladoraDroguerias Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraDroguerias();
                return instancia;
            }
        }
        public ReadOnlyCollection<Modelo.Drogueria> RecuperarDrogueria()
        {
            try
            {
                return Modelo.RepositorioDroguerias.Instancia.Droguerias;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
