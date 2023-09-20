namespace Parcial1
{
    partial class FormMedicamentos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAceptar = new Button();
            dgvMedicamentos = new DataGridView();
            label1 = new Label();
            dgvDrogueriasAsociadas = new DataGridView();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAsociadas).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(12, 166);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(12, 10);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicamentos.Size = new Size(483, 150);
            dgvMedicamentos.TabIndex = 1;
            dgvMedicamentos.SelectionChanged += dgvMedicamentos_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 223);
            label1.Name = "label1";
            label1.Size = new Size(248, 15);
            label1.TabIndex = 2;
            label1.Text = "DROGUERIAS ASOCIADAS A MEDICAMENTOS";
            // 
            // dgvDrogueriasAsociadas
            // 
            dgvDrogueriasAsociadas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDrogueriasAsociadas.Location = new Point(12, 241);
            dgvDrogueriasAsociadas.Name = "dgvDrogueriasAsociadas";
            dgvDrogueriasAsociadas.RowTemplate.Height = 25;
            dgvDrogueriasAsociadas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDrogueriasAsociadas.Size = new Size(483, 150);
            dgvDrogueriasAsociadas.TabIndex = 3;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(226, 166);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 4;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(420, 166);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 405);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dgvDrogueriasAsociadas);
            Controls.Add(label1);
            Controls.Add(dgvMedicamentos);
            Controls.Add(btnAceptar);
            Name = "FormMedicamentos";
            Text = "FormMedicamentos";
            Load += FormMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDrogueriasAsociadas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private DataGridView dgvMedicamentos;
        private Label label1;
        private DataGridView dgvDrogueriasAsociadas;
        private Button btnModificar;
        private Button btnEliminar;
    }
}