using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool EsVentaLibre { get; set; }

        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public int StockMinimo { get; set; }

        public Monodroga Monodroga { get; set; }

        public List<Drogueria> Droguerias { get; set; }
}
}
