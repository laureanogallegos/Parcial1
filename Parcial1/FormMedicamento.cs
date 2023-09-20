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
    public partial class FormMedicamento : Form
    {
        Medicamento? medicamento;
        ControladoraMedicamentos control;
        FormInicial formInicial;
        bool modificando;

        public FormMedicamento(FormInicial formInicial, Medicamento? medicamento = null)
        {
            modificando = (medicamento != null);
            this.medicamento = medicamento;
            control = new ControladoraMedicamentos();
            this.formInicial = formInicial;
            InitializeComponent();
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            if (medicamento == null)
            {
                medicamento = new Medicamento();
            }
            else
            {
                tboxNombre.Text = medicamento.NombreComercial;
                tboxNombre.Enabled = false;
            }
            ActualizarGrillas();
            cboxMonodroga.DataSource = control.RecuperarMonodrogas();
            cboxMonodroga.DisplayMember = "Nombre";
        }

        private void buttonAgregarDrogueria1_Click(object sender, EventArgs e)
        {
            if (dgvTodasLasDroguerias.CurrentRow == null)
            {
                return;
            }
            Drogueria drogueria = (Drogueria)dgvTodasLasDroguerias.CurrentRow.DataBoundItem;
            if (drogueria != null)
            {
                if (medicamento.Droguerias.Contains(drogueria))
                {
                    return;
                }
                medicamento.Droguerias.Add(drogueria);
            }
            ActualizarGrillas();
        }

        private void ActualizarGrillas()
        {
            dgvTodasLasDroguerias.DataSource = null;
            dgvDrogueriasDelMedicamento.DataSource = null;
            dgvTodasLasDroguerias.DataSource = control.RecuperarDroguerias();
            dgvDrogueriasDelMedicamento.DataSource = medicamento.Droguerias;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            medicamento.NombreComercial = tboxNombre.Text;
            medicamento.VentaLibre = checkBox1.Checked;
            medicamento.PrecioVenta = nudPrecio.Value;
            medicamento.Stock = int.Parse(nudStock.Value.ToString());
            medicamento.StockMinimo = int.Parse(nudStockMinimo.Value.ToString());
            medicamento.MonodrogaMedicamento = (Monodroga)cboxMonodroga.SelectedItem;
            string msg;
            if (!modificando)
            {
                msg = control.Agregar(medicamento);
            }
            else
            {
                msg = control.Modificar(medicamento);

            }
            if(msg != "")
            {
                MessageBox.Show(msg);
            }
            else
            {
                formInicial.ActualizarGrilla();
                this.Close();
            }
        }
    }
}
