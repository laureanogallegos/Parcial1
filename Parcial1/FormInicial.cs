using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class FormInicial : Form
    {
        ControladoraMedicamentos control;
        public FormInicial()
        {
            control = new ControladoraMedicamentos();
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formMedicamento = new FormMedicamento(this);
            formMedicamento.Show();
        }

        private void FormInicial_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow == null)
            {
                return;
            }
            Medicamento medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            var formMedicamento = new FormMedicamento(this, medicamento);
            formMedicamento.Show();
        }

        public void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = control.RecuperarMedicamentos();     
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow == null)
            {
                return;
            }
            Medicamento medicamento = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
            control.Eliminar(medicamento);
            ActualizarGrilla();
        }
    }
}