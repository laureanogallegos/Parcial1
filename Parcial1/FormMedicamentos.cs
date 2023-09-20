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
            ActualizarGrilla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formMed = new FormMedicamento();
            formMed.ShowDialog();
        }
        public void ActualizarGrilla()
        {
            dgvMedicamentos.DataSource = null;
            dgvMedicamentos.DataSource = RepositorioMedicamentos.Instancia.ListarMedicamentos();
        }
    }
}
