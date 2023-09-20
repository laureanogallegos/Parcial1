using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormMedicamento : Form
    {
        public FormMedicamento()
        {
            InitializeComponent();
            btnModificar.Hide();
            RellenarCBMonodrogas();

        }
        //Constructor recargado para las operaciones de modificar
        public FormMedicamento(Medicamento medicamento)
        {
            txtNombre.Enabled = false;
            btnAgregar.Hide();
            RellenarCBMonodrogas();
        }
        private void RellenarCBMonodrogas()
        {
            cbMonodroga.DataSource = null;
            cbMonodroga.DisplayMember = "Nombre";
            cbMonodroga.DataSource = ControladoraMedicamentos.Instancia.ListarMonodrogas();
        }
        private bool ValidarDatos()
        {
            var ok = true;
            if(txtNombre.Text == "")
            {
                return false;
            }
            var esPrecio = decimal.TryParse(txtPrecio.Text, out decimal precio);
            if (txtPrecio.Text == "" && esPrecio)
            {
                return false;
            }
            var esStock = int.TryParse(txtStock.Text, out int stock);
            if (txtStock.Text == "" && esStock)
            {
                return false;
            }
            var esStockMin = int.TryParse(txtStock.Text, out int stockMin);
            if (txtStockMin.Text == "" && esStockMin)
            {
                return false;
            }
            return ok;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var medicamento = new Medicamento();
                medicamento.NombreComercial = txtNombre.Text;
                medicamento.Precio = decimal.Parse(txtPrecio.Text);
                medicamento.Stock = int.Parse(txtStock.Text);
                medicamento.StockMin = int.Parse(txtStockMin.Text);
                medicamento.Monodroga = (Monodroga)cbMonodroga.SelectedValue;
                string mensaje = ControladoraMedicamentos.Instancia.Agregar(medicamento);
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Ingreso de datos erroneos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var medicamento = new Medicamento();
                medicamento.Precio = decimal.Parse(txtPrecio.Text);
                medicamento.Stock = int.Parse(txtStock.Text);
                medicamento.StockMin = int.Parse(txtStockMin.Text);
                medicamento.Monodroga = (Monodroga)cbMonodroga.SelectedValue;
                string mensaje = ControladoraMedicamentos.Instancia.Modificar(medicamento);
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Ingreso de datos erroneos");
            }
        }
    }
}
