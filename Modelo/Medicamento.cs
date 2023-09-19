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
        public string Monodroga { get; set; }
        public bool VentaLibre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public List<Drogueria> Drogerias { get; set; }
    }
}
