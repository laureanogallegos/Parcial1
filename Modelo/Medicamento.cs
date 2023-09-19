﻿using System;
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
        public int PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string Monodroga { get; set; }
    }
}
