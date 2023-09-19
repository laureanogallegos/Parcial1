using Controladora;
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
    public partial class Medicamentos : Form
    {
        public Medicamentos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formMedicamento formMedicamento = new formMedicamento();
            formMedicamento.ShowDialog();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicamentos.DataSource = ControladoraMedicamento.Instancia.RecuperarMedicamentos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
          /* if (dgvMedicamentos.Rows.Count > 0)
            {
                //var medicamento = ()dgvMedicamentos.CurrentRow.DataBoundItem;

                if (ControladoraMedicamento.Instancia.EliminarMedicamento(medicamento))
                {
                    var mensaje = ControladoraMedicamento.Instancia.EliminarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show("No se puede eliminar un rol asociado a un usuario, primero elimina el usuario asociado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
        }
    }

