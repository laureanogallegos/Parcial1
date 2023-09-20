using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private string nombre;
        private int stock, stockMinimo;
        private decimal precio;
        private Monodroga monodroga;
        private List<Drogueria> drogueriaList;
        private bool ventaLibre;

        public Medicamento()
        {
            drogueriaList = new List<Drogueria>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Stock { get => stock; set => stock = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public Monodroga Monodroga { get => monodroga; set => monodroga = value; }
        public bool VentaLibre { get => ventaLibre; set =>  ventaLibre = value; }

        [Browsable(false)]
        public List<Drogueria> DrogueriaList { get => drogueriaList; set => drogueriaList = value;}
    }
}
