namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            Medicamentos medicamentos = new Medicamentos();
            medicamentos.ShowDialog();
        }

        private void btnMonodrogas_Click(object sender, EventArgs e)
        {
            Monodrogas monodrogas = new Monodrogas();
            monodrogas.ShowDialog();    
        }
    }
}