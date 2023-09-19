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
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }
        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var MedicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var respuesta = Controladora.ControladoraMedicamentos.Instancia.EliminarMedicamento(MedicamentoSeleccionado);
                MessageBox.Show(respuesta, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un medicamento para eliminarlo");
            }
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var ticketSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMedicamento(ticketSeleccionado);
                formMedicamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un ticket para modificarlo");
            }
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
