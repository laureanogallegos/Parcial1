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
        public FormMedicamento(Medicamento? medicamento = null)
        {
            InitializeComponent();

            this.Text = (medicamento == null) ?
                "Añadir Medicamento" :
                "Modificar Medicamento";
            this.medicamento = medicamento;
            
            if (medicamento != null) llenarForm();
        }

        private void llenarForm()
        {
            txtNombre.Text = medicamento.Nombre;
            txtNombre.Enabled = false;
            numPrecio.Value = medicamento.Precio;
            numStock.Value = medicamento.Stock;
            numStockMinimo.Value = medicamento.StockMinimo;

            chkVentaLibre.Checked = medicamento.VentaLibre;

        }
        private bool Validacion()
        {
            string errores = "";
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) errores += "El nombre esta Vacio\n";
            if (txtNombre.Text.Length > 50) errores += "El nombre solo puede tener 50 chars\n";
            if (numStock.Value < numStockMinimo.Value) errores += "Ingresó menos que el minimo de stock\n";

            if (errores == "")
            {
                return true;
            }
            MessageBox.Show(errores);
            return false;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                if(medicamento == null)
                {
                    medicamento = new Medicamento();
                    medicamento.Nombre = txtNombre.Text;
                    medicamento.Stock = int.Parse(numStock.Value.ToString());
                    medicamento.VentaLibre = chkVentaLibre.Checked;
                    medicamento.StockMinimo = int.Parse(numStockMinimo.Value.ToString());
                    medicamento.Precio = numPrecio.Value;

                    ControladoraMedicamentos.Instance.AgregarMedicamentos(medicamento);
                    this.Close();
                }
                else
                {
                    medicamento.Stock = int.Parse(numStock.Value.ToString());
                    medicamento.VentaLibre = chkVentaLibre.Checked;
                    medicamento.StockMinimo = int.Parse(numStockMinimo.Value.ToString());
                    medicamento.Precio = numPrecio.Value;

                }
                ControladoraMedicamentos.Instance.AgregarMedicamentos(medicamento);
                this.Close();
            }
        }
    }
}
