using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public string NOMBRE_COMERCIAL { get; set; }
        public bool ES_VENTA_LIBRE { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public int STOCK { get; set; }
        public int STOCK_MINIMO { get; set; }
        public Monodroga monodroga { get; set; }
    }
}
