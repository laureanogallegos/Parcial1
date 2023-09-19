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
        private bool Modificar = false;
        private Medicamento mimedicamento;
        public FormMedicamento()
        {
            InitializeComponent();
        }
        public FormMedicamento(Medicamento medicamentoamodi)
        {
            InitializeComponent();
            mimedicamento = medicamentoamodi;
            Modificar = true;
        }
        private void CargarCombos()
        {
            cmbMonoDrogas.DataSource = null;
            cmbMonoDrogas.DataSource = RepositorioMonodrogas.Instancia.Monodrogas;
            cmbMonoDrogas.Name = cmbMonoDrogas.Name;
        }
        private void FormMedicamento_Load(object sender, EventArgs e)
        {
            CargarDrogueriasDispo();
            CargarCombos();
            if (Modificar)
            {
                txtNombre.Enabled = false;
                txtNombre.Text = mimedicamento.Nombrecomercial;
                numStockMaximo.Value = mimedicamento.Stockactual;
                numStockMin.Value = mimedicamento.Stockminimo;
                checkBox1.Checked = mimedicamento.Esventalibre;
                cmbMonoDrogas.Text = mimedicamento.Monodrogaasociada.Nombre;
            }
            else
            {
                txtNombre.Enabled = true;
            }

        }
        private void CargarDrogueriasDispo()
        {
            dgvDrogueriasDisponibles.DataSource = null;
            dgvDrogueriasDisponibles.DataSource = RepositorioDroguerias.Instancia.Droguerias;

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Modificar)
            {
                var Medicamento = new Medicamento();
                Medicamento.Nombrecomercial = txtNombre.Text;
                Medicamento.Monodrogaasociada = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == cmbMonoDrogas.Text);
                Medicamento.Stockactual = (int)numStockMaximo.Value;
                Medicamento.Stockminimo = (int)numStockMin.Value;
                Medicamento.Esventalibre = checkBox1.Checked;
                if (dgvDrogueriasDisponibles.CurrentRow is not null)
                {
                    foreach (DataGridViewRow Fila in dgvDrogueriasDisponibles.SelectedRows)
                    {
                        var Drogueria = (Drogueria)Fila.DataBoundItem;
                        Medicamento.Listadroguerias.Add(Drogueria);
                    }
                }
                var mensaje = ControladoraMedicamento.Instancia.agregarMedicamentos(Medicamento);
                MessageBox.Show(mensaje);
            }
            if (Modificar)
            {
                mimedicamento.Monodrogaasociada = RepositorioMonodrogas.Instancia.Monodrogas.FirstOrDefault(x => x.Nombre == cmbMonoDrogas.Text);
                mimedicamento.Stockactual = (int)numStockMaximo.Value;
                mimedicamento.Stockminimo = (int)numStockMin.Value;
                mimedicamento.Esventalibre = checkBox1.Checked;
                mimedicamento.Listadroguerias.Clear();
                if (dgvDrogueriasDisponibles.CurrentRow is not null)
                {
                    foreach (DataGridViewRow Fila in dgvDrogueriasDisponibles.SelectedRows)
                    {
                        var Drogueria = (Drogueria)Fila.DataBoundItem;
                        mimedicamento.Listadroguerias.Add(Drogueria);
                    }
                }
                var mensaje = ControladoraMedicamento.Instancia.modificarmedicamento(mimedicamento);
                MessageBox.Show(mensaje);
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
