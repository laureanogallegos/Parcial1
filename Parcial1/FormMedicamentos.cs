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
    public partial class FormMedicamentos : Form
    {
        Medicamento medicamento;
        bool Modificacion = false;
        ControladoraMedicamentos controladora = new ControladoraMedicamentos();
        public FormMedicamentos()
        {
            medicamento = new Medicamento();
            InitializeComponent();
        }

        public FormMedicamentos(Medicamento pMedicamento)
        {
            medicamento = pMedicamento;
            Modificacion = true;
            InitializeComponent();
        }

        public void Actualizar()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = controladora.RecuperarDroguerias();
            dgvDrogueriasMedicamento.DataSource = null;
            dgvDrogueriasMedicamento.DataSource = medicamento.Droguerias;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.SelectedRows.Count == 1)
            {
                var drogueria = dgvDroguerias.CurrentRow.DataBoundItem as Drogueria;
                var drogueriaExistente = medicamento.Droguerias.FirstOrDefault(x => x.Cuit == drogueria.Cuit);

                if(drogueriaExistente != null)
                {
                    MessageBox.Show("Esa drogueria ya esta asignada al medicamento");
                    return;
                }

                medicamento.Droguerias.Add(drogueria);
                Actualizar();
            }
            else MessageBox.Show("No hay ninguna drogueria seleccionada.");
            Actualizar();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasMedicamento.SelectedRows.Count == 1)
            {
                var drogueria = dgvDrogueriasMedicamento.CurrentRow.DataBoundItem as Drogueria;

                medicamento.Droguerias.Remove(drogueria);
            }
            else MessageBox.Show("No hay ninguna drogueria seleccionada.");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modificacion)
            {
                var MedicamentoMod = new Medicamento();
                MedicamentoMod.PrecioVenta = numPrecioVenta.Value;
                MedicamentoMod.StockActual = (int)numStock.Value;
                MedicamentoMod.StockMinimo = (int)numStockMinimo.Value;
                MedicamentoMod.VentaLibre = checkVentaLibre.Checked;
                MedicamentoMod.Monodroga = (Monodroga)comboMonodroga.SelectedItem;

                controladora.Modificar(MedicamentoMod);
            }
            else
            {
                var NuevoMedicamento = new Medicamento();
                NuevoMedicamento.NombreComercial = txtNombre.Text;
                NuevoMedicamento.PrecioVenta = numPrecioVenta.Value;
                NuevoMedicamento.StockActual = (int)numStock.Value;
                NuevoMedicamento.StockMinimo = (int)numStockMinimo.Value;
                NuevoMedicamento.VentaLibre = checkVentaLibre.Checked;
                NuevoMedicamento.Monodroga = (Monodroga)comboMonodroga.SelectedItem;

                controladora.Agregar(NuevoMedicamento);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            comboMonodroga.ValueMember = "Nombre";
            comboMonodroga.DataSource = controladora.RecuperarMonodrogas();

            if (Modificacion)
            {
                txtNombre.Text = medicamento.NombreComercial;
                txtNombre.Enabled = false;
                numPrecioVenta.Value = medicamento.PrecioVenta;
                numStock.Value = medicamento.StockActual;
                numStockMinimo.Value = medicamento.StockMinimo;
                checkVentaLibre.Checked = medicamento.VentaLibre;
                comboMonodroga.SelectedItem = medicamento.Monodroga;
            }
            else
            {
                txtNombre.Enabled = true;
            }

            Actualizar();
        }
    }
}
