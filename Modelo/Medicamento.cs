using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private string nombrecomercial;
        private decimal precioventa;
        private int stockminimo;
        private int stockactual;
        private Monodroga monodrogaasociada;
        private List<Drogueria> listadroguerias;
        private bool esventalibre;
        public Medicamento ()
        {
            Listadroguerias = new List<Drogueria>();
        }

        public string Nombrecomercial { get => nombrecomercial; set => nombrecomercial = value; }
 
        public int Stockactual { get => stockactual; set => stockactual = value; }
        public Monodroga Monodrogaasociada { get => monodrogaasociada; set => monodrogaasociada = value; }
        public List<Drogueria> Listadroguerias { get => listadroguerias; set => listadroguerias = value; }
        public bool Esventalibre { get => esventalibre; set => esventalibre = value; }
        public int Stockminimo { get => stockminimo; set => stockminimo = value; }
        public decimal Precioventa { get => precioventa; set => precioventa = value; }
    }
}
