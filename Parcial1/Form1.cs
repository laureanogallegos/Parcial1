namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMedicamento_Click(object sender, EventArgs e)
        {
            FormMedicamentos formMedicamento = new FormMedicamentos();
            formMedicamento.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}