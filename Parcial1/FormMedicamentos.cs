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
        }
        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = Controladora.ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var respuesta = ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamentoSeleccionado);
                MessageBox.Show(respuesta, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para eliminarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Modelo.Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMedicamento(medicamentoSeleccionado);
                formMedicamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento de la grilla para modificarlo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarGrilla();
        }

    }
}
