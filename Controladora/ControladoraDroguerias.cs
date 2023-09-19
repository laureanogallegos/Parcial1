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
                instancia ??= new ControladoraDroguerias();
                return instancia;
            }
        }
        public ReadOnlyCollection<Modelo.Drogueria> RecuperarDroguerias()
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
