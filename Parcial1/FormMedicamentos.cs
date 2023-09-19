using Modelo;
using Controladora;
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
        public FormMedicamentos()
        {
            InitializeComponent();
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregarMed_Click(object sender, EventArgs e)
        {
            FormMedicamento formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void btnSalirMed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void btnModificarMed_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                FormMedicamento formMedicamentos = new FormMedicamento(medicamento);
                formMedicamentos.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void btnEliminarMed_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var mensaje = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento);
                MessageBox.Show(mensaje, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrilla();
            }
        }
    }
}
