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
        public FormMedicamentos()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.ListarMedicamentos();

        }

        public void CargarDrogerias()
        {
            var medicamentoSelccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            var droguerias = medicamentoSelccionado.ListarDroguerias();

            dgvDrogueriasAsociadas.DataSource = null;
            dgvDrogueriasAsociadas.DataSource = droguerias;

        }

        private void dgvMedicamentos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDrogerias();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasAsociadas.Rows.Count > 0)
            {
                var medicamentoSelccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMedicamento(medicamentoSelccionado);
                formMedicamento.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSelccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var mensaje = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSelccionado);
                ActualizarGrilla();
                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
