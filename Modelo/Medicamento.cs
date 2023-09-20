using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private List<Drogueria> listadoDrogueria;
        public Medicamento()
        {
            listadoDrogueria = new List<Drogueria>();
        }

        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        
    }
}
