using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento

    {
        public string nombreComercial { get; set; }
        public byte esVentaLibre {get; set;}
        public decimal previoVenta { get; set; }
        public int stock { get; set; }
        public int stockMinimo { get; set; }
        public Monodroga monodroga { get; set; }
        public List<Drogueria> drogueria { get; set; }
    }
}
