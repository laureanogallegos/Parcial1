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
        private List<Drogueria> droguerias;

        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public ReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }

        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return "Drogueria agregada correctamente";
            }
            return "Drogueria ya existente";
        }

    }
}
