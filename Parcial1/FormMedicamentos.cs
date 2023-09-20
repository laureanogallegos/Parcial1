using Controladora;

namespace Parcial1
{
    public partial class FormMedicamentos : Form
    {
        public FormMedicamentos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            dgrMedicamentos.DataSource = null;
            dgrMedicamentos.DataSource = ControladoraMedicamentos.Instance.RecuperarMedicamentos();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            var form = new FormMedicamento();
            form.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}