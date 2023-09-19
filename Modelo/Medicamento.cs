using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        private string nombreComercial;
        private bool ventaLibre;
        private decimal precioVenta;
        private int stock;
        private int stockMinimo;
        private Monodroga monodrogaMedicamento;
        private List<Drogueria> listaDroguerias;

        public string NombreComercial { get => nombreComercial; set => nombreComercial = value; }
        public bool VentaLibre { get => ventaLibre; set => ventaLibre = value; }
        public decimal PrecioVenta { get => precioVenta; set => precioVenta = value; }
        public int Stock { get => stock; set => stock = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public Monodroga MonodrogaMedicamento { get => monodrogaMedicamento; set => monodrogaMedicamento = value; }
        public List<Drogueria> ListaDroguerias { get => listaDroguerias; set => listaDroguerias = value; }

        public Medicamento()
        {
            ListaDroguerias = new List<Drogueria>();
        }

        // Metodo para agregar una drogueria a la lista.
        public string AgregarDrogueria(Drogueria drogueria)
        {
            var buscoDrogueria = ListaDroguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (buscoDrogueria == null)
            {
                listaDroguerias.Add(drogueria);
                return "Drogueria agregada al medicamento con exito";
            }
            else return "La drogueria ya se encuentra asignada al medicamento";
        }

        // Metodo para eliminar una drogueria de la lista.
        public string EliminarDrogueria(Drogueria drogueria)
        {
            var buscoDrogueria = ListaDroguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
            if (buscoDrogueria != null)
            {
                listaDroguerias.Remove(drogueria);
                return "Drogueria eliminada del medicamento con exito";
            }
            else return "La drogueria no se encuentra";
        }
    }
}