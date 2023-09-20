using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormMedicamentos : Form
    {
        public FormMedicamentos()
        {
            InitializeComponent();
            ActualizarGrilla();

        }
        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.Recuperar();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btmEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Estás seguro de que deseas eliminar el medicamento  {medicamento.NombreComercial}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirmResult == DialogResult.Yes)
                {
                    var eliminar = Controladora.ControladoraMedicamentos.Instancia.Eliminar(medicamento);
                    MessageBox.Show(eliminar);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No existe medicamento");
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var formMedicamento = new FormMedicamento(medicamento);
                formMedicamento.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No existe medicamento");
            }
        }

        private void dgvMedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}