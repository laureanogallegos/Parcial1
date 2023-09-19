namespace Modelo
{
    public class Medicamento
    {
        public Monodroga monodroga { get; set; }
        public Drogueria drogueria { get; set; }
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
    }
}
