using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
namespace Parcial1
{
    public partial class FormMedicamentoAB : Form
    {
        private Medicamento medicamento;
        private bool modificar = false;
        List<Medicamento> medicamentos;
        public FormMedicamentoAB()
        {
            InitializeComponent();
            medicamento = new Medicamento();

        }
       /* private bool ValidarCampos()
        {
            //Valido campos

        }*/
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
            private void FormAB_Load(object sender, EventArgs e)
        {

        }
    }
}
