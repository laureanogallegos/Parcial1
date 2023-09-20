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
        public FormMedicamento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var medicamento = new Medicamento();
            medicamento.NombreComercial = txtNombre.Text;
            medicamento.VentaLibre = cboxVentaLibre.Checked;
            medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            medicamento.Stock = Convert.ToInt32(txtStock.Text);
            medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);

        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            cmbMonodroga.DataSource = null;
            cmbMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            cmbDrogueria.DataSource = null;
            cmbDrogueria.DataSource = RepositorioDroguerias.Instancia.Droguerias;
        }
    }
}
