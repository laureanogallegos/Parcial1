using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial;
        public bool EsVentaLibre;
        public decimal PrecioVenta;
        public int Stock;
        public int StockMinimo;
        public Monodroga Monodroga;
        public List<Drogueria> Droguerias;
    }
}
