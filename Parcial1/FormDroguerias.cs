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
    public partial class FormDroguerias : Form
    {
        public FormDroguerias()
        {
            InitializeComponent();
        }
        private void ActualizarGrilla()
        {
            dgvDroguerias.DataSource = null;
            dgvDroguerias.DataSource = ControladoraDroguerias.Instancia.RecuperarDrogueria();
        }
        private void FormDroguerias_Load(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
