﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Medicamento
    {
        public Monodroga monodroga { get; set; }
        public string NombreComercial { get; set; }
        public bool VentaLibre { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }

        public List<Drogueria> listaDroguerias;



    }
}
