using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormGestionarMedicamentos : Form
    {
        public FormGestionarMedicamentos()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        public void CargarDroguerias()
        {
            if (dgvMedicamentos.Rows.Count > 0)
            {
                var medicamentoSeleccionado = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var droguerias = medicamentoSeleccionado.Droguerias;

                dgvDroguerias.DataSource = null;
                dgvDroguerias.DataSource = droguerias;
            }
        }

        private void dgvMedicamentos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDroguerias();
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }
    }
}