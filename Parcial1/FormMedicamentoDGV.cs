using Modelo;
using Controladora;


namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormMedicamentoAM formMedicamento = new FormMedicamentoAM();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                FormMedicamentoAM formMedicamento = new FormMedicamentoAM(medicamento);
                formMedicamento.ShowDialog();
                ActualizarGrilla();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var mensaje = ControladoraMedicamento.Instancia.EliminarMedicamento(medicamento);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarGrilla();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();

            CargarDroguerias();
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicamentos.DataSource = ControladoraMedicamento.Instancia.RecuperarMedicamentos();
        }

        private void dgvMedicamentos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDroguerias();
        }


        private void CargarDroguerias()
        {
            if (dgvMedicamentos.Rows.Count > 0 && dgvMedicamentos.SelectedRows.Count > 0)
            {
                dgvDroguerias.DataSource = null;
                dgvDroguerias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                var medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                dgvDroguerias.DataSource = medicamento.Droguerias;
            }
        }
    }
}