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
    public partial class formMedicamentos : Form
    {
        public formMedicamentos()
        {
            InitializeComponent();
        }


        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamento.Instancia.RecuperarMedicamentos();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new formMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count > 0)
            {
                if (dgvMedicamentos.Rows.Count > 0)
                {
                    var medicamentoseleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                    var eliminarmedicamento = Controladora.ControladoraMedicamento.Instancia.EliminarMedicamento(medicamentoseleccionado);
                    MessageBox.Show(eliminarmedicamento);
                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show("No existen medicamentos creados");
                }
            }
            else
                MessageBox.Show("No ha seleccionado ningun medicamento");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoseleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formModificar = new formMedicamento(medicamentoseleccionado);
                formModificar.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No hay medicamentos disponibles para modificar");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
