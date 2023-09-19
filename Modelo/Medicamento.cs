using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool EsVentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga Monodroga { get; set; }
        private List<Drogueria> droguerias;
        public Medicamento()
        {
            droguerias = new List<Drogueria>();
        }
        public IReadOnlyCollection<Drogueria> Droguerias
        {
            get => droguerias.AsReadOnly();
        }
        public string AgregarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada == null)
            {
                droguerias.Add(drogueria);
                return "Drogueria agregada correctamente";
            }
            else return "Drogueria ya existente en la lista"; // requerimiento 2 : valido que a ese medicamento no se le pueda asignar la misma drogueria mas de una vez
        }
        public string QuitarDrogueria(Drogueria drogueria)
        {
            var drogueriaEncontrada = droguerias.FirstOrDefault(d => d.Cuit == drogueria.Cuit);
            if (drogueriaEncontrada != null)
            {
                droguerias.Remove(drogueria);
                return "Drogueria quitada correctamente";
            }
            else return "Drogueria no existente";
        }

    }
}
