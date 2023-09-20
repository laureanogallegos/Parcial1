using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga Monodroga { get; set; }
        public string NombreMonodroga { get { return Monodroga.Nombre; } }
        public string NombreComercial { get; set; }

        public decimal PrecioVenta { get; set; }
        public bool VentaLibre { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public List<Drogueria> Droguerias { get; set; }

        public Medicamento()
        {
            Droguerias = new List<Drogueria>();
        }
    }
}
