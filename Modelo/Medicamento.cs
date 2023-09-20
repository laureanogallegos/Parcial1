using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private List<Drogueria> listaDroguerias;
        public Medicamento()
        {
            listaDroguerias = new List<Drogueria>();
        }
        public Monodroga Monodroga { get; set; }
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public List<Drogueria> ListaDroguerias { get; }
        public void AgregarDrogueria(Drogueria drogueria)
        {
            listaDroguerias.Add(drogueria);
        }
        
    }
}
