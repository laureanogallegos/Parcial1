using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Medicamento() 
        {
            Droguerias = new List<Drogueria>();
        }

        public string Nombre_comercial { get; set; }
        public bool Es_venta_libre { get; set; }
        public decimal Precio_venta { get; set; }
        public int Stock { get; set; }
        public int Stock_Minimo { get; set; }

        public Monodroga Monodroga { get; set; }

        public List<Drogueria> Droguerias { get; set; }
    }

}
