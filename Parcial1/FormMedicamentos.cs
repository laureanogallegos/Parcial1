using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormMedicamentos : Form
    {
        Medicamento medicamentoSeleccionado;
        public FormMedicamentos()
        {
            medicamentoSeleccionado = new Medicamento();
            InitializeComponent();
            RellenarGrilla();
        }
        private void RellenarGrilla()
        {
            dgvMedicamento.DataSource = null;
            dgvMedicamento.DataSource = ControladoraMedicamentos.Instancia.Listar();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormMedicamento form = new FormMedicamento();
            form.ShowDialog();
            RellenarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            medicamentoSeleccionado = (Medicamento)dgvMedicamento.CurrentRow.DataBoundItem;
            FormMedicamento form = new FormMedicamento(medicamentoSeleccionado);
            form.ShowDialog();
            RellenarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvMedicamento.RowCount > 0)
            {
                medicamentoSeleccionado = (Medicamento)dgvMedicamento.CurrentRow.DataBoundItem;
                string mensaje = ControladoraMedicamentos.Instancia.Eliminar(medicamentoSeleccionado);
                MessageBox.Show(mensaje);
            }
        }

        private void btnAsignarProveedor_Click(object sender, EventArgs e)
        {

        }
    }
}