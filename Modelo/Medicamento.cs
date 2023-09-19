using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
    
            public string Nombre { get; set; }  
            public bool Habilitado { get; set; }
            public decimal PrecioVenta { get; set; }
            public int Stock { get; set; }  
            public int StockMinimo { get; set; }
            public List<Monodroga> Monodrogas { get; set; }

        public Medicamento()
        {
            Monodrogas = new List<Monodroga>();
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
