using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            dgvMonodrogas.DataSource = null;
            dgvMonodrogas.DataSource = Controladora.Instancia.Recuperar();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            var Form1 = new Form1();
            Form1.ShowDialog();
            ActualizarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMonodrogas.Rows.Count > 0)
            {
                var monodrogaSeleccionada = (Monodroga)dgvMonodrogas.CurrentRow.DataBoundItem;
                var formCategoria = new Form1(monodrogaSeleccionada);
                Form1.ShowDialog();
            }
            ActualizarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMonodrogas.Rows.Count > 0)
            {
                var monodroga = (Monodroga)dgvMonodrogas.CurrentRow.DataBoundItem;
                var mensaje = Controladora.Instancia.Eliminar(monodroga);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
}