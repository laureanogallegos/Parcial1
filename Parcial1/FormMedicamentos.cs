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

        //////////////////////////////// Agregar ////////////////////////////////
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var abroMedicamento = new FormMedicamento();
            abroMedicamento.ShowDialog();
            ActualizarGrilla();
        }

        //////////////////////////////// Eliminar ////////////////////////////////
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow != null) 
            {
                var MedicamentoSelect = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show("¿Confima que desea eliminar el medicamento: " + MedicamentoSelect.NombreComercial + " de la base de datos?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraMedicamentos.Instancia.EliminarMedicamento(MedicamentoSelect);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento para poder utilizar esta funcion");
            }
        }

        //////////////////////////////// Modificar ////////////////////////////////
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow != null)
            {
                var MedicamentoSelect = (Medicamento)dgvMedicamentos.CurrentRow.DataBoundItem;
                var abroMedicamento = new FormMedicamento(MedicamentoSelect); // Se lo paso al otro form.
                abroMedicamento.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un medicamento para poder utilizar esta funcion");
            }
        }

        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = ControladoraMedicamentos.Instancia.RecuperarMedicamentos();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMedicamentos_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
