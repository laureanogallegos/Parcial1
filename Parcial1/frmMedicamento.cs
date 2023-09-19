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
    public partial class frmMedicamento : Form
    {
        private Medicamento medicamento;
        private bool modificar = false;
        private List<Monodroga> listaMonodroga;

        public frmMedicamento()
        {
            InitializeComponent();
        }

        public frmMedicamento(Medicamento medicamentoModif)
        {
            medicamentoModif = medicamento;
            modificar = true;
            listaMonodroga = new List<Monodroga>();
        }

        private bool ValidarDatos()
        {
            if (txtNombreComercial.Text != "")
            {
                return false;
            }
            return true;
        }
        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                txtNombreComercial.Text = medicamento.NombreComercial;
                checkboxVentaLibre.Checked = medicamento.VentaLibre;
                numPrecioVenta.Value = medicamento.PrecioVenta;
                numStock.Value = medicamento.Stock;
                numStockMinimo.Value = medicamento.StockMinimo;
                //cmbMonodroga = medicamento.monodroga.Nombre;

                var mensaje = ControladoraMedicamento.Instancia.Modificar(medicamento);
            }
            else
            {
                Medicamento nuevoMedicamento = new Medicamento();

                txtNombreComercial.Text = nuevoMedicamento.NombreComercial;
                checkboxVentaLibre.Checked = nuevoMedicamento.VentaLibre;
                numPrecioVenta.Value = nuevoMedicamento.PrecioVenta;
                numStock.Value = nuevoMedicamento.Stock;
                numStockMinimo.Value = nuevoMedicamento.StockMinimo;

                var mensaje = ControladoraMedicamento.Instancia.Agregar(nuevoMedicamento);

            }
        }
    }
}
