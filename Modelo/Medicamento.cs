using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga Monodroga { get; set; }
        public string Nombre { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public List<Drogueria> Droguerias { get; set; }

        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                Droguerias.Add(drogueria);
                return "Drogueria agregada correctamente";
            }
            return "Drogueria ya existente";
        }
    }
}
