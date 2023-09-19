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
    public partial class formMedicamento : Form
    {
        public formMedicamento()
        {
            InitializeComponent();
            comboBox1.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var medicamento = new Medicamento();
            try
            {
                medicamento.Nombre_comercial = txtnombre.Text;
                medicamento.Es_venta_libre = chventalibre.Checked;
                medicamento.Stock = int.Parse(txtstock.Text);
                medicamento.Stock_Minimo = int.Parse(txtstockminimo.Text);
                medicamento.Precio_venta = decimal.Parse(txtprecio.Text);
                medicamento.Monodroga = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == comboBox1.Text);

                var msj = ControladoraMedicamentos.Instancia.AgregarMedicamento(medicamento);
                MessageBox.Show(msj, "atencian");
                this.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
