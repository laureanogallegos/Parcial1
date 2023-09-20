namespace Controladora
{
    public class Controladora
    {


        private ControladoraMonodroga() { }
        private static ControladoraMonodroga instancia;
        public static ControladoraMonodroga Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ControladoraMonodroga();
                return instancia;
            }
        }
        public ReadOnlyCollection<Modelo.Monodroga> RecuperarCategoriasHabilitadas()
        {
            var listado = Modelo.RepositorioMonodrogas.Instancia.RepositorioMonodrogas();
            return listado.Where(x => x.Habilitado == true).ToList().AsReadOnly();
        }
        public ReadOnlyCollection<Modelo.Monodroga> Recuperar()
        {
            try
            {
                return Modelo.RepositorioMonodrogas.Instancia.Monodrogas();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AgregarDroga(Monodroga monodroga)
        {
            try
            {
                var Monodroga = RepositorioMonodrogas.Instancia.Recuperar();
                var drogaenccontrada = Monodroga.FirstOrDefault(x => x.Nombre.ToLower() == monodroga.Nombre.ToLower());
                if (drogaenccontrada == null)
                {
                    var ok = RepositorioMonodrogas.Instancia.Agregar(monodroga);
                    if (ok)
                    {
                        return $"La monodroga {monodroga.Nombre} se agregó correctamente";
                    }
                    else return $"La monodroga {monodroga.Nombre} no se ha podido agregar";
                }
            }
    } } }