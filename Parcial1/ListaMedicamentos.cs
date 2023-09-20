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
    public partial class ListaMedicamentos : Form
    {
        ControladoraMedicamentos controladora = new ControladoraMedicamentos();
        public ListaMedicamentos()
        {
            InitializeComponent();
        }

        public void Actualizar()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = controladora.RecuperarMedicamentos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using(FormMedicamentos form = new FormMedicamentos())
            {
                form.ShowDialog();
                Actualizar();
            }
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (FormMedicamentos form = new FormMedicamentos(Medicamento pMedicamento))
            {
                form.ShowDialog();
                Actualizar();
            }
            Actualizar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.SelectedRows.Count == 1)
            {
                var medicamento = dgvMedicamentos.CurrentRow.DataBoundItem as Medicamento;
                MessageBox.Show(controladora.Eliminar(medicamento));
            }
            else MessageBox.Show("No hay ningun medicamento seleccionado.");
        }

        private void ListaMedicamentos_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dgvMedicamentos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if(dgvDrogueriasMedicamento.SelectedRows.Count == 0)
            {
                dgvDrogueriasMedicamento.DataSource = null;
            }
            else
            {
                var medicamento = dgvDrogueriasMedicamento.CurrentRow.DataBoundItem as Medicamento;
                dgvDrogueriasMedicamento.DataSource = null;
                dgvDrogueriasMedicamento.DataSource = medicamento.Droguerias;
            }
        }
    }
}
