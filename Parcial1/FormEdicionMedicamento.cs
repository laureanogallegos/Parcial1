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
    public partial class FormEdicionMedicamento : Form
    {
        private bool editandoMedExistente = false;
        private Medicamento medicamento;
        public FormEdicionMedicamento(Medicamento? medicamento = null)
        {
            editandoMedExistente = medicamento != null;
            this.medicamento = medicamento;
            InitializeComponent();
        }

        private void FormEdicionMedicamento_Load(object sender, EventArgs e)
        {
            if (editandoMedExistente)
            {
                txtNombreComercial.Enabled = false;
            }
            else
            {
                medicamento = new Medicamento();
                medicamento.Droguerias = new List<Drogueria>();
            }

            foreach (Monodroga monodroga in RepositorioMonodrogas.Instancia.Monodrogas)
            {
                cbMonodroga.Items.Add(monodroga);
                if( editandoMedExistente
                    && medicamento.Monodroga!=null
                    && medicamento.Monodroga.Nombre==monodroga.Nombre)
                {
                    cbMonodroga.SelectedItem = monodroga;
                }
            }
            cbMonodroga.DisplayMember = "Nombre";
            ActualizarGrillaDroguerias();
        }

        private void ActualizarGrillaDroguerias()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = medicamento.Droguerias;
        }

        private void btnAgregarDrogueria_Click(object sender, EventArgs e)
        {
            // TODO form seleccionar droguería
            ActualizarGrillaDroguerias();
        }

        private void btnEliminarDrogueria_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.CurrentRow == null || dgvDroguerias.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione una droguería primero!");
                return;
            }
            Drogueria drogueria = (Drogueria)dgvDroguerias.CurrentRow.DataBoundItem;
            medicamento.Droguerias.Remove(drogueria);
            ActualizarGrillaDroguerias();

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string? error = null;
            if (!editandoMedExistente) medicamento.NombreComercial = txtNombreComercial.Text;
            medicamento.EsVentaLibre = cbEsVentaLibre.Checked;
            medicamento.PrecioVenta = numPrecioVenta.Value;
            medicamento.Stock = ((int)numStock.Value);
            medicamento.StockMinimo = ((int)numStock.Value);
            medicamento.Monodroga = (Monodroga) cbMonodroga.SelectedItem;
            if (editandoMedExistente)
            {
                error = ControladoraMedicamentos.Instance.ModificarMedicamento(medicamento);
            }
            else
            {
                error = ControladoraMedicamentos.Instance.CrearMedicamento(medicamento);
            }
            if (error != null)
            {
                MessageBox.Show(error);
            }
            else
            {
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
