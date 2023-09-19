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
            dgvMedicamentos = new DataGridView();
            btnAgregarMed = new Button();
            btnModificarMed = new Button();
            btnEliminarMed = new Button();
            btnSalirMed = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(12, 12);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowTemplate.Height = 25;
            dgvMedicamentos.Size = new Size(653, 290);
            dgvMedicamentos.TabIndex = 0;
            // 
            // btnAgregarMed
            // 
            btnAgregarMed.Location = new Point(12, 314);
            btnAgregarMed.Name = "btnAgregarMed";
            btnAgregarMed.Size = new Size(75, 23);
            btnAgregarMed.TabIndex = 1;
            btnAgregarMed.Text = "Agregar";
            btnAgregarMed.UseVisualStyleBackColor = true;
            btnAgregarMed.Click += btnAgregarMed_Click;
            // 
            // btnModificarMed
            // 
            btnModificarMed.Location = new Point(134, 314);
            btnModificarMed.Name = "btnModificarMed";
            btnModificarMed.Size = new Size(75, 23);
            btnModificarMed.TabIndex = 2;
            btnModificarMed.Text = "Modificar";
            btnModificarMed.UseVisualStyleBackColor = true;
            btnModificarMed.Click += btnModificarMed_Click;
            // 
            // btnEliminarMed
            // 
            btnEliminarMed.Location = new Point(255, 314);
            btnEliminarMed.Name = "btnEliminarMed";
            btnEliminarMed.Size = new Size(75, 23);
            btnEliminarMed.TabIndex = 3;
            btnEliminarMed.Text = "Eliminar";
            btnEliminarMed.UseVisualStyleBackColor = true;
            btnEliminarMed.Click += btnEliminarMed_Click;
            // 
            // btnSalirMed
            // 
            btnSalirMed.Location = new Point(590, 314);
            btnSalirMed.Name = "btnSalirMed";
            btnSalirMed.Size = new Size(75, 23);
            btnSalirMed.TabIndex = 4;
            btnSalirMed.Text = "Salir";
            btnSalirMed.UseVisualStyleBackColor = true;
            btnSalirMed.Click += btnSalirMed_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 349);
            Controls.Add(btnSalirMed);
            Controls.Add(btnEliminarMed);
            Controls.Add(btnModificarMed);
            Controls.Add(btnAgregarMed);
            Controls.Add(dgvMedicamentos);
            Name = "FormMedicamentos";
            Text = "Medicamentos";
            Load += FormMedicamento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private Button btnAgregarMed;
        private Button btnModificarMed;
        private Button btnEliminarMed;
        private Button btnSalirMed;
    }
}