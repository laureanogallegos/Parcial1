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
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }    
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        public List<Drogueria> droguerias;

        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }


        public ReadOnlyCollection<Drogueria> ListarDrogerias()
        {
            return droguerias.AsReadOnly();
        }

        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = ListarDrogerias().FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return $"{drogueria.RazonSocial} ha sido agregado correctamente";
            }
            return $"{drogueria.RazonSocial} ya existente";
        }

    }
}
