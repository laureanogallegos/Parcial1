using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        private bool actualiza;
        private Medicamento mediamento;
        public FormMedicamento()
        {
            InitializeComponent();
        }

        public FormMedicamento(Medicamento medicamento)
        {
            this.mediamento = medicamento;

            txtNombre.Text = mediamento.NombreComercial.ToString();
            txtPrecio.Text = mediamento.PrecioVenta.ToString();
            txtStock.Text = mediamento.StockActual.ToString();
            txtStockMinimo.Text = mediamento.StockMinimo.ToString();
            InitializeComponent();
        }


    }
}
