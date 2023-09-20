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
    public partial class FormSeleccionDrogueria : Form
    {
        private Medicamento medicamento;
        public FormSeleccionDrogueria(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = medicamento;
        }

        private void FormSeleccionDrogueria_Load(object sender, EventArgs e)
        {
            dgvDroguerias.DataSource = null;
            List<Drogueria> droguerias = new List<Drogueria>(RepositorioDroguerias.Instancia.Droguerias);
            foreach (Drogueria d in medicamento.Droguerias)
            {
                droguerias.Remove(d);
            }
            dgvDroguerias.DataSource = droguerias;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvDroguerias.CurrentRow == null) return;
            if (dgvDroguerias.CurrentRow.DataBoundItem == null) return;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
