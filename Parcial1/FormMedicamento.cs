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
        private Medicamento medicamento;
        private bool modifica = false;
        public FormMedicamento()
        {
            InitializeComponent();
        }
        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
            modifica = true;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombreComercial.Text))
            {
                MessageBox.Show("Debe ingresar el Nombre comercial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtPrecioVenta.Text))
            {
                MessageBox.Show("Debe ingresar el Precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtStock.Text))
            {
                MessageBox.Show("Debe ingresar el stock", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.cmbDrogueria.Text))
            {
                MessageBox.Show("Debe ingresar la drogueria", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.cmbMonodroga.Text))
            {
                MessageBox.Show("Debe ingresar la monodroga", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtStockMinimo.Text))
            {
                MessageBox.Show("Debe ingresar el stock minimo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Text = "Modificar ticket";
                txtNombreComercial.Enabled = false;
                txtPrecioVenta.Text = medicamento.NOMBRE_COMERCIAL.ToString();
                txtStock.Text = medicamento.STOCK.ToString();
                txtStockMinimo.Text = medicamento.STOCK.ToString();
                cmbMonodroga.Text = medicamento.monodroga.Nombre.ToString();
                chkVentaLibre.Checked = medicamento.ES_VENTA_LIBRE;
            }
            else
            {
                this.Text = "Agregar ticket";

            }
            var drogerias = Controladora.ControladoraDroguerias.Instancia.RecuperarDrogueria();
            foreach (Drogueria drogueria in drogerias)
            {
                cmbDrogueria.Items.Add(drogueria.RazonSocial);
            }
            var Monodrogas = Controladora.ControladoraMonodrogas.Instancia.RecuperarMonodroga();
            foreach (Monodroga monodroga in Monodrogas)
            {
                cmbMonodroga.Items.Add(monodroga.Nombre);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /* if(ValidarDatos())
             {
                 if (modifica)
                 {

                 }
                 else
                 {

                 }
                 this.Close();
             }*/
        }
    }
