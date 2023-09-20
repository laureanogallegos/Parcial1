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
        private bool modifica = false;
        public FormMedicamento()
        {
            InitializeComponent();
            medicamento = new Medicamento();
            CargarComboBox();
        }
        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
            CargarComboBox();

        }
        private void ActualizarGrillaDroguerias()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = medicamento.Droguerias;
        }
        private void CargarComboBox()
        {
            var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
            foreach (Monodroga monodroga in monodrogas)
            {
                cmbMonodroga.Items.Add(monodroga.Nombre);
            }
            ActualizarComboBoxDrogueria();
        }
        private void ActualizarComboBoxDrogueria()
        {
            cmbDrogueria.Items.Clear();
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias();
            foreach (Drogueria drogueria in droguerias)
            {
                var drogueriaEncontrada = medicamento.Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
                if (drogueriaEncontrada == null)
                {
                    cmbDrogueria.Items.Add(drogueria.Cuit);
                }
            }
            cmbDrogueria.Text = "";
        }
        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre comercial", "Atención");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el precio de venta", "Atención");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtStock.Text))
            {
                MessageBox.Show("Debe ingresar el stock", "Atención");
                return false;
            }
            if (string.IsNullOrEmpty(this.txtStockMinimo.Text))
            {
                MessageBox.Show("Debe ingresar el stock minimo", "Atención");
                return false;
            }
            if (string.IsNullOrEmpty(this.cmbMonodroga.Text))
            {
                MessageBox.Show("Debe ingresar la monodroga", "Atención");
                return false;
            }
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta))
            {
                MessageBox.Show("Por favor, ingrese el precio de venta correctamente");
                return false;
            }
            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Por favor, ingrese el stock correctamente");
                return false;
            }
            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo))
            {
                MessageBox.Show("Por favor, ingrese el stock minimo correctamente");
                return false;
            }
            return true;
        }
        private void FormMedicamento_Load_1(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar medicamento";
                txtNombreComercial.Text = medicamento.NombreComercial;
                txtNombreComercial.Enabled = false;
                chkVentaLibre.Checked = medicamento.EsVentaLibre;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                txtStock.Text = medicamento.Stock.ToString();
                txtStockMinimo.Text = medicamento.StockMinimo.ToString();
                cmbMonodroga.Text = medicamento.Monodroga.Nombre.ToString();
                ActualizarGrillaDroguerias();
                CargarComboBox();
            }
            else
            {
                this.Text = "Agregar medicamento";
            }
        }
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (modifica)
                {
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.EsVentaLibre = chkVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(txtStock.Text);
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);
                    medicamento.Monodroga.Nombre = cmbMonodroga.Text;

                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    var nombreMonodroga = cmbMonodroga.Text;
                    var monodrogas = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
                    var monodrogaEncontrada = monodrogas.FirstOrDefault(m => m.Nombre.ToLower() == nombreMonodroga.ToLower());
                    medicamento.Monodroga = monodrogaEncontrada;
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.EsVentaLibre = chkVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(txtStock.Text);
                    medicamento.StockMinimo = Convert.ToInt32(txtStockMinimo.Text);

                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }
        private void btnAgregarDrogueria_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbDrogueria.Text))
            {
                MessageBox.Show("Debe ingresar un cuit de la drogueria que desea agregar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var cuitDrogueria = Convert.ToInt64(cmbDrogueria.Text);
            var drogueriaEncontrada = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias().FirstOrDefault(x => x.Cuit == cuitDrogueria);
            var respuesta = medicamento.AgregarDrogueria(drogueriaEncontrada);

            MessageBox.Show(respuesta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActualizarGrillaDroguerias();
            CargarComboBox();
        }
        private void btnEliminarDrogueria_Click_1(object sender, EventArgs e)
        {
            if (dgvDroguerias.Rows.Count > 0)
            {
                var drogueriaEncontrada = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
                var respuesta = medicamento.QuitarDrogueria(drogueriaEncontrada);
                CargarComboBox();
                MessageBox.Show(respuesta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione una drogueria para eliminarla de la lista");
            }
            ActualizarGrillaDroguerias();
        }
    }
}
