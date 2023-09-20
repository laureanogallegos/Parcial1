namespace Modelo
{
    public class Medicamento
    {
        public string NombreComercial { get; set; }
        public bool VentaLibre{ get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public Monodroga MonodrogaMedicamento { get; set; }
        public List<Drogueria> Droguerias{ get; set; }
        public Medicamento()
        {
            Droguerias = new List<Drogueria>();
        }
    }
}
