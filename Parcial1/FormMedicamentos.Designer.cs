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
            btnAgregarMedicamento = new Button();
            btnEditarMedicamento = new Button();
            btnEliminarMedicamento = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).BeginInit();
            SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            dgvMedicamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMedicamentos.Location = new Point(12, 12);
            dgvMedicamentos.Name = "dgvMedicamentos";
            dgvMedicamentos.RowHeadersWidth = 51;
            dgvMedicamentos.RowTemplate.Height = 29;
            dgvMedicamentos.Size = new Size(776, 379);
            dgvMedicamentos.TabIndex = 0;
            // 
            // btnAgregarMedicamento
            // 
            btnAgregarMedicamento.Location = new Point(12, 408);
            btnAgregarMedicamento.Name = "btnAgregarMedicamento";
            btnAgregarMedicamento.Size = new Size(234, 29);
            btnAgregarMedicamento.TabIndex = 1;
            btnAgregarMedicamento.Text = "Agregar nuevo medicamento";
            btnAgregarMedicamento.UseVisualStyleBackColor = true;
            btnAgregarMedicamento.Click += btnAgregarMedicamento_Click;
            // 
            // btnEditarMedicamento
            // 
            btnEditarMedicamento.Location = new Point(252, 408);
            btnEditarMedicamento.Name = "btnEditarMedicamento";
            btnEditarMedicamento.Size = new Size(266, 29);
            btnEditarMedicamento.TabIndex = 2;
            btnEditarMedicamento.Text = "Editar medicamento seleccionado";
            btnEditarMedicamento.UseVisualStyleBackColor = true;
            btnEditarMedicamento.Click += btnEditarMedicamento_Click;
            // 
            // btnEliminarMedicamento
            // 
            btnEliminarMedicamento.Location = new Point(524, 408);
            btnEliminarMedicamento.Name = "btnEliminarMedicamento";
            btnEliminarMedicamento.Size = new Size(264, 29);
            btnEliminarMedicamento.TabIndex = 3;
            btnEliminarMedicamento.Text = "Eliminar medicamento seleccionado";
            btnEliminarMedicamento.UseVisualStyleBackColor = true;
            btnEliminarMedicamento.Click += btnEliminarMedicamento_Click;
            // 
            // FormMedicamentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 458);
            Controls.Add(btnEliminarMedicamento);
            Controls.Add(btnEditarMedicamento);
            Controls.Add(btnAgregarMedicamento);
            Controls.Add(dgvMedicamentos);
            Name = "FormMedicamentos";
            Text = "FormMedicamentos";
            Load += FormMedicamentos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMedicamentos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMedicamentos;
        private Button btnAgregarMedicamento;
        private Button btnEditarMedicamento;
        private Button btnEliminarMedicamento;
    }
}