using Modelo;
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
    public partial class FormMedicamento : Form
    {
        private Medicamento medicamento;
        private bool modificar = false;

        public FormMedicamento()
        {
            InitializeComponent();
        }

        public FormMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            medicamento = medicamentoModificar;
            modificar = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos)
            {
                if (modificar)
                {
                    var medicamento = new Medicamento()
                    {
                        NombreComercial = tbNombre.Text,
                        EsVentaLibre = ,
                        PrecioVenta = ,
                        Stock = ,
                        StockMinimo = ,
                        Monodroga = ,
                    };

                    string mensaje = ControladoraMedicamentos.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var medicamento = new Medicamento()
                    {
                        NombreComercial = tbNombre.Text,
                        EsVentaLibre = ,
                        PrecioVenta = ,
                        Stock = ,
                        StockMinimo = ,
                        Monodroga = ,
                    };

                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(tbNombre.Text))
            {
                MessageBox.Show("Debe ingresar un Nombre Comercial", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(tbPrecio.Text))
            {
                MessageBox.Show("Debe ingresar un precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbMonodroga.SelectedItem == null)
            {
                MessageBox.Show("Debe ingresar una Monodroga", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            
        }
    }
}
