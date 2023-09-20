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
        private Medicamento medicamento;
        public FormMedicamento()
        {
            InitializeComponent();
            medicamento = new Medicamento();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var mensaje = "";

            //medicamento.NombreComercial = txtNombreComercial.Text;
            //medicamento.VentaLibre = checkVentaLibre.Value;
            //medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            //medicamento.Stock = Convert.ToInt32(txtStock.Text);
            //medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
            //medicamento.Monodroga = (Monodroga)cbMonodroga.SelectedItem;


            mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
