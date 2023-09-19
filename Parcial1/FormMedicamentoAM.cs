using Controladora;
using Modelo;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMedicamentoAM : Form
    {
        private Medicamento medicamento;
        private bool modificar = false;

        public FormMedicamentoAM()
        {
            InitializeComponent();
            LlenarCombos();
        }

        public FormMedicamentoAM(Medicamento medicamentoModificar)
        {
            InitializeComponent();
            medicamento = medicamentoModificar;
            modificar = true;
            LlenarCombos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    var nuevoMedicamento = new Medicamento()
                    {
                        NombreComercial = txtNombreComercial.Text,
                        EsVentaLibre = cbVentaLibre.Checked,
                        PrecioVenta = numVenta.Value,
                        Stock = (int)numStock.Value,
                        StockMinimo = (int)numStockMinimo.Value,
                        Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
                        Droguerias = lbAsignados.Items.Cast<Drogueria>().ToList()
                    };

                    var mensaje = ControladoraMedicamento.Instancia.ModificarMedicamento(nuevoMedicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var nuevoMedicamento = new Medicamento()
                    {
                        NombreComercial = txtNombreComercial.Text,
                        EsVentaLibre = cbVentaLibre.Checked,
                        PrecioVenta = numVenta.Value,
                        Stock = (int)numStock.Value,
                        StockMinimo = (int)numStockMinimo.Value,
                        Monodroga = (Monodroga)cmbMonodroga.SelectedItem,
                        Droguerias = lbAsignados.Items.Cast<Drogueria>().ToList()
                    };

                    var mensaje = ControladoraMedicamento.Instancia.AgregarMedicamento(nuevoMedicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!lbAsignados.Items.Contains(cmbDisponibles.SelectedItem))
            {
                lbAsignados.Items.Add(cmbDisponibles.SelectedItem);
            }
            else
            {
                MessageBox.Show("La droguería ya se encuentra asignada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lbAsignados.Items.Clear();
        }

        private void LlenarCombos()
        {
            cmbMonodroga.DataSource = null;
            cmbMonodroga.DataSource = ControladoraMedicamento.Instancia.RecuperarMonodrogas();

            cmbDisponibles.DataSource = null;
            cmbDisponibles.DataSource = ControladoraMedicamento.Instancia.RecuperarDroguerias();
        }

        private void FormMedicamentoAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Medicamento";
                txtNombreComercial.Enabled = false;
                txtNombreComercial.Text = medicamento.NombreComercial;
                cbVentaLibre.Checked = medicamento.EsVentaLibre;
                numVenta.Value = medicamento.PrecioVenta;
                numStock.Value = medicamento.Stock;
                numStockMinimo.Value = medicamento.StockMinimo;
                cmbMonodroga.SelectedItem = medicamento.Monodroga;
                lbAsignados.Items.AddRange(medicamento.Droguerias.ToArray());
            }
            else
            {
                lblAgregaroModificar.Text = "Agregar Medicamento";
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar un nombre comercial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numVenta.Value == 0)
            {
                MessageBox.Show("Debe ingresar un valor de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
