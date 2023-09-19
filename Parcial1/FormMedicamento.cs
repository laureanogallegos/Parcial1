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

        // Cuando agrego.
        public FormMedicamento()
        {
            InitializeComponent();

            medicamento = new Medicamento();

            // Lleno el combo de droguerias.
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDrogueriasNoAsignadas(medicamento);
            foreach (Drogueria drogueria in droguerias)
            {
                boxDrogueria.Items.Add(drogueria.Cuit);
            }

            LlenarComboBox();
        }

        // Cuando modifico.
        public FormMedicamento(Medicamento seleccionado)
        {
            InitializeComponent();
            this.medicamento = seleccionado;
            modifica = true;

            LlenarComboBox();
        }

        private void ActualizarGrilla()
        {
            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = medicamento.ListaDroguerias;
        }

        private void ActualizarBoxDroguerias()
        {
            boxDrogueria.Items.Clear();
            var droguerias = Controladora.ControladoraMedicamentos.Instancia.RecuperarDrogueriasNoAsignadas(medicamento);
            foreach (Drogueria drogueria in droguerias)
            {
                var drogueriaEncontrada = medicamento.ListaDroguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);
                if (drogueriaEncontrada == null)
                {
                    boxDrogueria.Items.Add(drogueria.Cuit);
                }
            }
            boxDrogueria.Text = "";
        }

        public void LlenarComboBox()
        {
            boxMonodrogas.DataSource = Controladora.ControladoraMedicamentos.Instancia.RecuperarMonodrogas();
            boxMonodrogas.DisplayMember = "Nombre";
            boxMonodrogas.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                if (modifica)
                {
                    medicamento.VentaLibre = checkVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(numStock.Value);
                    medicamento.StockMinimo = Convert.ToInt32(numStockMin.Value);
                    medicamento.MonodrogaMedicamento = (Monodroga)boxMonodrogas.SelectedItem;
                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    medicamento.NombreComercial = txtNombreComercial.Text;
                    medicamento.VentaLibre = checkVentaLibre.Checked;
                    medicamento.PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text);
                    medicamento.Stock = Convert.ToInt32(numStock.Value);
                    medicamento.StockMinimo = Convert.ToInt32(numStockMin.Value);
                    medicamento.MonodrogaMedicamento = (Monodroga)boxMonodrogas.SelectedItem;
                    var mensaje = Controladora.ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.boxDrogueria.Text))
            {
                MessageBox.Show("Debe asignar una drogueria", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var drogueriaCuit = Convert.ToInt64(boxDrogueria.Text);
            var drogueriaEncontrada = Controladora.ControladoraMedicamentos.Instancia.RecuperarDroguerias().FirstOrDefault(x => x.Cuit == drogueriaCuit);

            var mensaje = medicamento.AgregarDrogueria(drogueriaEncontrada);
            MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarBoxDroguerias();
            ActualizarGrilla();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasMedicamento.CurrentRow != null) // Verifico que el usuario tenga una fila seleccionada.
            {
                var DrogueriaSelect = (Drogueria)dgvDrogueriasMedicamento.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("¿Confima que desea quitar a la drogueria: " + DrogueriaSelect.Cuit + " como drogueria del medicamento?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = medicamento.EliminarDrogueria(DrogueriaSelect);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ActualizarBoxDroguerias();
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una drogueria para poder utilizar esta funcion");
            }
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar medicamento";
                txtNombreComercial.Enabled = false;
                txtNombreComercial.Text = medicamento.NombreComercial;
                checkVentaLibre.Checked = medicamento.VentaLibre;
                txtPrecioVenta.Text = medicamento.PrecioVenta.ToString();
                numStock.Value = medicamento.Stock;
                numStockMin.Value = medicamento.StockMinimo;
                boxMonodrogas.Text = medicamento.MonodrogaMedicamento.ToString();

                ActualizarGrilla();
                ActualizarBoxDroguerias();
            }
            else
            {
                this.Text = "Agregar medicamento";
            }
        }

        // Validaciones simples de campos obligatorios.
        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre comercial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            decimal precio;
            if (!decimal.TryParse(this.txtPrecioVenta.Text, out precio)) // Si llega a ingresar letras.
            {
                MessageBox.Show("Ingrese un precio valido...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.boxMonodrogas.Text))
            {
                MessageBox.Show("Debe asignarle una monodroga", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
