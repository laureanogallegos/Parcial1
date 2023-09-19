using Modelo;
using System.Security.Permissions;

namespace Parcial1
{
    public partial class formMedicamento : Form
    {
        private Medicamento medicamento;
        private bool modificar_medicamento = false;
        public formMedicamento()
        {
            InitializeComponent();
            this.medicamento = new Medicamento();
            cbMonodroga.DataSource = null;
            cbMonodroga.DataSource = RepositorioMonodrogas.Instancia.RecuperarMonodrogas();
            ActualizarGrilla();

            dgvDrogueriasDisponibles.DataSource = null;
            dgvDrogueriasDisponibles.DataSource = RepositorioDroguerias.Instancia.RecuperarDroguerias();
        }


        public formMedicamento(Medicamento medicamento)
        {
            InitializeComponent();
            this.medicamento = new Medicamento();
            modificar_medicamento = true;
            cbMonodroga.DataSource = null;
            cbMonodroga.DataSource = RepositorioMonodrogas.Instancia.RecuperarMonodrogas();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvDrogueriasExistentes.DataSource = null;
            dgvDrogueriasExistentes.DataSource = medicamento.Droguerias;

        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombre_Comercial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void formMedicamento_Load(object sender, EventArgs e)
        {
            if (modificar_medicamento)
            {
                this.Text = "Modificar Medicamento";
                txtNombre_Comercial.Enabled = false;
                txtNombre_Comercial.Text = medicamento.Nombre_Comercial;
                txtEs_Venta_Libre.Text = medicamento.Es_Venta_Libre.ToString();
                txtPrecio_Venta.Text = medicamento.Precio_Venta.ToString();
                txtStock.Text = medicamento.Stock.ToString();
                txtStock_Minimo.Text = medicamento.Stock_Minimo.ToString();
                cbMonodroga.SelectedItem = medicamento.Monodroga;
            }
            else
            {
                this.Text = "Agregar Medicamento";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (modificar_medicamento)
                {
                    medicamento.Nombre_Comercial = txtNombre_Comercial.Text;
                    medicamento.Es_Venta_Libre = Convert.ToBoolean(txtEs_Venta_Libre.Text);
                    medicamento.Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text);
                    medicamento.Stock = Convert.ToInt32(txtStock.Text);
                    medicamento.Stock_Minimo = Convert.ToInt32(txtStock_Minimo.Text);
                    medicamento.Monodroga = cbMonodroga.SelectedItem as Monodroga;

                    var mensaje = Controladora.ControladoraMedicamento.Instancia.ModificarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var medicamento = new Medicamento
                    {
                        Nombre_Comercial = txtNombre_Comercial.Text,
                        Es_Venta_Libre = Convert.ToBoolean(txtEs_Venta_Libre.Text),
                        Precio_Venta = Convert.ToInt32(txtPrecio_Venta.Text),
                        Stock = Convert.ToInt32(txtStock.Text),
                        Stock_Minimo = Convert.ToInt32(txtStock_Minimo.Text),
                        Monodroga = cbMonodroga.SelectedItem as Monodroga
                    };


                    foreach (DataGridViewRow row in dgvDrogueriasExistentes.Rows)
                    {
                        if (row.DataBoundItem is Drogueria drogueria)
                        {
                            drogueria.Droguerias.Add(drogueria);
                        }
                    }

                    if (drogueria.Droguerias.Count == 0)
                    {
                        MessageBox.Show("Debe agregarle una drogueria al medicamento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var mensaje = Controladora.ControladoraMedicamento.Instancia.AgregarMedicamento(medicamento);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasExistentes.Rows.Count > 0)
            {
                var drogueriaagregada = (Drogueria)dgvDrogueriasExistentes.CurrentRow.DataBoundItem;
                bool drogueriaexistente = RepositorioDroguerias.Instancia.Recuperar().Any(drog => drog.Cuit == drogueriaagregada.Cuit);

                if (drogueriaexistente)
                {
                    MediaPermission.Droguerias.Add(drogueriaagregada);
                    ActualizarGrilla();
                }
                else
                {
                    MessageBox.Show("La drogueria ya se encuentra asociado a un medicamento");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDrogueriasExistentes.Rows.Count > 0)
            {
                var drogueriaEliminada = (Drogueria)dgvDrogueriasExistentes.CurrentRow.DataBoundItem;

                if (medicamento.Droguerias.Contains(drogueriaEliminada))
                {
                    if (medicamento.Droguerias.Count > 1)
                    {
                        medicamento.Droguerias.Remove(drogueriaEliminada);
                        ActualizarGrilla();
                    }
                    else
                    {
                        MessageBox.Show("Debe existir al menos una drogueria relacionado al medicamento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("La drogueria seleccionada no está relacionada al medicamento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}