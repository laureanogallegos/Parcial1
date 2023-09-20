namespace Parcial1
{
    partial class FormMedicamentos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvMedicamento = new DataGridView();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnAsignarProveedor = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamento).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamento
            // 
            dgvMedicamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamento.Location = new Point(12, 12);
            dgvMedicamento.Name = "dgvMedicamento";
            dgvMedicamento.RowTemplate.Height = 25;
            dgvMedicamento.Size = new Size(695, 363);
            dgvMedicamento.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(713, 12);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(713, 41);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(713, 70);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Borrar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAsignarProveedor
            // 
            btnAsignarProveedor.Location = new Point(713, 99);
            btnAsignarProveedor.Name = "btnAsignarProveedor";
            btnAsignarProveedor.Size = new Size(75, 23);
            btnAsignarProveedor.TabIndex = 4;
            btnAsignarProveedor.Text = "Asignar P.";
            btnAsignarProveedor.UseVisualStyleBackColor = true;
            btnAsignarProveedor.Click += btnAsignarProveedor_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 387);
            Controls.Add(btnAsignarProveedor);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvMedicamento);
            Name = "FormMedicamentos";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMedicamento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMedicamento;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAsignarProveedor;
    }
}