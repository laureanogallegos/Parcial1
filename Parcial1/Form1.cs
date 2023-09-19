using Controladora;
using Modelo;

namespace Parcial1
{
    public partial class Form1 : Form
    {
        private bool eliminar = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Actualizargrilla()
        {
            dgvmedicamentos.DataSource = null;
            dgvmedicamentos.DataSource = ControladoraMedicamento.Instancia.RecuperarMedicamentos();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizargrilla();
        }
        private void Actualizargrilladedroguerias(Medicamento medica)
        {
            dgvdrogueriasasociadas.DataSource = null;
            dgvdrogueriasasociadas.DataSource = medica.Listadroguerias;
        }
        private void dgvmedicamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //el error es que lo elimina y lo sigue seleccionando al objeto ya eliminado
        private void dgvmedicamentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvmedicamentos.SelectedRows is not null && eliminar == false)
            {
                var medicamento = (Medicamento)dgvmedicamentos.CurrentRow.DataBoundItem;
                Actualizargrilladedroguerias(medicamento);
            }
           
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            eliminar = false;
            FormMedicamento form = new FormMedicamento();
            form.ShowDialog();
            Actualizargrilla();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            eliminar = false;
            if (dgvmedicamentos.CurrentRow is not null)
            {
                var Medicamentoamodi = (Medicamento)dgvmedicamentos.CurrentRow.DataBoundItem;
                FormMedicamento formulario = new FormMedicamento(Medicamentoamodi);
                formulario.ShowDialog();

            }
            Actualizargrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvmedicamentos.CurrentRow is not null)
            {
                var Medicamentoaeliminar = (Medicamento)dgvmedicamentos.CurrentRow.DataBoundItem;
                var mensaje = ControladoraMedicamento.Instancia.EliminarMedicamento(Medicamentoaeliminar);
                MessageBox.Show(mensaje);
                Actualizargrilla();
                eliminar = true;
            }
        }
    }
}