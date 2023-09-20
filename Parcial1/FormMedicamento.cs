using Controladora;
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
        private bool modifica = false;
        private Medicamento medicamento;

        public FormMedicamento()
        {
            InitializeComponent();
            this.medicamento = new Medicamento();
            ActualizarGrilla();
        }

        public FormMedicamento(Medicamento medicamentoSeleccionado)
        {
            InitializeComponent();
            modifica = true;
            this.medicamento = medicamentoSeleccionado;
            ActualizarGrilla();
        }
        public void ActualizarGrilla()
        {
            dgvDrogueriasAsociadas.DataSource = null;
            dgvDrogueriasAsociadas.DataSource = this.medicamento.ListarDroguerias();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            medicamento.NombreComercial = txtNombreComercial.Text;
            medicamento.VentaLibre = checkVentaLibre.Checked;
            medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
            medicamento.Stock = Convert.ToInt32(txtStock.Text);
            medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
            medicamento.Monodroga = (Monodroga)cmbMonodroga.SelectedItem;

            if (ValidarDatos())
            {
                if (modifica == true)
                {
                    var mensaje = ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje);
                }
                else
                {
                    var mensaje = ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    MessageBox.Show(mensaje);
                }
                ActualizarGrilla();
                this.Close();
            }
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre comercial");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el precio de venta");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("Debe ingresar el stock");
                return false;
            }
            if (string.IsNullOrEmpty(txtStockMinimo.Text))
            {
                MessageBox.Show("Debe ingresar el stock minimo");
                return false;
            }
            if (string.IsNullOrEmpty(cmbMonodroga.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de la monodroga");
                return false;
            }
            return true;
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            if (modifica == true)
            {
                txtNombreComercial.Text = medicamento.NombreComercial;
                txtNombreComercial.Enabled = false;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.Stock.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                cmbDrogueria.SelectedItem = medicamento.ListarDroguerias();

            }

            cmbDrogueria.DataSource = null;
            cmbDrogueria.DataSource = RepositorioDroguerias.Instancia.Droguerias;
            cmbDrogueria.DisplayMember = "Cuit";

            cmbMonodroga.DataSource = null;
            cmbMonodroga.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            cmbMonodroga.DisplayMember = "Nombre";
        }

        private void btnAsignarDrogueria_Click(object sender, EventArgs e)
        {
            var drogueriaSeleccionada = (Drogueria)cmbDrogueria.SelectedItem;
            var mensaje = this.medicamento.AgregarDroguerias(drogueriaSeleccionada);

            ActualizarGrilla();
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
