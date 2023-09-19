using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private List<Drogueria> droguerias;

        public Medicamento()
        {
            Droguerias = new List<Drogueria>();
        }

        public string Nombre_Comercial { get; set; }
        public bool Es_Venta_Libre { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Stock { get; set; }
        public int Stock_Minimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public List<Drogueria> Droguerias { get => droguerias; set => droguerias = value; }
    }
}
