using Controladora;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarGrilla();
        }

        void ActualizarGrilla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void brnagregar_Click(object sender, EventArgs e)
        {
            var form = new formMedicamento();
            form.ShowDialog();
            ActualizarGrilla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                var medicamento = (Modelo.Medicamento) dataGridView1.CurrentRow.DataBoundItem;
                var msj = Controladora.ControladoraMedicamentos.Instancia.EliminarMedicamento(medicamento);
                MessageBox.Show(msj, "atencion");
                ActualizarGrilla();
            }

        }
    }
}