using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga Monodroga {  get; set; }
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal Precio {  get; set; }
        public int StockActual {  get; set; }
        public int StockMinimo { get; set; }

    }
}
