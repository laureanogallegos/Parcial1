using Controladora;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1
{
    public partial class FormMedicamentos : Form
    {
        public FormMedicamentos()
        {
            InitializeComponent();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instance.RecuperarMedicamentos();
        }

        private void btnAgregarMedicamento_Click(object sender, EventArgs e)
        {

            FormEdicionMedicamento form = new FormEdicionMedicamento();
            form.ShowDialog();
            ActualizarGrilla();

        }

        private void btnEditarMedicamento_Click(object sender, EventArgs e)
        {
            Medicamento? seleccionado = ObtenerMedSeleccionadoOError();
            if (seleccionado == null) return;
            FormEdicionMedicamento form = new FormEdicionMedicamento(seleccionado);
            form.ShowDialog();
            ActualizarGrilla();
        }

        private void btnEliminarMedicamento_Click(object sender, EventArgs e)
        {
            Medicamento? seleccionado = ObtenerMedSeleccionadoOError();
            if (seleccionado == null) return;
            string? error = ControladoraMedicamentos.Instance.EliminarMedicamento(seleccionado);
            if(error != null)
            {
                MessageBox.Show(error);
            }
            ActualizarGrilla();
        }


        /// <summary>
        /// Este método obtiene el medicamento seleccionado en el data grid view, 
        /// si no hay un medicamento seleccionado le muestra un error al usuario y
        /// devuelve null
        /// </summary>
        /// <returns>Medicamento seleccionado, null si no hay ninguno seleccionado</returns>
        private Medicamento? ObtenerMedSeleccionadoOError()
        {
            if (dgvMedicamentos.CurrentRow != null)
            {
                Medicamento? seleccionado = dgvMedicamentos.CurrentRow.DataBoundItem as Medicamento;
                return seleccionado;

            }
            MessageBox.Show("Debe seleccionar un medicamento primero!");
            return null;
        }
    }
}
