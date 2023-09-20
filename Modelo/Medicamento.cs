using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private List<Drogueria> listaDroguerias;

        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }

        public Medicamento() 
        {
            listaDroguerias = new List<Drogueria>();
        }

        public ReadOnlyCollection<Drogueria> ListarDroguerias()
        {
            return listaDroguerias.AsReadOnly();
        }

        public string AgregarDroguerias(Drogueria drogueria)
        {
            var drogueriaEncontrada = ListarDroguerias().FirstOrDefault(x => x.Cuit == drogueria.Cuit );

            if(drogueriaEncontrada == null)
            {
                listaDroguerias.Add(drogueria);
                return "Se ha agregado una drogueria correctamente";
            }
            else return "La drogueria ya esta asociado a ese producto";
        }
    }
}
