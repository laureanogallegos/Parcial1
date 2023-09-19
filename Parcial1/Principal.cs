namespace Parcial1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnDrogueria_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formDrogueria = new FormDroguerias();
            formDrogueria.ShowDialog();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formMedcamentos = new FormMedicamentos();
            formMedcamentos.ShowDialog();
        }

        private void BtnMonodrogas_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formMonodrogas = new FormMonodrogas();
            formMonodrogas.ShowDialog();
        }
    }
}